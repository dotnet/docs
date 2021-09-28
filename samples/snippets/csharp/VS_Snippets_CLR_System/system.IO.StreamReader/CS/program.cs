// <Snippet30>
using System;
using System.IO;

class Test
{
    public static void Main()
    {
        string path = @"c:\temp\alphabet.txt";

        using (StreamReader sr = new StreamReader(path))
        {
            char[] c = null;

            c = new char[15];
            sr.Read(c, 0, c.Length);
            Console.WriteLine("first 15 characters:");
            Console.WriteLine(c);
            // writes - "abcdefghijklmno"

            sr.DiscardBufferedData();
            sr.BaseStream.Seek(2, SeekOrigin.Begin);
            Console.WriteLine("\nBack to offset 2 and read to end: ");
            Console.WriteLine(sr.ReadToEnd());
            // writes - "cdefghijklmnopqrstuvwxyz"
            // without DiscardBufferedData, writes - "pqrstuvwxyzcdefghijklmnopqrstuvwxyz"
        }
    }
}
// </Snippet30>
