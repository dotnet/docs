// <Snippet1>
#define TRACE

using System;
using System.IO;
using System.Diagnostics;

public class TextWriterTraceListenerSample
{
    public static void Main() 
    {
        TextWriterTraceListener myTextListener = null;

        // Create a file for output named TestFile.txt.
        String myFileName = "TestFile.txt";
        StreamWriter myOutputWriter = new StreamWriter(myFileName, true);

        // Add a TextWriterTraceListener for the file.
        myTextListener = new TextWriterTraceListener(myOutputWriter);
        Trace.Listeners.Add(myTextListener);
      
 
        // Write trace output to all trace listeners.
        Trace.WriteLine(DateTime.Now.ToString() + " - Trace output");
 
        // Remove and close the file writer/trace listener.
        myTextListener.Flush();
        Trace.Listeners.Remove(myTextListener);
        myTextListener.Close();
    }
}
// </Snippet1>
