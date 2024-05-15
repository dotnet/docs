using System;
using System.IO;

namespace Example;

public class ProcessFile
{
    public static void Main()
    {
        // <Snippet1>
        var fs = default(FileStream);
        try
        {
            // Open a text tile.
            fs = new FileStream(@"C:\temp\data.txt", FileMode.Open);
            var sr = new StreamReader(fs);

            // Read a value from the file and output to the console.
            string? line = sr.ReadLine();
            Console.WriteLine(line);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine($"[Data File Missing] {e}");
            throw new FileNotFoundException(@"[data.txt not in c:\temp directory]", e);
        }
        finally
        {
            fs?.Close();
        }
        // </Snippet1>
    }
}
