namespace TestTask.DepthQuotesSystem.OrderBook;

internal record ServiceConfig
{
    public string OrderBookSnapshotChannel { get; init; }

    public string BusConnectionString { get; init; }
}