using System;
using System.Data;
using System.Diagnostics;

public class Class1
{
    public void Method()
    {
        // <Snippet1>
        /* Create a ConsoleTraceListener and add it to the trace listeners. */
        ConsoleTraceListener myWriter = new
           ConsoleTraceListener();
        Trace.Listeners.Add(myWriter);

        // </Snippet1>
    }
}

