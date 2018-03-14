// <Snippet1>
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var files = from file in Directory.EnumerateFiles(@"c:\", "*.txt", SearchOption.AllDirectories)
                        from line in File.ReadLines(file)
                        where line.Contains("Microsoft")
                        select new
                        {
                            File = file,
                            Line = line
                        };

            foreach (var f in files)
            {
                Console.WriteLine("{0}\t{1}", f.File, f.Line);
            }
			Console.WriteLine("{0} files found.", files.Count().ToString());
        }
        catch (UnauthorizedAccessException UAEx)
        {
            Console.WriteLine(UAEx.Message);
        }
        catch (PathTooLongException PathEx)
        {
            Console.WriteLine(PathEx.Message);
        }
    }
}
// </Snippet1>