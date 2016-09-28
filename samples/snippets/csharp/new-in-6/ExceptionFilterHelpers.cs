using System;

namespace NewStyle
{
    public static class ExceptionExtensions
    {
        // <ExceptionFilterLogging>
        public static bool LogException(this Exception e)
        {
            Console.Error.WriteLine(@"Exceptions happen: {e}");
            return false;
        } 
        // </ExceptionFilterLogging>
    }
}