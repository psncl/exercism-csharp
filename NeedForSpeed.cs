// https://exercism.org/tracks/csharp/exercises/need-for-speed

class RemoteControlCar
{
    private int speed;
    private int batteryLeft = 100;
    private int batteryDrain;
    private int distanceDriven = 0;
    
    // TODO: define the constructor for the 'RemoteControlCar' class
    public RemoteControlCar(int s, int b)
    {
        speed = s;
        batteryDrain = b;
    }
    public bool BatteryDrained()
    {
        return batteryLeft <= 0 || batteryLeft < batteryDrain;
    }

    public int DistanceDriven()
    {
        return distanceDriven;
    }

    public void Drive()
    {
        if (BatteryDrained()) return;
        distanceDriven += speed;
        batteryLeft -= batteryDrain;
    }   

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{
    // TODO: define the constructor for the 'RaceTrack' class
    private int distance;

    public RaceTrack(int d)
    {
        distance = d;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (!car.BatteryDrained() && car.DistanceDriven() < distance)
        {
            car.Drive();
        }

        return car.DistanceDriven() >= distance;
    }
}
