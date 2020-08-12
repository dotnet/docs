using System;
using System.Threading;
using System.Threading.Tasks;

public class UnwrapExample
{
    public static async Task Main()
    {
        Task<int> taskOne = RemoteIncrement(0);
        Console.WriteLine("Started RemoteIncrement(0)");

        Task<int> taskTwo = RemoteIncrement(4)
            .ContinueWith(t => RemoteIncrement(t.Result))
            .Unwrap().ContinueWith(t => RemoteIncrement(t.Result))
            .Unwrap().ContinueWith(t => RemoteIncrement(t.Result))
            .Unwrap();

        Console.WriteLine("Started RemoteIncrement(...(RemoteIncrement(RemoteIncrement(4))...)");

        try
        {
            await taskOne;
            Console.WriteLine("Finished RemoteIncrement(0)");

            await taskTwo;
            Console.WriteLine("Finished RemoteIncrement(...(RemoteIncrement(RemoteIncrement(4))...)");
        }
        catch (Exception e)
        {
            Console.WriteLine($"A task has thrown the following (unexpected) exception:\n{e}");
        }
    }

    static Task<int> RemoteIncrement(int number) =>
        Task<int>.Factory.StartNew(
            obj =>
            {
                Thread.Sleep(1000);

                int x = (int)obj;
                Console.WriteLine("Thread={0}, Next={1}", Thread.CurrentThread.ManagedThreadId, ++x);
                return x;
            },
            number);
}

// The example displays the similar output:
//     Started RemoteIncrement(0)
//     Started RemoteIncrement(...(RemoteIncrement(RemoteIncrement(4))...)
//     Thread=4, Next=1
//     Finished RemoteIncrement(0)
//     Thread=5, Next=5
//     Thread=6, Next=6
//     Thread=6, Next=7
//     Thread=6, Next=8
//     Finished RemoteIncrement(...(RemoteIncrement(RemoteIncrement(4))...)
