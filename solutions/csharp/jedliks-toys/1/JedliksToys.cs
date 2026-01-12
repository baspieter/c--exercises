class RemoteControlCar
{
    public int MetersDriven;
    public int BatteryPercentage = 100;

    
    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return "Driven " + MetersDriven + " meters";
    }

    public string BatteryDisplay()
    {
        return BatteryPercentage > 0
            ? "Battery at " + BatteryPercentage + "%" 
            : "Battery empty";
    }

    public void Drive()
    {
        if (BatteryPercentage == 0) return;
        
        MetersDriven = MetersDriven + 20;
        BatteryPercentage = BatteryPercentage - 1;
    }
}
