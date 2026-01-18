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

    public void SetSponsors(params string[] sponsors) =>  this.sponsors = sponsors;

    public string DisplaySponsor(int sponsorNum) => sponsors[sponsorNum];
    public bool GetTelemetryData(ref int serialNum,
        out int batteryPercentage, out int distanceDrivenInMeters)
    {
        bool correctData = latestSerialNum < serialNum;
        batteryPercentage = correctData ? this.batteryPercentage : -1;
        distanceDrivenInMeters = correctData ? this.distanceDrivenInMeters : -1;
        latestSerialNum = correctData ? serialNum : latestSerialNum;
        serialNum = latestSerialNum;

        return correctData;
    }

    public static RemoteControlCar Buy() => new RemoteControlCar();
}

public class TelemetryClient
{
    private RemoteControlCar car;

    public TelemetryClient(RemoteControlCar car) => this.car = car;

    public string GetBatteryUsagePerMeter(int serialNum)
    {
        if (car.GetTelemetryData(ref serialNum, out var batteryPercentage, out var distanceDrivenInMeters) && distanceDrivenInMeters > 0)
        {
            int batteryUsePerMeter = (100 - batteryPercentage) / distanceDrivenInMeters;
            return $"usage-per-meter={batteryUsePerMeter}";
        } else
        {
            return "no data";
        }
    }
}