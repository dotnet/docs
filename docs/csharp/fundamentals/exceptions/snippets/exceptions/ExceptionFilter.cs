namespace Exceptions;

    // <ShowExceptionFilter>
public class ExceptionFilter
{
    public static void Main()
    {
        try
        {
            string? s = null;
            Console.WriteLine(s.Length);
        }
        catch (Exception e) when (LogException(e))
        {
        }
        Console.WriteLine("Exception must have been handled");
    }

    private static bool LogException(Exception e)
    {
        Console.WriteLine($"\tIn the log routine. Caught {e.GetType()}");
        Console.WriteLine($"\tMessage: {e.Message}");
        return false;
    }
}
// </ShowExceptionFilter>

public class ExceptionFilter2
{
    // <DemonstrateExceptionFilter>
    int GetInt(int[] array, int index)
    {
        try
        {
            return array[index];
        }
        catch (IndexOutOfRangeException e) when (index < 0) 
        {
            throw new ArgumentOutOfRangeException(
                "Parameter index cannot be negative.", e);
        }
        catch (IndexOutOfRangeException e)
        {
            throw new ArgumentOutOfRangeException(
                "Parameter index cannot be greater than the array size.", e);
        }
    }
    // </DemonstrateExceptionFilter>
}
