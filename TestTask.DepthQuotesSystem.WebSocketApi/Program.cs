using TestTask.DepthQuotesSystem.Communication.Nats;
using TestTask.DepthQuotesSystem.Messages;
using TestTask.DepthQuotesSystem.OrderBook;

var builder = WebApplication.CreateBuilder(args);

var config = new ServiceConfig
{
    OrderBookSnapshotChannel = builder.Configuration["MESSAGEBUS_ORDERBOOK_SNAPSHOOT_CHANEL_NAME"],
    BusConnectionString = builder.Configuration["MESSAGEBUS_CONNECTION_STRING"],
};

builder.Services.AddControllers();



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var consumer = scope.ServiceProvider.GetRequiredService<NatsConsumer>();
    consumer.Suscribe<OrderBookSnapShot>(config.BusConnectionString, config.OrderBookSnapshotChannel);
}

await app.RunAsync();
