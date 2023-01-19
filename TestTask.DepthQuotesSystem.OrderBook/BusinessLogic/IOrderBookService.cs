using TestTask.DepthQuotesSystem.Messages;

namespace TestTask.DepthQuotesSystem.OrderBook.BusinessLogic;

public interface IOrderBookService
{
    void Process(OrderBookUpdate update);
    OrderBookSnapShot GetSnapShot(string symbol);
}