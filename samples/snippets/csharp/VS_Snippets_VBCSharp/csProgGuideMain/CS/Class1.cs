namespace CsCsrefProgrammingMain
{

    //<Snippet16>
    // Add a using directive for System if the directive isn't already present.

    public class Functions
    {
        public static long Factorial(int n)
        {
            // Test for invalid input.
            if ((n < 0) || (n > 20))
            {
                return -1;
            }

            // Calculate the factorial iteratively rather than recursively.
            long tempResult = 1;
            for (int i = 1; i <= n; i++)
            {
                tempResult *= i;
            }
            return tempResult;
        }
    }

    class MainClass
    {
        static int Main(string[] args)
        {
            // Test if input arguments were supplied.
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a numeric argument.");
                Console.WriteLine("Usage: Factorial <num>");
                return 1;
            }

            // Try to convert the input arguments to numbers. This will throw
            // an exception if the argument is not a number.
            // num = int.Parse(args[0]);
            int num;
            bool test = int.TryParse(args[0], out num);
            if (!test)
            {
                Console.WriteLine("Please enter a numeric argument.");
                Console.WriteLine("Usage: Factorial <num>");
                return 1;
            }

            // Calculate factorial.
            long result = Functions.Factorial(num);

            // Print result.
            if (result == -1)
                Console.WriteLine("Input must be >= 0 and <= 20.");
            else
                Console.WriteLine($"The Factorial of {num} is {result}.");

            return 0;
        }
    }
    // If 3 is entered on command line, the
    // output reads: The factorial of 3 is 6.
    //</Snippet16>

    //<Snippet9>
    class CommandLine
    {
        static void Main(string[] args)
        {
            // The Length property provides the number of array elements.
            Console.WriteLine($"parameter count = {args.Length}");

            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine($"Arg[{i}] = [{args[i]}]");
            }
        }
    }
    /* Output (assumes 3 cmd line args):
        parameter count = 3
        Arg[0] = [a]
        Arg[1] = [b]
        Arg[2] = [c]
    */
    //</Snippet9>

    //<Snippet17>
    class TestClass
    {
        static void Main(string[] args)
        {
            // Display the number of command line arguments.
            Console.WriteLine(args.Length);
        }
    }
    //</Snippet17>
}
