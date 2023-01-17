using TestTask.DepthQuotesSystem.Communication.Interface;
using TestTask.DepthQuotesSystem.Messages;

namespace TestTask.DepthQuotesSystem.WebSocketApi.MessageHandlers;

public class QuoteHandler: IHandler<Quote>
{
    private readonly ILogger<QuoteHandler> _logger;

    public QuoteHandler(ILogger<QuoteHandler> logger)
    {
        _logger = logger;
    }

    public void Process(Quote message)
    {
        _logger.LogWarning($"{nameof(QuoteHandler)} {message}");
    }
}