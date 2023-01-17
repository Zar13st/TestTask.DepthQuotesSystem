namespace TestTask.DepthQuotesSystem.Communication.Interface;

public interface IBus
{
    void Publish<T>(string channel, T message);
}