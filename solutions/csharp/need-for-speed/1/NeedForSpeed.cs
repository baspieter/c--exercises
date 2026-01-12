class RemoteControlCar
{

    private int speed;
    private int batteryDrain;
    private int distanceDriven;
    private int battery = 100;
    
     public RemoteControlCar(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
    }

    public bool BatteryDrained() => this.battery < this.batteryDrain;

    public int DistanceDriven() => this.distanceDriven;

    public void Drive() {
        if (this.battery < this.batteryDrain) return;

        this.distanceDriven = this.distanceDriven + this.speed;   
        this.battery = this.battery - this.batteryDrain;
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{
    private int distance;

    public RaceTrack(int distance)
    {
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (car.DistanceDriven() < this.distance)
        {
            if (car.BatteryDrained()) return false;

            car.Drive();
        }

        return true;
    }
}
