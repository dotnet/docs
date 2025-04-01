//<snippet04>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class ThreadLocalForWithOptions
{
   // The number of parallel iterations to perform.
   const int N = 1000000;

   static void Main()
   {
      // The result of all thread-local computations.
      int result = 0;

      // This example limits the degree of parallelism to four.
      // You might limit the degree of parallelism when your algorithm
      // does not scale beyond a certain number of cores or when you
      // enforce a particular quality of service in your application.

      Parallel.For(0, N, new ParallelOptions { MaxDegreeOfParallelism = 4 },
         // Initialize the local states
         () => 0,
         // Accumulate the thread-local computations in the loop body
         (i, loop, localState) =>
         {
            return localState + Compute(i);
         },
         // Combine all local states
         localState => Interlocked.Add(ref result, localState)
      );

      // Print the actual and expected results.
      Console.WriteLine($"Actual result: {result}. Expected 1000000.");
   }

   // Simulates a lengthy operation.
   private static int Compute(int n)
   {
      for (int i = 0; i < 10000; i++) ;
      return 1;
   }
}
//</snippet04>