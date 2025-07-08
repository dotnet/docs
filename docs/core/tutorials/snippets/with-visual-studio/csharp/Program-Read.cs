//Variant of Program.cs that reads input from the debug console instead of the terminal
#if READ
// <MainMethod>
Console.WriteLine("What is your name?");
var name = Console.ReadLine();
var currentDate = DateTime.Now;
Console.WriteLine($"{Environment.NewLine}Hello, {name}, on {currentDate:d} at {currentDate:t}!");
Console.Write($"{Environment.NewLine}Press Enter to exit...");
Console.Read();
// </MainMethod>
#endif
