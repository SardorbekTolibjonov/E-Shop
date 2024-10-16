namespace E_Shop.Brokers.Loggings;

public interface ILoggingBroker
{
    void LogInformation(string message);
    void LogError(Exception exception);
    void LogError(string message);
}
