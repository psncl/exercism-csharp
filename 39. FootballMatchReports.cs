// https://exercism.org/tracks/csharp/exercises/football-match-reports
// Practice switch statement

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        switch (shirtNum)
        {
            case 1:
                return "goalie";
            case 2:
                return "left back";
            case 3:
            case 4:
                return "center back";
            case 5:
                return "right back";
            case 6:
            case 7:
            case 8:
                return "midfielder";
            case 9:
                return "left wing";
            case 10:
                return "striker";
            case 11:
                return "right wing";
            default:
                return "UNKNOWN";
        }
    }

    public static string AnalyzeOffField(object report)
    {
        switch (report)
        {
            case int numberSupporters:
                return $"There are {numberSupporters} supporters at the match.";
            case string announcement:
                return announcement;
            case Injury injury:
                return $"Oh no! {injury.GetDescription()} Medics are on the field.";
            case Incident incident:
                return incident.GetDescription();
            case Manager manager when string.IsNullOrEmpty(manager.Club):
                return manager.Name;
            case Manager manager:
                return $"{manager.Name} ({manager.Club})";
            default:
                return "";
        }
    }
}