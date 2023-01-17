namespace TestTask.DepthQuotesSystem.Communication.Interface;

public interface IHandler<in T> where T : class
{
    void Process(T message);
}