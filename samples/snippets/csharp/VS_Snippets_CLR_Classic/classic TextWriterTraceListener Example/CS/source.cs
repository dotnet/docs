using System;
using System.IO;
using System.Diagnostics;

// <Snippet1>
public class Sample
{

public static int Main(string[] args) {
    // Create a file for output named TestFile.txt.
    Stream myFile = File.Create("TestFile.txt");
 
    /* Create a new text writer using the output stream, and add it to
     * the trace listeners. */
    TextWriterTraceListener myTextListener = new 
       TextWriterTraceListener(myFile);
    Trace.Listeners.Add(myTextListener);
 
    // Write output to the file.
    Trace.Write("Test output ");
 

    // Flush the output.
    Trace.Flush(); 

    return 0;
 }

}
// </Snippet1>
