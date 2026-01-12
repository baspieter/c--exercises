class WeighingMachine
{

    public int Precision { get; private set; }
    private double _weight { get; set; }
    public double Weight
    {
        get { return _weight; }
        set
        {
            if (double.IsNegative(value))
                throw new ArgumentOutOfRangeException("Value cannot be negative.");
            _weight = value;
        }
    }
    public double TareAdjustment { get; set; } = 5;
    public string DisplayWeight
    {
        get
        {
            double result = Weight - TareAdjustment;
            return result.ToString($"F{Precision}") + " kg";
            // return $"{Math.Round(Weight - TareAdjustment, Precision)} kg";
        }
    }

    public string FirstName { get; set; } = "Jane";
    // Constructor
    public WeighingMachine(int precision)
    {
        Precision = precision;
    }
}
