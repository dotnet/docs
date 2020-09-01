using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

class CancelWithCallback
{
    static void Main()
    {
        using var cts = new CancellationTokenSource();
        var token = cts.Token;

        _ = Task.Run(async () =>
        {
            using var client = new WebClient();

            client.DownloadStringCompleted += (_, args) =>
            {
                if (args.Cancelled)
                {
                    Console.WriteLine("The download was canceled.");
                }
                else
                {
                    Console.WriteLine("The download has completed:\n");
                    Console.WriteLine($"{args.Result}\n\nPress any key to continue.");
                }
            };

            if (!token.IsCancellationRequested)
            {
                using CancellationTokenRegistration ctr = token.Register(() => client.CancelAsync());

                Console.WriteLine("Starting request\n");
                await client.DownloadStringTaskAsync(new Uri("http://www.contoso.com"));
            }
        }, token);

        Console.WriteLine("Press 'c' to cancel.\n\n");
        if (Console.ReadKey().KeyChar == 'c')
        {
            cts.Cancel();
        }

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }
}