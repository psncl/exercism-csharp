// https://exercism.org/tracks/csharp/exercises/weighing-machine

class WeighingMachine(int precision)
{
    public int Precision { get; } = precision;

    private double _weight;

    public double Weight
    {
        get => _weight;
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException();
            _weight = value;
        }
    }

    public double TareAdjustment { get; set; } = 5.0d;

    public string DisplayWeight => $"{(Weight - TareAdjustment).ToString($"F{Precision}")} kg";
}
