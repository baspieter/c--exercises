public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try
        {
            checked
            {
                return (@base * multiplier).ToString();
            }
        }
        catch (OverflowException)
        {
            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier) => float.IsInfinity(@base * multiplier) ? "*** Too Big ***" : (@base * multiplier).ToString();
    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try
        {
            checked
            {
                return (salaryBase * multiplier).ToString();
            }
        }
        catch (OverflowException)
        {
            return "*** Much Too Big ***";
        }
    }
}
