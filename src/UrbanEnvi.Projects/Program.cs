using OpenIddict.Validation.AspNetCore;
using System.Diagnostics;
using UrbanEnvi;
using UrbanEnvi.GraphQL;
using UrbanEnvi.Persistence;

Activity.DefaultIdFormat = ActivityIdFormat.W3C;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuthorization()
    .AddAuthentication(options => options.DefaultScheme = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);

builder.Services
    .AddOpenIddict()
    .AddValidation(options =>
    {
        _ = options.SetIssuer(builder.Configuration.GetServiceUri(WellKnownService.Identity))
            .AddAudiences(WellKnownService.Projects.DasherizedName)
            .AddEncryptionCertificate(
                builder.Configuration.CertificateFromPem(WellKnownService.Identity)
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
