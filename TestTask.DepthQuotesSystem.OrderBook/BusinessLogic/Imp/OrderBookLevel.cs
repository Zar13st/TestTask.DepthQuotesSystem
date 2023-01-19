using TestTask.DepthQuotesSystem.Messages.Enums;

namespace TestTask.DepthQuotesSystem.OrderBook.BusinessLogic.Imp;

public record OrderBookLevel
{
    public decimal Price { get; init; }

    public decimal Quantaty { get; init; }

    public QuoteType Type { get; init; }
}