namespace TestTask.DepthQuotesSystem.Messages;

public record OrderBookSnapShot
{
    public string Symbol { get; init; }

    public List<Level> Levels { get; init; }
}