using TestTask.DepthQuotesSystem.Communication.Nats;
using TestTask.DepthQuotesSystem.Messages;
using TestTask.DepthQuotesSystem.OrderBook;


var builder = WebApplication.CreateBuilder(args);

var config = new ServiceConfig
{
    QuoteChannel = builder.Configuration["MESSAGEBUS_BOOK20_CHANEL_NAME"],
    OrderBookSnapshotChannel = builder.Configuration["MESSAGEBUS_ORDERBOOK_SNAPSHOOT_CHANEL_NAME"],
    BusConnectionString = builder.Configuration["MESSAGEBUS_CONNECTION_STRING"],
};

builder.Services.AddSingleton(config);

builder.Services.AddBusinessLogic();

builder.Services.AddNutsMessageBus(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

using (var scope = app.Services.CreateScope())
{
    var consumer = scope.ServiceProvider.GetRequiredService<NatsConsumer>();
    consumer.Suscribe<OrderBookUpdate>(config.BusConnectionString, config.QuoteChannel);
}

await app.RunAsync();
