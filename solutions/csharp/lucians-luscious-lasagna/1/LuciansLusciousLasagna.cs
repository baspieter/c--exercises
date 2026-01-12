class Lasagna
{
    public int ExpectedMinutesInOven()
    {
        return 40;
    }
    
    public int RemainingMinutesInOven(int TimeInOven)
    {
        return ExpectedMinutesInOven() - TimeInOven;
    }


    public int PreparationTimeInMinutes(int layers)
    {
        return layers * 2;
    }


    public int ElapsedTimeInMinutes(int NumberOfLayers, int TimeInOven)
    {
        int LayerTime = PreparationTimeInMinutes(NumberOfLayers);

        return TimeInOven + LayerTime;
    }
}
