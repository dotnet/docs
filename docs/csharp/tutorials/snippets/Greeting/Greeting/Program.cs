using Greeting.Contracts;
using Greeting.Models;

namespace Greeting;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter time: ");
        int hour = int.Parse(Console.ReadLine());

        IGreet greet = new Greeter();

        string greetingResult = greet.GetGreeting(hour);

        Console.WriteLine(greetingResult);
        Console.ReadKey();
    }
}

