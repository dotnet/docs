//<snippet29>

public static partial class Program
{
    public static void HandleFour()
    {
        var task = Task.Run(
            () => throw new CustomException("This exception is expected!"));

        while (!task.IsCompleted) { }

        if (task.Status == TaskStatus.Faulted)
        {
            foreach (var ex in task.Exception?.InnerExceptions ?? new(Array.Empty<Exception>()))
            {
                // Handle the custom exception.
                if (ex is CustomException)
                {
                    Console.WriteLine(ex.Message);
                }
                // Rethrow any other exception.
                else
                {
                    throw ex;
                }
            }
        }
    }
}
// The example displays the following output:
//        This exception is expected!
//</snippet29>
