using System;

namespace CallerInfoCS
{
    class CallerInfo
    {
        //<Snippet51>
        public void DoProcessing()
        {
            TraceMessage("Something happened.");
        }

        public void TraceMessage(string message,
                [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
                [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
                [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            System.Diagnostics.Trace.WriteLine("message: " + message);
            System.Diagnostics.Trace.WriteLine("member name: " + memberName);
            System.Diagnostics.Trace.WriteLine("source file path: " + sourceFilePath);
            System.Diagnostics.Trace.WriteLine("source line number: " + sourceLineNumber);
        }

        // Sample Output:
        //  message: Something happened.
        //  member name: DoProcessing
        //  source file path: c:\Users\username\Documents\Visual Studio 2012\Projects\CallerInfoCS\CallerInfoCS\Form1.cs
        //  source line number: 31
        //</Snippet51>

    }
}
