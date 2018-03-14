//<Snippet1>
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        DirectoryInfo diTop = new DirectoryInfo(@"d:\");
        try
        {
            foreach (var fi in diTop.EnumerateFiles())
            {
                try
                {
                    // Display each file over 10 MB;
                    if (fi.Length > 10000000)
                    {
                        Console.WriteLine("{0}\t\t{1}", fi.FullName, fi.Length.ToString("N0"));
                    }
                }
                catch (UnauthorizedAccessException UnAuthTop)
                {
                    Console.WriteLine("{0}", UnAuthTop.Message);
                }
            }
            
            foreach (var di in diTop.EnumerateDirectories("*"))
            {
                try
                {
                    foreach (var fi in di.EnumerateFiles("*", SearchOption.AllDirectories))
                    {
                        try
                        {
                            // Display each file over 10 MB;
                            if (fi.Length > 10000000)
                            {
                                Console.WriteLine("{0}\t\t{1}",  fi.FullName, fi.Length.ToString("N0"));
                            }
                        }
                        catch (UnauthorizedAccessException UnAuthFile)
                        {
                            Console.WriteLine("UnAuthFile: {0}", UnAuthFile.Message);
                        }
                    }
                }
                catch (UnauthorizedAccessException UnAuthSubDir)
                {
                    Console.WriteLine("UnAuthSubDir: {0}", UnAuthSubDir.Message);
                }
            }
        }
        catch (DirectoryNotFoundException DirNotFound)
        {
            Console.WriteLine("{0}", DirNotFound.Message);
        }
        catch (UnauthorizedAccessException UnAuthDir)
        {
            Console.WriteLine("UnAuthDir: {0}", UnAuthDir.Message);
        }
        catch (PathTooLongException LongPath)
        {
            Console.WriteLine("{0}", LongPath.Message);
        }
    }
}
// </Snippet1>

