using TestTask.DepthQuotesSystem.Communication.Interface;
using TestTask.DepthQuotesSystem.Messages;

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
        
        while (!cancellationToken.IsCancellationRequested)
        {
            var msg = new Quote
            {
                Symbol = "BTCUSD_perp",
                Price = 22222,
                Quantaty = 123
            };
            _bus.Publish(_config.QuoteChannel, msg);
            await Task.Delay(1000, cancellationToken);
        }

        _logger.LogInformation("Market Data Consumer worker stopped at {time} UTC", DateTime.UtcNow);
    }
}