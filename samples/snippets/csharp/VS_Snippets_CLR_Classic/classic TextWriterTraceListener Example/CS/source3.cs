// <snippet6>
using System;
using System.Diagnostics;

class OverviewTraceListener
{
    public static void Main()
    {
        // <snippet7>
        // Use this example when debugging.
        Debug.WriteLine("Error in Widget 42");
        // Use this example when tracing.
        Trace.WriteLine("Error in Widget 42");
        // </snippet7>

        // <snippet8>
        Trace.Listeners.Clear();
        Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
        // </snippet8>
    }
}
// </snippet6>
