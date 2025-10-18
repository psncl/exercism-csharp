// https://exercism.org/tracks/csharp/exercises/beauty-salon-goes-global
// Practice DateTime, TimeZoneInfo and CultureInfo

using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    private static readonly Dictionary<Location, TimeZoneInfo> TimeZones = new()
    {
        {
            Location.NewYork,
            CurrentPlatform() == OSPlatform.Windows
                ? TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")
                : TimeZoneInfo.FindSystemTimeZoneById("America/New_York")
        },
        {
            Location.London,
            CurrentPlatform() == OSPlatform.Windows
                ? TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time")
                : TimeZoneInfo.FindSystemTimeZoneById("Europe/London")
        },
        {
            Location.Paris,
            CurrentPlatform() == OSPlatform.Windows
                ? TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time")
                : TimeZoneInfo.FindSystemTimeZoneById("Europe/Paris")
        }
    };

    private static readonly Dictionary<Location, CultureInfo> Cultures = new()
    {
        { Location.NewYork, CultureInfo.GetCultureInfo("en-US") },
        { Location.London, CultureInfo.GetCultureInfo("en-GB") },
        { Location.Paris, CultureInfo.GetCultureInfo("fr-FR") }
    };

    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        DateTime apptTime =
            DateTime.ParseExact(appointmentDateDescription, "M/d/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        return TimeZoneInfo.ConvertTime(apptTime, CurrentTimeZone(location), TimeZoneInfo.Utc);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        return alertLevel switch
        {
            AlertLevel.Early => appointment.AddDays(-1),
            AlertLevel.Standard => appointment.AddMinutes(-105),
            AlertLevel.Late => appointment.AddMinutes(-30)
        };
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        return CurrentTimeZone(location).IsDaylightSavingTime(dt) !=
               CurrentTimeZone(location).IsDaylightSavingTime(dt.AddDays(-7));
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        CultureInfo currentCulture = Cultures[location];

        try
        {
            return DateTime.Parse(dtStr, currentCulture);
        }
        catch (FormatException)
        {
            return new DateTime(1, 1, 1);
        }
    }

    private static OSPlatform CurrentPlatform()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return OSPlatform.Windows;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) return OSPlatform.Linux;
        return OSPlatform.Create("Unknown OS");
    }

    private static TimeZoneInfo CurrentTimeZone(Location location) => TimeZones[location];
}