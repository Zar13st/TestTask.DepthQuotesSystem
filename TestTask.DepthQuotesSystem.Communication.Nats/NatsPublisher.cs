using System.Text;
using NATS.Client;
using TestTask.DepthQuotesSystem.Communication.Interface;

namespace TestTask.DepthQuotesSystem.Communication.Nats;

public class NatsPublisher : IBus
{
    private readonly IConnection _connection;

    public NatsPublisher(IConnection connection)
    {
        _connection = connection;
    }

    public void Publish<T>(string channel, T message)
    {
        var msg = Newtonsoft.Json.JsonConvert.SerializeObject(message);

        _connection.Publish(channel, Encoding.UTF8.GetBytes(msg)); 
    }
}