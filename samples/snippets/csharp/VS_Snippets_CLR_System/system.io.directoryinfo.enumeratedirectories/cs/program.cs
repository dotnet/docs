//<Snippet1>
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Set a variable to the My Documents path.
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        DirectoryInfo diTop = new DirectoryInfo(docPath);

        try
        {
            foreach (var fi in diTop.EnumerateFiles())
            {
                try
                {
                    // Display each file over 10 MB;
                    if (fi.Length > 10000000)
                    {
                        Console.WriteLine($"{fi.FullName}\t\t{fi.Length.ToString("NO")}");
                    }
                }
                catch (UnauthorizedAccessException unAuthTop)
                {
                    Console.WriteLine($"{unAuthTop.Message}");
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
                                Console.WriteLine($"{fi.FullName}\t\t{fi.Length.ToString("NO")}");
                            }
                        }
                        catch (UnauthorizedAccessException unAuthFile)
                        {
                            Console.WriteLine($"unAuthFile: {unAuthFile.Message}");
                        }
                    }
                }
                catch (UnauthorizedAccessException unAuthSubDir)
                {
                    Console.WriteLine($"unAuthSubDir: {unAuthSubDir.Message}");
                }
            }
        }
        catch (DirectoryNotFoundException dirNotFound)
        {
            Console.WriteLine($"{dirNotFound.Message}");
        }
        catch (UnauthorizedAccessException unAuthDir)
        {
            Console.WriteLine($"unAuthDir: {unAuthDir.Message}");
        }
        catch (PathTooLongException longPath)
        {
            Console.WriteLine($"{longPath.Message}");
        }
    }
}
// </Snippet1>
