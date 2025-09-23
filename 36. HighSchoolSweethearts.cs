using System.Globalization;

public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        const int separatorLength = 3; //length of " ♡ "
        const int totalLength = 61;
        const int padding = (totalLength - separatorLength) / 2;
        return $"{studentA,padding} ♡ {studentB,-padding}";
    }

    public static string DisplayBanner(string studentA, string studentB)
    {
        return $"""

            ******       ******
               **      **   **      **
             **         ** **         **
            **            *            **
            **                         **
            **     {studentA} +  {studentB}    **
             **                       **
               **                   **
                 **               **
                   **           **
                     **       **
                       **   **
                         ***
                          *

            """;
    }

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours)
    {
        return
            $"{studentA} and {studentB} have been dating since {start:dd.MM.yyyy} - " +
            $"that's {hours.ToString("N2", new CultureInfo("de-DE"))} hours";
    }
}