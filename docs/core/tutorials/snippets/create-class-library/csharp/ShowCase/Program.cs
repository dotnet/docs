using System;
using UtilityLibraries;

const int EntriesPerPage = 7;

int entryCount = 0;

ResetConsole();

while (true)
{
    string? input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
        break;

    if (entryCount >= EntriesPerPage)
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
        ResetConsole();
        entryCount = 0;
    }

    string result = input.StartsWithUpper() ? "Yes" : "No";

    Console.WriteLine($"Input: {input}");
    Console.WriteLine($"{"Begins with uppercase?",30}: {result}");
    Console.WriteLine();

    entryCount++;
}

return;

void ResetConsole()
{
    Console.Clear();
    Console.WriteLine();
    Console.WriteLine("Press <Enter> only to exit; otherwise, enter a string and press <Enter>:");
    Console.WriteLine();
}