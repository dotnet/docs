// <Snippet1>
using System;
using System.IO;

public class FSSeek
{
    public static void Main()
    {
        long offset;
        int nextByte;

        // alphabet.txt contains "abcdefghijklmnopqrstuvwxyz"
        using (FileStream fs = new FileStream(@"c:\temp\alphabet.txt", FileMode.Open, FileAccess.Read))
        {
            for (offset = 1; offset <= fs.Length; offset++)
            {
                fs.Seek(-offset, SeekOrigin.End);
                Console.Write(Convert.ToChar(fs.ReadByte()));
            }
            Console.WriteLine();

            fs.Seek(20, SeekOrigin.Begin);

            while ((nextByte = fs.ReadByte()) > 0)
            {
                Console.Write(Convert.ToChar(nextByte));
            }
            Console.WriteLine();
        }
    }
}
// This code example displays the following output:
//
// zyxwvutsrqponmlkjihgfedcba
// uvwxyz
// </Snippet1>