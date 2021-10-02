using System.Diagnostics;
using UrbanEnvi.GraphQL;
using UrbanEnvi.Persistence;

Activity.DefaultIdFormat = ActivityIdFormat.W3C;

var builder = WebApplication.CreateBuilder(args);

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
    .UseRouting()
    .UseCloudEvents()
    .UseEndpoints(endpoints => endpoints.MapGraphQL());

app.Run();
