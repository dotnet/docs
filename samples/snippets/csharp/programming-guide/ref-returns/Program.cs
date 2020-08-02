namespace UseRefReturns
{
    using RefReturns;
    using RefReturnsVersionTwo;
    using static System.Console;

    public class Example
    {
        static void Main(string[] args)
        {
            FirstExample.Tests();
            WriteLine();
            SecondExample.Tests();
        }
    }
}
