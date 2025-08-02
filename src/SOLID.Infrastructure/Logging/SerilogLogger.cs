using Domain.Interfaces;
using Serilog;

namespace Infrastructure.Logging;

public class SerilogLogger : ILoggerService
{
    private readonly ILogger _logger;

    public SerilogLogger()
    {
        _logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
    }

    public void Info(string message) => _logger.Information(message);
    public void Error(string message) => _logger.Error(message);
}
