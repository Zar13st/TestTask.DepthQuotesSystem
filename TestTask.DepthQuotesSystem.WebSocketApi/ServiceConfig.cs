namespace TestTask.DepthQuotesSystem.WebSocketApi;

internal record ServiceConfig
{
    public string QuoteChannel { get; init; }

    public string BusConnectionString { get; init; }
}