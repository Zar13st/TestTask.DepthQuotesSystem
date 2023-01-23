using TestTask.DepthQuotesSystem.Communication.Interface;
using TestTask.DepthQuotesSystem.Messages;
using TestTask.DepthQuotesSystem.OrderBook.BusinessLogic;


namespace TestTask.DepthQuotesSystem.OrderBook.MessageHandlers;

public class OrderBookUpdateHandler : IHandler<OrderBookUpdate>
{
    private readonly ILogger<OrderBookUpdateHandler> _logger;
    private readonly IOrderBookService _orderBookService;

    public OrderBookUpdateHandler(ILogger<OrderBookUpdateHandler> logger, IOrderBookService orderBookService)
    {
        _logger = logger;
        _orderBookService = orderBookService;
    }

    public async Task ProcessAsync(OrderBookUpdate message)
    {
        _logger.LogInformation($"{nameof(OrderBookUpdateHandler)} {message}");

        _orderBookService.Process(message);
    }
}