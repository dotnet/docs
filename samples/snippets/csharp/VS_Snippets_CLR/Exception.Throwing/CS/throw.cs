﻿// <Snippet1>
using System;
using System.IO;

public class ProcessFile
{
    public static void Main()
    {
        FileStream fs;
        try
        {
            // Opens a text tile.
            fs = new FileStream(@"C:\temp\data.txt", FileMode.Open);
            var sr = new StreamReader(fs);

            // A value is read from the file and output to the console.
            string line = sr.ReadLine();
            Console.WriteLine(line);
        }
        catch(FileNotFoundException e)
        {
            Console.WriteLine($"[Data File Missing] {e}");
            throw new FileNotFoundException(@"[data.txt not in c:\temp directory]", e);
        }
        finally
        {
            if (fs != null)
                fs.Close();
        }
    }
}
// </Snippet1>
