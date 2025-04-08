// https://exercism.org/tracks/csharp/exercises/logs-logs-logs
// Practice Enums

// TODO: define the 'LogLevel' enum
enum LogLevel : ushort
{
    Unknown = 0,
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42
}

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        string logType = logLine.Substring(1, 3);
        return logType switch
        {
            "TRC" => LogLevel.Trace,
            "DBG" => LogLevel.Debug,
            "INF" => LogLevel.Info,
            "WRN" => LogLevel.Warning,
            "ERR" => LogLevel.Error,
            "FTL" => LogLevel.Fatal,
            _ => LogLevel.Unknown
        };
    }

    public static string OutputForShortLog(LogLevel logLevel, string message) => $"{(ushort)logLevel}:{message}";
}
