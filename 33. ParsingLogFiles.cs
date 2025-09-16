using System.Text.RegularExpressions;

public class LogParser
{
    public bool IsValidLine(string text)
    {
        const string pattern = @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]";
        return Regex.IsMatch(text, pattern);
    }

    public string[] SplitLogLine(string text)
    {
        const string pattern = @"<[\^*=-]+>";
        return Regex.Split(text, pattern);
    }

    public int CountQuotedPasswords(string lines)
    {
        const string pattern = """
                               ".*password.*"
                               """;

        return Regex.Count(lines, pattern, RegexOptions.IgnoreCase);
    }

    public string RemoveEndOfLineText(string line)
    {
        const string pattern = "end-of-line[0-9]+";
        return Regex.Replace(line, pattern, "");
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        List<string> output = [];
        const string pattern = @"password\S+";
        foreach (var line in lines)
        {
            var match = Regex.Match(line, pattern, RegexOptions.IgnoreCase);
            output.Add(match.Success ? $"{match.Value}: {line}" : $"--------: {line}");
        }

        return output.ToArray();
    }
}
