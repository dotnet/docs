// <Snippet22>

public static partial class Program
{
    public static void FlattenTwo()
    {
        var task = Task.Factory.StartNew(() =>
        {
            var child = Task.Factory.StartNew(() =>
            {
                var grandChild = Task.Factory.StartNew(() =>
                {
                    // This exception is nested inside three AggregateExceptions.
                    throw new CustomException("Attached child2 faulted.");
                }, TaskCreationOptions.AttachedToParent);

                // This exception is nested inside two AggregateExceptions.
                throw new CustomException("Attached child1 faulted.");
            }, TaskCreationOptions.AttachedToParent);
        });

        try
        {
            task.Wait();
        }
        catch (AggregateException ae)
        {
            foreach (var ex in ae.Flatten().InnerExceptions)
            {
                if (ex is CustomException)
                {
                    Console.WriteLine(ex.Message);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
// The example displays the following output:
//    Attached child1 faulted.
//    Attached child2 faulted.
// </Snippet22>
