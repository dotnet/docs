// <Snippet27>

public static partial class Program
{
    public static void ExceptionPropagationTwo()
    {
        _ = Task.Run(
            () => throw new CustomException("task1 faulted."))
            .ContinueWith(_ =>
            {
                if (_.Exception?.InnerException is { } inner)
                {
                    Console.WriteLine($"{inner.GetType().Name}: {inner.Message}");
                }
            }, 
            TaskContinuationOptions.OnlyOnFaulted);
        
        Thread.Sleep(500);
    }
}
// The example displays output like the following:
//        CustomException: task1 faulted.
// </Snippet27>
