public class RemoteControlCar
{
    private int batteryPercentage = 100;
    private int distanceDrivenInMeters = 0;
    private string[] sponsors = new string[0];
    private int latestSerialNum = 0;

    public void Drive()
    {
        if (batteryPercentage > 0)
        {
            batteryPercentage -= 10;
            distanceDrivenInMeters += 2;
        }
    }

    public void SetSponsors(params string[] sponsors)
    {
        this.sponsors = sponsors.ToArray();
    }

    public string DisplaySponsor(int sponsorNum) => sponsors[sponsorNum];

    public bool GetTelemetryData(ref int serialNum,
        out int batteryPercentage, out int distanceDrivenInMeters)
    {
        if (serialNum < latestSerialNum)
        {
            serialNum = latestSerialNum;
            batteryPercentage = -1;
            distanceDrivenInMeters = -1;
            return false;
        }
        
        latestSerialNum = serialNum;
        batteryPercentage = this.batteryPercentage;
        distanceDrivenInMeters = this.distanceDrivenInMeters;
        return true;
    }

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }
}

public class TelemetryClient
{
    private RemoteControlCar car;

    public TelemetryClient(RemoteControlCar car)
    {
        this.car = car;
    }

    public string GetBatteryUsagePerMeter(int serialNum)
    {
        int batteryPercentage, distanceDrivenInMeters;
        bool telemetryExists = car.GetTelemetryData(ref serialNum, out batteryPercentage, out distanceDrivenInMeters); 
        
        if (!telemetryExists || distanceDrivenInMeters == 0) return "no data";
        return $"usage-per-meter={(100 - batteryPercentage) / distanceDrivenInMeters}";
    }
}