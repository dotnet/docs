using System;

namespace NewStyle
{
    public static class ExceptionExtensions
    {
        public static bool LogException(this Exception e)
        {
            Console.Error.WriteLine(@"Exceptions happen: {e}");
            return false;
        }  
    }
}