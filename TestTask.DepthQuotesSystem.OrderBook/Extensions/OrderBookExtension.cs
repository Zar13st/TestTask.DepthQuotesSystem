using TestTask.DepthQuotesSystem.Messages;
using TestTask.DepthQuotesSystem.OrderBook.BusinessLogic.Imp;
using OrderBookLevel = TestTask.DepthQuotesSystem.Messages.OrderBookLevel;

namespace TestTask.DepthQuotesSystem.OrderBook.Extensions;

public static class OrderBookExtension
{
    public static BusinessLogic.Imp.OrderBookLevel ToOrderBookLevel(this Quote quote)
    {
        return new BusinessLogic.Imp.OrderBookLevel
        {
            Price = quote.Price,
            Quantaty = quote.Quantaty,
            Type = quote.Type
        };
    }

    public static OrderBookSnapShot ToSnapshot(this string symbol, IEnumerable<BusinessLogic.Imp.OrderBookLevel> levels)
    {
        return new OrderBookSnapShot
        {
            Symbol = symbol,
            Levels = null
        };
    }

    public static OrderBookLevel ToDto(this BusinessLogic.Imp.OrderBookLevel level)
    {
        return new OrderBookLevel
        {
            Price = level.Price,
            Quantaty = level.Quantaty,
            Type = level.Type
        };
    }
}