namespace Domain.Interfaces;

public interface ILoggerService
{
    void Info(string message);
    void Error(string message);
}
