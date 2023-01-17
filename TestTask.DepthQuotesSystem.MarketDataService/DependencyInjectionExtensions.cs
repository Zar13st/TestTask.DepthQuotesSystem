using NATS.Client;
using TestTask.DepthQuotesSystem.Communication.Interface;
using TestTask.DepthQuotesSystem.Communication.Nats;

namespace TestTask.DepthQuotesSystem.MarketDataService;

public static class DependencyInjectionExtensions
{
    public static void AddNutsMessageBus(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IBus, NatsPublisher>();

        services.AddNatsClient(configureOptions: options =>
        {
            options.Url = configuration["MESSAGEBUS_CONNECTION_STRING"];
        });
    }
}