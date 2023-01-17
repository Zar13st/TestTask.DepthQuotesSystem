using TestTask.DepthQuotesSystem.MarketDataService;
using TestTask.DepthQuotesSystem.MarketDataService.Workers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

builder.Services.AddSingleton(p => new ServiceConfig()
{
    QuoteChannel = builder.Configuration["MESSAGEBUS_BOOK20_CHANEL_NAME"],
});

builder.Services.AddHostedService<MarketDataConsumeWorker>();

builder.Services.AddNutsMessageBus(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

await app.RunAsync();
