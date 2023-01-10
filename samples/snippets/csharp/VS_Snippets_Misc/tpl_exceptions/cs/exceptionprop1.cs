// <Snippet7>

public static partial class Program
{
    public static void ExceptionPropagation()
    {
        _ = Task.Run(
            () => throw new CustomException("task1 faulted."))
            .ContinueWith(_ =>
            {
                if (_.Exception?.InnerException is { } inner)
                {
                    Console.WriteLine("{0}: {1}",
                        inner.GetType().Name,
                        inner.Message);
                }
            },
            TaskContinuationOptions.OnlyOnFaulted);

        Thread.Sleep(500);
    }
}
// The example displays output like the following:
//        CustomException: task1 faulted.
// </Snippet7>
