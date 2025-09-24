using System.Text.RegularExpressions;

static class LogLine
{
    const string Pattern = @"^\[(INFO|WARNING|ERROR)\]:";
    public static string Message(string logLine)
    {
        string logMessage = Regex.Replace(logLine, Pattern, "");
        return logMessage.Trim();
    }

    public static string LogLevel(string logLine)
    {
        var match = Regex.Match(logLine, Pattern);
        const string removePattern = @"[\[\]:]"; //to match []:
        return Regex.Replace(match.Value, removePattern, "").ToLower();
    }

    public static string Reformat(string logLine) => $"{Message(logLine)} ({LogLevel(logLine)})";
}