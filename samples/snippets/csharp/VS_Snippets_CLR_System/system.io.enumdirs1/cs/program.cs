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

            List<string> dirs = new List<string>(Directory.EnumerateDirectories(dirPath));
                    
            foreach (var dir in dirs)
            {
                Console.WriteLine("{0}", dir.Substring(dir.LastIndexOf("\\") + 1));
            }
            Console.WriteLine("{0} directories found.",  dirs.Count);
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


