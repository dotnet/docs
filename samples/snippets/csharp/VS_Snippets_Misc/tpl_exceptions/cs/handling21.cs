//<snippet21>

public static partial class Program
{
    public static void HandleThree()
    {
        var task1 = Task.Run(() =>
        {
            throw new CustomException("This exception is expected!");
        });

        try
        {
            task1.Wait();
        }
        catch (AggregateException ae)
        {
            foreach (var ex in ae.InnerExceptions)
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
//</snippet21>
