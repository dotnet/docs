using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class HelloWorld
    {
        public static void Main(string[] args)
        {
            // <MainMethod>
            Console.WriteLine($"{Environment.NewLine}What is your name? ");
            var name = Console.ReadLine();
            var date = DateTime.Now;
            Console.WriteLine($"{Environment.NewLine}Hello, {name}, on {date:d} at {date:t}!");
            Console.Write($"{Environment.NewLine}Press any key to exit...");
            Console.ReadKey(true);
            // </MainMethod>
        }
    }
}
