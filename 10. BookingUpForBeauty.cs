// https://exercism.org/tracks/csharp/exercises/booking-up-for-beauty

static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        return DateTime.Parse(appointmentDateDescription);
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        return appointmentDate < DateTime.Now;
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        return appointmentDate.Hour is >= 12 and < 18;
    }

    public static string Description(DateTime appointmentDate)
    {
        return $"You have an appointment on {DateTime.Parse(appointmentDate.ToString("G"))}.";
    }

    public static DateTime AnniversaryDate()
    {
        return new DateTime(DateTime.Now.Year, 9, 15);
    }
}
