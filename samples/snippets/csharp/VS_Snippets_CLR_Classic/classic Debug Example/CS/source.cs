// <Snippet1>
// Specify /d:DEBUG when compiling.

using System;
using System.Data;
using System.Diagnostics;

class Test
{
    static void Main()
    {
       Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
       Debug.AutoFlush = true;
       Debug.Indent();
       Debug.WriteLine("Entering Main");
       Console.WriteLine("Hello World.");
       Debug.WriteLine("Exiting Main"); 
       Debug.Unindent();
    }
}
// </Snippet1>

