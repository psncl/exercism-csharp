static class AssemblyLine
{
    private const int CarsPerHour = 221;
    public static double SuccessRate(int speed)
    {
        return speed switch
        {
            10 => 0.77,
            9 => 0.8,
            >= 5 => 0.9,
            >= 1 => 1.0,
            0 => 0.0,
            _ => throw new ArgumentOutOfRangeException(nameof(speed), speed, "Invalid speed")
        };
    }
    
    public static double ProductionRatePerHour(int speed)
    {
        return speed * CarsPerHour * SuccessRate(speed);
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        return (int) (ProductionRatePerHour(speed) / 60);
    }
}
