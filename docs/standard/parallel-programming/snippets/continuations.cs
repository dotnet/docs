using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContinuationExample
{
    class Program
    {
        static async Task Main()
        {
            using var cts = new CancellationTokenSource();

            // UI thread. Hit the right key the first time.
            _ = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Press 'c' to cancel");
                if (Console.ReadKey().KeyChar == 'c')
                {
                    cts.Cancel();
                }
            });

            var tasks = new Task<int>[]
            {
                new Task<int>(() => 34),
                new Task<int>(() => 8)
            };

            Task continuation =
                Task.Factory.ContinueWhenAll(
                    tasks,
                    antecedents =>
                    {
                        int answer = antecedents[0].Result + antecedents[1].Result;
                        Console.WriteLine($"The answer is {answer}");
                    });

            tasks[0].Start();
            tasks[1].Start();

            await continuation;

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}