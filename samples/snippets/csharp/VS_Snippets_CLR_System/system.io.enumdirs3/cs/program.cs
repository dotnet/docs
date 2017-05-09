// <Snippet1>
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{

    private static void Main(string[] args)
    {
        try
        {
            string dirPath = @"\\archives\2009\reports";
            
            // LINQ query.
            var dirs = from dir in 
                     Directory.EnumerateDirectories(dirPath, "dv_*",
                     	SearchOption.AllDirectories)
                       select dir;

            // Show results.
            foreach (var dir in dirs)
            {
                // Remove path information from string.
                Console.WriteLine("{0}", 
                    dir.Substring(dir.LastIndexOf("\\") + 1));

            }
            Console.WriteLine("{0} directories found.", 
                dirs.Count<string>().ToString());

            // Optionally create a List collection.
            List<string> workDirs = new List<string>(dirs);
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
