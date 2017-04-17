//<Snippet1>
// Specify /d:TRACE when compiling.
 
using System;
using System.Diagnostics;

class Test
{
    static void Main()
    {
       Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
       Trace.AutoFlush = true;
       Trace.Indent();
       Trace.WriteLine("Entering Main");
       Console.WriteLine("Hello World.");
       Trace.WriteLine("Exiting Main"); 
       Trace.Unindent();
    }
}
//</Snippet1>
