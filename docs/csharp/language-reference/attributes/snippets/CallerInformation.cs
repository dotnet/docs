using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace attributes
{
    internal class CallerInformation
    {
        // <CallerFileMemberLine>
        public void DoProcessing()
        {
            TraceMessage("Something happened.");
        }

        public void TraceMessage(string message,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            Trace.WriteLine("message: " + message);
            Trace.WriteLine("member name: " + memberName);
            Trace.WriteLine("source file path: " + sourceFilePath);
            Trace.WriteLine("source line number: " + sourceLineNumber);
        }

        // Sample Output:
        //  message: Something happened.
        //  member name: DoProcessing
        //  source file path: c:\Visual Studio Projects\CallerInfoCS\CallerInfoCS\Form1.cs
        //  source line number: 31
        // </CallerFileMemberLine>

        // <InvokeTestCondition>
        public void Operation(Action func)
        {
            Utilities.ValidateArgument(nameof(func), func is not null);
            func();
        }
        // </InvokeTestCondition>


        public static class Utilities
        {
            // <TestCondition>
            public static void ValidateArgument(string parameterName, bool condition, [CallerArgumentExpression("condition")] string? message=null)
            {
                if (!condition)
                {
                    throw new ArgumentException($"Argument failed validation: <{message}>", parameterName);
                }
            }
            // </TestCondition>
        }
    }

    public static class Extensions
    {
        // <ExtensionMethod>
        public static IEnumerable<T> Sample<T>(this IEnumerable<T> sequence, int frequency, 
            [CallerArgumentExpression("sequence")] string? message = null)
        {
            if (sequence.Count() < frequency)
                throw new ArgumentException($"Expression doesn't have enough elements: {message}", nameof(sequence));
            int i = 0;
            foreach (T item in sequence)
            {
                if (i++ % frequency == 0)
                    yield return item;
            }
        }
        // </ExtensionMethod>

    }
}
