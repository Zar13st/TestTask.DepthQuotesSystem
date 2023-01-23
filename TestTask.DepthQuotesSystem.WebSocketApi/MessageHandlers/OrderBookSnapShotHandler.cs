using TestTask.DepthQuotesSystem.Communication.Interface;
using TestTask.DepthQuotesSystem.Messages;

namespace TestTask.DepthQuotesSystem.WebSocketApi.MessageHandlers;

public class OrderBookSnapShotHandler: IHandler<OrderBookSnapShot>
{
    private readonly ILogger<OrderBookSnapShotHandler> _logger;

    public OrderBookSnapShotHandler(ILogger<OrderBookSnapShotHandler> logger)
    {
        _logger = logger;
    }

    public Task ProcessAsync(OrderBookSnapShot message)
    {
        _logger.LogInformation($"{nameof(OrderBookSnapShotHandler)} {message}");

        return Task.CompletedTask;
    }
}