namespace TestTask.DepthQuotesSystem.OrderBook;

internal record ServiceConfig
{
    public string QuoteChannel { get; init; }

    public string OrderBookSnapshotChannel { get; init; }

    public string BusConnectionString { get; init; }
}