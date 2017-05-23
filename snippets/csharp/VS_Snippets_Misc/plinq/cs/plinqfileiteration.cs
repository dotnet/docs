using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

class PLINQ_Files
{

    static void Main()
    {
        // Supply a tree for which you have at least read permissions.
        string path = @"c:\Program Files";

        
        FileIteration_1(path);
        FileIteration_2(path);

        Console.ReadKey();
    }

    //<snippet33>

    struct FileResult
    {
        public string Text;
        public string FileName;
    }
    // Use Directory.GetFiles to get the source sequence of file names.
    public static void FileIteration_1(string path)
    {       
        var sw = Stopwatch.StartNew();
        int count = 0;
        string[] files = null;
        try
        {
            files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine("You do not have permission to access one or more folders in this directory tree.");
            return;
        }

        catch (FileNotFoundException)
        {
            Console.WriteLine("The specified directory {0} was not found.", path);
        }

        var fileContents = from file in files.AsParallel()
                let extension = Path.GetExtension(file)
                where extension == ".txt" || extension == ".htm"
                let text = File.ReadAllText(file)
                select new FileResult { Text = text , FileName = file }; //Or ReadAllBytes, ReadAllLines, etc.              

        try
        {
            foreach (var item in fileContents)
            {
                Console.WriteLine(Path.GetFileName(item.FileName) + ":" + item.Text.Length);
                count++;
            }
        }
        catch (AggregateException ae)
        {
            ae.Handle((ex) =>
                {
                    if (ex is UnauthorizedAccessException)
                    {
                       Console.WriteLine(ex.Message);
                       return true;
                    }
                    return false;
                });
        }
       
        Console.WriteLine("FileIteration_1 processed {0} files in {1} milliseconds", count, sw.ElapsedMilliseconds);
        }
    //</snippet33>
        //q.ForAll((s) =>
        //    { 

        //        // ...Do work here.

        //        // Perform some minimal progress updates.
        //        if (c % 100 == 0)
        //        {
        //            // Locking is necessary to so that all writes
        //            // start at 0,0.
        //            lock(_lock)
        //            {
        //            Console.CursorLeft = 0;
        //            Console.CursorTop = 0;
        //            Console.Write(c + ":" + sw.ElapsedMilliseconds);
        //            }

        //        }
        //        Interlocked.Increment(ref c);

        //    });
       
  //<snippet34>

    struct FileResult
    {
        public string Text;
        public string FileName;
    }

    // Use Directory.EnumerateDirectories and EnumerateFiles to get the source sequence of file names.
    public static void FileIteration_2(string path) //225512 ms
    {
        var count = 0;
        var sw = Stopwatch.StartNew();
        var fileNames = from dir in Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories)
                        select dir;
      

        var fileContents = from file in fileNames.AsParallel() // Use AsOrdered to preserve source ordering
                           let extension = Path.GetExtension(file)
                           where extension == ".txt" || extension == ".htm"
                           let Text = File.ReadAllText(file)
                           select new { Text, FileName = file }; //Or ReadAllBytes, ReadAllLines, etc.
        try
        {
            foreach (var item in fileContents)
            {
                Console.WriteLine(Path.GetFileName(item.FileName) + ":" + item.Text.Length);
                count++;
            }
        }
        catch (AggregateException ae)
        {
            ae.Handle((ex) =>
                {
                    if (ex is UnauthorizedAccessException)
                    {
                       Console.WriteLine(ex.Message);
                       return true;
                    }
                    return false;
                });
        }

        Console.WriteLine("FileIteration_2 processed {0} files in {1} milliseconds", count, sw.ElapsedMilliseconds);
    }
    //</snippet34>
}
