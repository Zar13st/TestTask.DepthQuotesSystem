using TestTask.DepthQuotesSystem.Communication.Interface;
using TestTask.DepthQuotesSystem.Messages;
using TestTask.DepthQuotesSystem.Messages.Enums;

namespace TestTask.DepthQuotesSystem.MarketDataService.Workers;

internal class MarketDataConsumeWorker : BackgroundService
{
    private readonly ILogger<MarketDataConsumeWorker> _logger;
    private readonly IBus _bus;
    private readonly ServiceConfig _config;

    public MarketDataConsumeWorker(ILogger<MarketDataConsumeWorker> logger, IBus bus, ServiceConfig config)
    {
        _logger = logger;
        _bus = bus;
        _config = config;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Market Data Consumer worker started at {time} UTC", DateTime.UtcNow);

        var msg1 = new Quote
        {
            Price = 22222,
            Quantaty = 123,
            Type = QuoteType.Ask,
        };

        var msg2 = new Quote
        {
            Price = 21111,
            Quantaty = 111,
            Type = QuoteType.Bid,
        };

        var msq = new OrderBookUpdate
        {
            Symbol = "BTCUSD_perp",
            Quotes = new List<Quote>(){ msg1, msg2}
        };

        while (!cancellationToken.IsCancellationRequested)
        {
            _bus.Publish(_config.QuoteChannel, msq);

            await Task.Delay(1000, cancellationToken);
        }

        _logger.LogInformation("Market Data Consumer worker stopped at {time} UTC", DateTime.UtcNow);
    }
}