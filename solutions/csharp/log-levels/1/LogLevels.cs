static class LogLine
{
    public static string Message(string input)
    {
        string result = input.Split("]: ")[1];
        return result.Trim();
    }

    public static string LogLevel(string input)
    {
        int start = input.IndexOf('[') + 1;
        int end = input.IndexOf(']');
        
        string result = input.Substring(start, end - start);
        return result.ToLower();
    }

    public static string Reformat(string input)
    {   
        string type = LogLine.LogLevel(input);
        string message = LogLine.Message(input);
        return  $"{message} " + $"({type})";
    }
}
