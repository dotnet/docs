//<snippet06>
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ContinueWith
{
   class Continuations
   {
      static void Main()
      {
         SimpleContinuation();

         Console.WriteLine("Press any key to exit");
         Console.ReadKey();
      }

      static void SimpleContinuation()
      {
         string path = @"C:\users\public\TPLTestFolder\";
         try
         {
            var firstTask = new Task(() => CopyDataIntoTempFolder(path));
            var secondTask = firstTask.ContinueWith((t) => CreateSummaryFile(path));
            firstTask.Start();
         }
         catch (AggregateException e)
         {
            Console.WriteLine(e.Message);
         }
      }

      // A toy function to simulate a workload
      static void CopyDataIntoTempFolder(string path)
      {
         System.IO.Directory.CreateDirectory(path);
         Random rand = new Random();
         for (int x = 0; x < 50; x++)
         {
            byte[] bytes = new byte[1000];
            rand.NextBytes(bytes);
            string filename = Path.GetRandomFileName();
            string filepath = Path.Combine(path, filename);
            System.IO.File.WriteAllBytes(filepath, bytes);
         }
      }

      static void CreateSummaryFile(string path)
      {
         string[] files = System.IO.Directory.GetFiles(path);
         Parallel.ForEach(files, (file) =>
         {
            Thread.SpinWait(5000);
         });

         System.IO.File.WriteAllText(Path.Combine(path, "__SummaryFile.txt"), "did my work");
         Console.WriteLine("Done with task2");
      }

      static void SimpleContinuationWithState()
      {
         int[] nums = { 19, 17, 21, 4, 13, 8, 12, 7, 3, 5 };
         var f0 = new Task<double>(() => nums.Average());
         var f1 = f0.ContinueWith(t => GetStandardDeviation(nums, t.Result));

         f0.Start();
         Console.WriteLine("the standard deviation is {0}", f1.Result);
      }

      private static double GetStandardDeviation(int[] values, double mean)
      {
         double d = 0.0;
         foreach (var n in values)
         {
            d += Math.Pow(mean - n, 2);
         }
         return Math.Sqrt(d / (values.Length - 1));
      }
   }
}
//</snippet06>