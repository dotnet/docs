using static System.Console;
using Fibonacci;

namespace ConsoleApplication
{
    public class Program
    {        
        public static void Main(string[] args)
        {
            var generator = new FibonacciGenerator();
            foreach (var digit in generator.Generate(15))
            {
                WriteLine(digit);
            }
        }
    }
}
