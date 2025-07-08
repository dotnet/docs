//<snippet3>
class ArgumentOutOfRangeExample
{
    public static void Main()
    {
        int[] array1 = {0, 0};
        int[] array2 = {0, 0};

        try
        {
            Array.Copy(array1, array2, -1);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine($"Error: {e}");
            throw;
        }
        finally
        {
            Console.WriteLine("This statement is always executed.");
        }
    }
}
//</snippet3>
