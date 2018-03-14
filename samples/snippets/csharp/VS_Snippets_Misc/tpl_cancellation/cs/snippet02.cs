//<snippet02>
using System;
using System.Threading;
using System.Threading.Tasks;
class Program
{
    static void Main()
    {
        var tokenSource2 = new CancellationTokenSource();
        CancellationToken ct = tokenSource2.Token;

        var task = Task.Factory.StartNew(() =>
        {

            // Were we already canceled?
            ct.ThrowIfCancellationRequested();

            bool moreToDo = true;
            while (moreToDo)
            {
                // Poll on this property if you have to do
                // other cleanup before throwing.
                if (ct.IsCancellationRequested)
                {
                    // Clean up here, then...
                    ct.ThrowIfCancellationRequested();
                }

            }
        }, tokenSource2.Token); // Pass same token to StartNew.

        tokenSource2.Cancel();

        // Just continue on this thread, or Wait/WaitAll with try-catch:
        try
        {
            task.Wait();
        }
        catch (AggregateException e)
        {
            foreach (var v in e.InnerExceptions)
                Console.WriteLine(e.Message + " " + v.Message);
        }
        finally
        {
            tokenSource2.Dispose();
        }

        Console.ReadKey();
    }
}
//</snippet02>