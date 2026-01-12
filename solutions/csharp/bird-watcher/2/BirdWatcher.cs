class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek() => [0, 2, 5, 3, 7, 8, 4];

    public int Today() => birdsPerDay[birdsPerDay.Length - 1];

    public void IncrementTodaysCount() => birdsPerDay[birdsPerDay.Length - 1] = Today() + 1;

    public bool HasDayWithoutBirds()
    {
        foreach (char day in birdsPerDay)
        {
            if (day == 0) return true;
        }

        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int totalBirdCount = 0;
        
        for (int i = 0; i < numberOfDays; i++)
        {
            totalBirdCount = totalBirdCount + birdsPerDay[i];
        }

        return totalBirdCount;
    }

    public int BusyDays()
    {
        int busyDayCount = 0;
        
        foreach (char day in birdsPerDay)
        {
            if (day > 4) busyDayCount++;
        }

        return busyDayCount;
    }
}

