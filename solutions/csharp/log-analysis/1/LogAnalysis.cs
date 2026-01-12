public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
        public static string SubstringAfter(this string input, string after)
    {    
        return input.Split(after)[1];
    }

    // TODO: define the 'SubstringBetween()' extension method on the `string` type
        public static string SubstringBetween(this string input, string firstDelimiter, string secondDelimiter)
    {    
        string first = input.Split(firstDelimiter)[1];
        string result = first.Split(secondDelimiter)[0];
        
        return result;
    }
    
    // TODO: define the 'Message()' extension method on the `string` type
        public static string Message(this string input)
    {
        return input.SubstringAfter(": ");
    }
    // TODO: define the 'LogLevel()' extension method on the `string` type
        public static string LogLevel(this string input)
    {
        return input.SubstringBetween("[", "]");
    }
}