//<snippet02>
using System;
using System.Threading;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        var tokenSource = new CancellationTokenSource();
        CancellationToken cancellationToken = tokenSource.Token;

        var task = Task.Factory.StartNew(() =>
        {

            // Were we already canceled?
            cancellationToken.ThrowIfCancellationRequested();

            bool moreToDo = true;
            while (moreToDo)
            {
                // Poll on this property if you have to do
                // other cleanup before throwing.
                if (cancellationToken.IsCancellationRequested)
                {
                    // Clean up here, then...
                    cancellationToken.ThrowIfCancellationRequested();
                }

            }
        }, tokenSource.Token); // Pass same token to StartNew.

        tokenSource.Cancel();

        // Just continue on this thread, or Wait/WaitAll with try-catch:
        try
        {
            task.Wait();
        }
        catch (AggregateException exception)
        {
            foreach (var innerException in exception.InnerExceptions)
            {
                Console.WriteLine(exception.Message + " " + innerException.Message);
            }
        }
        finally
        {
            tokenSource.Dispose();
        }

        Console.ReadKey();
    }
}
//</snippet02>
