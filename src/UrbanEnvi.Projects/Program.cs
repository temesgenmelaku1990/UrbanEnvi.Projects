using OpenIddict.Validation.AspNetCore;
using System.Diagnostics;
using UrbanEnvi;
using UrbanEnvi.GraphQL;
using UrbanEnvi.Persistence;

Activity.DefaultIdFormat = ActivityIdFormat.W3C;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuthentication(options => options.DefaultScheme = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);

builder.Services
    .AddOpenIddict()
    .AddValidation(options =>
    {
        _ = options.SetIssuer(builder.Configuration.GetServiceUri(WellKnownServices.Identity))
            .AddAudiences(WellKnownServices.Projects)
            .AddEncryptionCertificate(
                builder.Configuration.CertificateFromPem(WellKnownServices.Identity)
            );

        _ = options.UseSystemNetHttp();
        _ = options.UseAspNetCore();
    });

builder.Services
    .AddHttpContextAccessor()
    .AddUrbanEnviCore()
    .AddDefaultRedis(builder.Configuration)
    .AddPersistence(builder.Configuration)
    .AddDefaultGrpc()
    .AddDefaultDaprClient()
    .AddDefaultMediatr()
    .AddGraphQL();

var app = builder.Build();

app.Services.UseUrbanEnviCore();

app
    .UseStaticFiles()
    .UseAuthentication()
    .UseAuthorization()
    .UseRouting()
    .UseCloudEvents()
    .UseEndpoints(endpoints => endpoints.MapGraphQL());

app.Run();
