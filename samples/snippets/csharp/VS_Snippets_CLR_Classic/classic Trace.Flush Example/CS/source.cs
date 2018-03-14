// <Snippet1>
// Specify /d:TRACE when compiling.

using System;
using System.IO;
using System.Diagnostics;

class Test
{
    static void Main()
    {
        // Create a file for output named TestFile.txt.
        using (FileStream myFileStream = 
            new FileStream("TestFile.txt", FileMode.Append))
        {
            // Create a new text writer using the output stream 
            // and add it to the trace listeners.
            TextWriterTraceListener myTextListener = 
                new TextWriterTraceListener(myFileStream);
            Trace.Listeners.Add(myTextListener);
          
            // Write output to the file.
            Trace.WriteLine("Test output");
         
            // Flush and close the output stream.
            Trace.Flush();
            Trace.Close();
        }
    }
}
// </Snippet1>
