public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        switch (shirtNum)
        {
            case 1:
                return "goalie";
                break;
            case 2:
                return "left back";
                break;
            case 3:
            case 4:
                return "Left back";
                break;
            case 5:
                return "right back";
            case 6:
            case 7:
            case 8:
                return "midfielder";
            case 9:
                return "left wing";
            case 10:
                return "striker";
            case 11:
                return "right wing";
            default:
                return "UNKNOWN";
                break;
        }
    }

    public static string AnalyzeOffField(object report)
    {
        
        switch (report)
        {
            case int number:
                return "There are " + number + " supporters at the match.";
                break;
            case string text:
                return text;
                break;
            case Foul foul:
                return foul.GetDescription();
                break;
            case Injury injury:
                return injury.GetDescription();
                break;
            case Incident incident:
                return incident.GetDescription();
                break;
            case Manager manager:
                return manager.GetDescription();
                break;
            default:
                return "";
                break;
                
        }
    }
}
