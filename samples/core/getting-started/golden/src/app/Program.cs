using static System.Console;
using Library;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WriteLine($"The answer is {new Thing().Get(19, 23)}");
        }
    }
}
