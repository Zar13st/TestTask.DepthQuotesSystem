namespace TestTask.DepthQuotesSystem.Messages;

public record OrderBookUpdate
{
    public string Symbol { get; init; }

    public List<Quote> Quotes { get; init; }
}