
namespace E_Shop.Brokers.Loggings;

public class LoggingBroker : ILoggingBroker
{
    public void LogError(Exception exception)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(exception.Message);
        Console.ResetColor();
    }

    public void LogError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void LogInformation(string message)
    {
        Console.WriteLine(message);
    }
}
