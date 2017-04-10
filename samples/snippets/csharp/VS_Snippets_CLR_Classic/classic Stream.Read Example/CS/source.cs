// <Snippet1>
using System;
using System.IO;

public class Block
{
    public static void Main()
    {
        Stream s = new MemoryStream();
        for (int i = 0; i < 122; i++)
        {
            s.WriteByte((byte)i);
        }
        s.Position = 0;

        // Now read s into a byte buffer with a little padding.
        byte[] bytes = new byte[s.Length + 10];
        int numBytesToRead = (int)s.Length;
        int numBytesRead = 0;
        do
        {
            // Read may return anything from 0 to 10.
            int n = s.Read(bytes, numBytesRead, 10);
            numBytesRead += n;
            numBytesToRead -= n;
        } while (numBytesToRead > 0);
        s.Close();
       
        Console.WriteLine("number of bytes read: {0:d}", numBytesRead);
    }
}
// </Snippet1>