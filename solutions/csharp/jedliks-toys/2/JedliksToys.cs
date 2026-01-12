class RemoteControlCar
{
    public int MetersDriven;
    
    public int BatteryPercentage = 100;

    public static RemoteControlCar Buy() => new RemoteControlCar();
    
    public string DistanceDisplay() => $"Driven {MetersDriven} meters";

    public string BatteryDisplay() => BatteryPercentage > 0 ? $"Battery at {BatteryPercentage}%" : "Battery empty";
    
    public void Drive()
    {
        if (BatteryPercentage == 0) return;
        
        MetersDriven = MetersDriven + 20;
        BatteryPercentage = BatteryPercentage - 1;
    }
}
