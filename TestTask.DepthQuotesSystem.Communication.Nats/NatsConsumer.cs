using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NATS.Client;
using NATS.Client.Rx;
using NATS.Client.Rx.Ops;
using TestTask.DepthQuotesSystem.Communication.Interface;

namespace TestTask.DepthQuotesSystem.Communication.Nats;

public class NatsConsumer
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<NatsConsumer> _logger;
    private IConnection _connection;

    public NatsConsumer(IServiceProvider serviceProvider, ILogger<NatsConsumer> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public void Suscribe<T>(string url, string channel) where T : class
    {
        _connection = new ConnectionFactory().CreateConnection(url);

        var messages = _connection.Observe(channel)
            .Where(m => m.Data?.Any() == true)
            .Select(m => m.Data);

        messages.Subscribe(async m =>
        {
            try
            {
                var plainTextMessage = Encoding.UTF8.GetString(m);

                var handler = _serviceProvider.GetRequiredService<IHandler<T>>();

                var msg = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(plainTextMessage);

                await handler.ProcessAsync(msg);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
        }, OnError);
    }

    private void OnError(Exception e)
    {
        _logger.LogError(e, e.Message);
    }
}