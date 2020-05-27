// <Snippet3>
using System;
using System.IO;

class Example
{
    static void Main()
    {
        char[] buffer = new char[50];
        var streamReader = new StreamReader("file1.txt");
        try
        {
            int charsRead = 0;
            while (streamReader.Peek() != -1)
            {
                charsRead = streamReader.Read(buffer, 0, buffer.Length);
                //
                // Process characters read.
                //
            }
        }
        finally
        {
            if (streamReader != null)
            {
                ((IDisposable)streamReader).Dispose();
            }
        }
    }
}
// </Snippet3>
