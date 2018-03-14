// <snippet2>
using System;
using System.Diagnostics;

class TraceIntroExample
{
    public static void Main()
    {
        // <snippet3>
        Trace.WriteLine("Hello World!");
        Debug.WriteLine("Hello World!");
        // </snippet3>

       // <snippet4>
       bool errorFlag = false;
       Trace.WriteLine("Error in AppendData procedure.");
       Trace.WriteLineIf(errorFlag, "Error in AppendData procedure.");
       // </snippet4>
    }
}
// </snippet2>
