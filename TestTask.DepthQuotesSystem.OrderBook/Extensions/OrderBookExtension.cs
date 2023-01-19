using TestTask.DepthQuotesSystem.Messages;
using TestTask.DepthQuotesSystem.OrderBook.BusinessLogic.Imp;

namespace TestTask.DepthQuotesSystem.OrderBook.Extensions;

public static class OrderBookExtension
{
    public static OrderBookLevel ToOrderBookLevel(this Quote quote)
    {
        return new OrderBookLevel
        {
            Price = quote.Price,
            Quantaty = quote.Quantaty,
            Type = quote.Type
        };
    }

    public static OrderBookSnapShot ToSnapshot(this string symbol, IEnumerable<OrderBookLevel> levels)
    {
        return new OrderBookSnapShot
        {
            Symbol = symbol,
            Levels = null
        };
    }

    public static Level ToDto(this OrderBookLevel level)
    {
        return new Level
        {
            Price = level.Price,
            Quantaty = level.Quantaty,
            Type = level.Type
        };
    }
}