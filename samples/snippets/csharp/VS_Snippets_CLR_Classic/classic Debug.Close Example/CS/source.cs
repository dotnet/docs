// <Snippet1>
// Specify /d:DEBUG when compiling.

using System;
using System.IO;
using System.Diagnostics;

class Test
{
    static void Main()
    {
        // Create a new stream object for an output file named TestFile.txt.
        using (FileStream myFileStream = 
            new FileStream("TestFile.txt", FileMode.Append))
        {
            // Add the stream object to the trace listeners.
            TextWriterTraceListener myTextListener = 
                new TextWriterTraceListener(myFileStream);
            Debug.Listeners.Add(myTextListener);
          
            // Write output to the file.
            Debug.WriteLine("Test output");
         
            // Flush and close the output stream.
            Debug.Flush();
            Debug.Close();
        }
    }
}
// </Snippet1>
