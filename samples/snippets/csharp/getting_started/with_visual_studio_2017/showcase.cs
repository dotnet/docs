using System;
using UtilityLibraries;

class Program
{
    static void Main(string[] args)
    {
        int rows = Console.WindowHeight;
 
        Console.Clear();
        do
        {
            if (Console.CursorTop >= rows || Console.CursorTop == 0)
            {
                Console.Clear();
                Console.WriteLine("\nPress <Enter> only to exit; otherwise, enter a string and press <Enter>:\n");
            }
            string input = Console.ReadLine();
            if (String.IsNullOrEmpty(input)) break;
            Console.WriteLine($"Input: {input} {"Begins with uppercase? ",30}: " +
                              $"{(input.StartsWithUpper() ? "Yes" : "No")}\n");
        } while (true);
    }
}

