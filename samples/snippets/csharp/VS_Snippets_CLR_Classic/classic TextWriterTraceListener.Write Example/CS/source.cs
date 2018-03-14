using System;
using System.Diagnostics;

// <Snippet1>
public class Sample 
{

 void Main(string[] args) {
    /* Create a text writer that writes to the console screen and add
     * it to the trace listeners */
    TextWriterTraceListener myWriter = new TextWriterTraceListener();
    myWriter.Writer = System.Console.Out;
    Trace.Listeners.Add(myWriter);
 
    // Write the output to the console screen.
    myWriter.Write("Write to console screen. ");
    myWriter.WriteLine("Again, write to the Console screen.");
 
    // Flush and close the output.
    myWriter.Flush();
    myWriter.Close();
 }

}
// </Snippet1>
