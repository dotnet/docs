// <Snippet7>

public static partial class Program
{
    public static void ExceptionPropagation()
    {
        var task1 =
            Task.Run(() =>
            {
                throw new CustomException("task1 faulted.");
            })
            .ContinueWith(t =>
            {
                Console.WriteLine("{0}: {1}",
                    t.Exception.InnerException.GetType().Name,
                    t.Exception.InnerException.Message);
            },
            TaskContinuationOptions.OnlyOnFaulted);

        Thread.Sleep(500);
    }
}
// The example displays output like the following:
//        CustomException: task1 faulted.
// </Snippet7>
