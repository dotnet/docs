// <Snippet23>

public static partial class Program
{
    public static void DetachedTwo()
    {
        var task1 = Task.Run(() =>
        {
            var nested1 = Task.Run(() =>
            {
                throw new CustomException("Detached child task faulted.");
            });

            // Here the exception will be escalated back to the calling thread.
            // We could use try/catch here to prevent that.
            nested1.Wait();
        });

        try
        {
            task1.Wait();
        }
        catch (AggregateException ae)
        {
            foreach (var e in ae.Flatten().InnerExceptions)
            {
                if (e is CustomException)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
// The example displays the following output:
//    Detached child task faulted.
// </snippet23>
