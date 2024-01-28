internal class Program
{
    private static void Main(string[] args)
    {
        // <MainMethod>
        Console.WriteLine("What is your name?");
        var name = Console.ReadLine();
        var currentDate = DateTime.Now;
        Console.WriteLine($"{Environment.NewLine}Hello, {name}, on {currentDate:d} at {currentDate:t}!");
        Console.Write($"{Environment.NewLine}Press Enter to exit...");
        Console.ReadLine();
        // </MainMethod>
    }
}
