// <Snippet1>
using System;
using System.Linq;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // LINQ query for all .txt files containing the word 'Europe'.
            var files = from file in Directory.EnumerateFiles(@"\\archives1\library\", "*.txt")
                where file.ToLower().Contains("europe")
                select file;

            foreach (var file in files)
            {
                Console.WriteLine("{0}", file);
            }
            Console.WriteLine("{0} files found.", files.Count<string>().ToString());
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
