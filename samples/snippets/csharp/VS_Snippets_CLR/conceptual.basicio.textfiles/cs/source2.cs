// <Snippet2>
using System;
using System.IO;

class DirAppend
{
    public static void Main()
    {
        using (StreamWriter w = File.AppendText("log.txt"))
        {
            Log("Test1", w);
            Log("Test2", w);
        }

        using (StreamReader r = File.OpenText("log.txt"))
        {
            DumpLog(r);
        }
    }

    public static void Log(string logMessage, TextWriter w)
    {
        w.Write("\r\nLog Entry : ");
        w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
        w.WriteLine("  :");
        w.WriteLine($"  :{logMessage}");
        w.WriteLine ("-------------------------------");
    }

    public static void DumpLog(StreamReader r)
    {
        string line;
        while ((line = r.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
    }
}
// The example creates a file named "log.txt" and writes the following lines to it,
// or appends them to the existing "log.txt" file:

// Log Entry : <current long time string> <current long date string>
//  :
//  :Test1
// -------------------------------

// Log Entry : <current long time string> <current long date string>
//  :
//  :Test2
// -------------------------------

// It then writes the contents of "log.txt" to the console.
// </Snippet2>
