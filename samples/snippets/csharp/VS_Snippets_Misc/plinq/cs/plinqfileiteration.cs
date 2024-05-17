using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

class ExampleWithFiles
{
    static void Main()
    {
        // Supply a tree for which you have at least read permissions.
        string path = @"C:\Program Files";

        FileIterationOne(path);
        FileIterationTwo(path);

        Console.ReadKey();
    }

    //<snippet33>

    // Use Directory.GetFiles to get the source sequence of file names.
    public static void FileIterationOne(string path)
    {
        var sw = Stopwatch.StartNew();
        int count = 0;
        string[]? files = null;
        try
        {
            files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You do not have permission to access one or more folders in this directory tree.");
            return;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"The specified directory {path} was not found.");
        }

        var fileContents =
            from FileName in files?.AsParallel()
            let extension = Path.GetExtension(FileName)
            where extension == ".txt" || extension == ".htm"
            let Text = File.ReadAllText(FileName)
            select new
            {
                Text,
                FileName
            };

        try
        {
            foreach (var item in fileContents)
            {
                Console.WriteLine($"{Path.GetFileName(item.FileName)}:{item.Text.Length}");
                count++;
            }
        }
        catch (AggregateException ae)
        {
            ae.Handle(ex =>
            {
                if (ex is UnauthorizedAccessException uae)
                {
                    Console.WriteLine(uae.Message);
                    return true;
                }
                return false;
            });
        }

        Console.WriteLine($"FileIterationOne processed {count} files in {sw.ElapsedMilliseconds} milliseconds");
    }
    //</snippet33>

    //<snippet34>
    public static void FileIterationTwo(string path) //225512 ms
    {
        var count = 0;
        var sw = Stopwatch.StartNew();
        var fileNames =
            from dir in Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories)
            select dir;

        var fileContents =
            from FileName in fileNames.AsParallel()
            let extension = Path.GetExtension(FileName)
            where extension == ".txt" || extension == ".htm"
            let Text = File.ReadAllText(FileName)
            select new
            {
                Text,
                FileName
            };
        try
        {
            foreach (var item in fileContents)
            {
                Console.WriteLine($"{Path.GetFileName(item.FileName)}:{item.Text.Length}");
                count++;
            }
        }
        catch (AggregateException ae)
        {
            ae.Handle(ex =>
            {
                if (ex is UnauthorizedAccessException uae)
                {
                    Console.WriteLine(uae.Message);
                    return true;
                }
                return false;
            });
        }

        Console.WriteLine($"FileIterationTwo processed {count} files in {sw.ElapsedMilliseconds} milliseconds");
    }
    //</snippet34>
}
