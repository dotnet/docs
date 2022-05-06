//<snippet29>

public static partial class Program
{
    public static void HandleFour()
    {
        var task1 = Task.Run(() =>
        {
            throw new CustomException("This exception is expected!");
        });

        while (!task1.IsCompleted) { }

        if (task1.Status == TaskStatus.Faulted)
        {
            foreach (var e in task1.Exception.InnerExceptions)
            {
                // Handle the custom exception.
                if (e is CustomException)
                {
                    Console.WriteLine(e.Message);
                }
                // Rethrow any other exception.
                else
                {
                    throw e;
                }
            }
        }
    }
}
// The example displays the following output:
//        This exception is expected!
//</snippet29>
