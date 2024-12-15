using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Serilog;
using ILogger = Serilog.ILogger;

namespace UserService.Data.Provider.Interceptors;

public class LogQueryInterceptor : DbCommandInterceptor
{
    private const int SlowQueryThreshold = 200;

    private readonly ILogger _logger = Log.ForContext<LogQueryInterceptor>();

    public override DbDataReader ReaderExecuted(
        DbCommand command,
        CommandExecutedEventData eventData,
        DbDataReader result)
    {
        if (eventData.Duration.TotalMilliseconds > SlowQueryThreshold)
        {
            _logger.Warning($"Slow query ({eventData.Duration.TotalMilliseconds} ms): \"{command.CommandText}\".");
        }

        _logger.Debug($"Command executed: {command.CommandText}.");
        _logger.Verbose($"Duration time {eventData.Duration.TotalMilliseconds} ms.");

        return base.ReaderExecuted(command, eventData, result);
    }
}