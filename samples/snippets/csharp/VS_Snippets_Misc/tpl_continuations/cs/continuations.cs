using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Child_Continuation
{
   class Program
   {
      static void Main(string[] args)
      {
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
      }

        static void MultiTaskContinuations()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            // UI thread. Hit the right key the first time.
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Press 'c' to cancel");
                if (Console.ReadKey().KeyChar == 'c')
                    cts.Cancel();
            });

            Task<int>[] tasks = new Task<int>[2];
            tasks[0] = new Task<int>(() =>
            {
                // Do some work... 
                return 34;
            });

            tasks[1] = new Task<int>(() =>
            {
                // Do some work...
                 return 8;
            });

            var continuation = Task.Factory.ContinueWhenAll(
                            tasks,
                            (antecedents) =>
                            {
                                int answer = antecedents[0].Result + antecedents[1].Result;
                                Console.WriteLine("The answer is {0}", answer);
                            });

            tasks[0].Start();
            tasks[1].Start();
            continuation.Wait();

            cts.Dispose();
        }
    }
}
