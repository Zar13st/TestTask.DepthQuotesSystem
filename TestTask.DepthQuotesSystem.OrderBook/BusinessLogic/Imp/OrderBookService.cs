using System.Collections.Concurrent;
using TestTask.DepthQuotesSystem.Messages;
using TestTask.DepthQuotesSystem.OrderBook.Extensions;

namespace TestTask.DepthQuotesSystem.OrderBook.BusinessLogic.Imp;

public class OrderBookService : IOrderBookService
{
    private readonly ConcurrentDictionary<string, ConcurrentDictionary<decimal, OrderBookLevel>> _orderBookBySymbol  = new ();

    public void Process(OrderBookUpdate update)
    {
        var orderBook = _orderBookBySymbol.GetOrAdd(update.Symbol, new ConcurrentDictionary<decimal, OrderBookLevel>());

        foreach (var quote in update.Quotes)
        {
            if (quote.Quantaty == 0)
            {
                orderBook.Remove(quote.Price, out _);
            }
            else
            {
                orderBook.AddOrUpdate(quote.Price, quote.ToOrderBookLevel(), (key, oldValue) => quote.ToOrderBookLevel());
            }
        }
    }

    public OrderBookSnapShot GetSnapShot(string symbol)
    {
        var isSuccess = _orderBookBySymbol.TryGetValue(symbol, out var orderBook);
        if (isSuccess)
        {
            return new OrderBookSnapShot
            {
                Symbol = symbol,
                Levels = orderBook!.Values.Select(x => x.ToDto()).ToList()
            };
        }
        else
        {
            return new OrderBookSnapShot
            {
                Symbol = symbol,
                Levels = new List<Messages.OrderBookLevel>()
            };
        }
    }
}