// <Snippet16>

public static partial class Program
{
    public static void HandleMethodTwo()
    {
        var task1 = Task.Run(
            () => throw new CustomException("This exception is expected!"));

        try
        {
            task1.Wait();
        }
        catch (AggregateException ae)
        {
            // Call the Handle method to handle the custom exception,
            // otherwise rethrow the exception.
            ae.Handle(ex =>
            {
                if (ex is CustomException)
                {
                    Console.WriteLine(ex.Message);
                }
                return ex is CustomException;
            });
        }
    }
}
// The example displays the following output:
//        This exception is expected!
// </Snippet16>
