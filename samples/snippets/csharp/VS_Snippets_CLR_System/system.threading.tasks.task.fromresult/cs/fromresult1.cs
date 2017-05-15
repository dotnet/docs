// <Snippet1>
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      string[] args = Environment.GetCommandLineArgs();
      if (args.Length > 1) {
         List<Task<long>> tasks = new List<Task<long>>();
         for (int ctr = 1; ctr < args.Length; ctr++)
            tasks.Add(GetFileLengthsAsync(args[ctr]));

         try {
            Task.WaitAll(tasks.ToArray());
         }
         // Ignore exceptions here.
         catch (AggregateException) {}

         for (int ctr = 0 ; ctr < tasks.Count; ctr++) {
            if (tasks[ctr].Status == TaskStatus.Faulted)
               Console.WriteLine("{0} does not exist", args[ctr + 1]);
            else
               Console.WriteLine("{0:N0} bytes in files in '{1}'",
                                 tasks[ctr].Result, args[ctr + 1]);
         }
      }
      else {
         Console.WriteLine("Syntax error: Include one or more file paths.");
      }
   }

   private static Task<long> GetFileLengthsAsync(string filePath)
   {
      if (! Directory.Exists(filePath)) {
         return Task.FromException<long>(
                     new DirectoryNotFoundException("Invalid directory name."));
      }
      else {
         string[] files = Directory.GetFiles(filePath);
         if (files.Length == 0)
            return Task.FromResult(0L);
         else
            return Task.Run( () => { long total = 0;
                                     Parallel.ForEach(files, (fileName) => {
                                                 var fs = new FileStream(fileName, FileMode.Open,
                                                                         FileAccess.Read, FileShare.ReadWrite,
                                                                         256, true);
                                                 long length = fs.Length;
                                                 Interlocked.Add(ref total, length);
                                                 fs.Close(); } );
                                     return total;
                                   } );
      }
   }
}
// When launched with the following command line arguments:
//      subdir . newsubdir
// the example displays output like the following:
//       0 bytes in files in 'subdir'
//       2,059 bytes in files in '.'
//       newsubdir does not exist
// </Snippet1>
