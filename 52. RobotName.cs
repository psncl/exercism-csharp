// https://exercism.org/tracks/csharp/exercises/robot-name

using System.Text;

public class Robot
{
    private static readonly HashSet<string> ExistingRobots = new();
    private static readonly Random RandomGenerator = new();

    public Robot() => SetRandomName();

    public string Name { get; private set; }

    private void SetRandomName()
    {
        while (true)
        {
            string randomName = GenerateRandomRobotName();
            if (!ExistingRobots.Add(randomName)) continue;
            Name = randomName;
            break;
        }
    }

    public void Reset()
    {
        ExistingRobots.Remove(Name);
        SetRandomName();
    }

    private static string GenerateRandomRobotName()
    {
        const string letterPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string numberPool = "0123456789";
        var builder = new StringBuilder();

        for (var i = 0; i < 2; i++)
        {
            builder.Append(letterPool[RandomGenerator.Next(0, letterPool.Length)]);
        }

        for (var i = 0; i < 3; i++)
        {
            builder.Append(numberPool[RandomGenerator.Next(0, numberPool.Length)]);
        }

        return builder.ToString();
    }
}