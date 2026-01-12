public static class LogAnalysis 
{
        public static string SubstringAfter(this string input, string after)
    {    
        return input.Split(after)[1];
    }

        public static string SubstringBetween(this string input, string firstDelimiter, string secondDelimiter)
    {    
        string first = input.Split(firstDelimiter)[1];
        return first.Split(secondDelimiter)[0];
    }
    
        public static string Message(this string input)
    {
        return input.SubstringAfter(": ");
    }
    
        public static string LogLevel(this string input)
    {
        return input.SubstringBetween("[", "]");
    }
}