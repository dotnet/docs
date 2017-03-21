using System;
using System.Text;

public sealed class App 
{
    static void Main() 
    {
        // Create a StringBuilder that expects to hold 50 characters.
        // Initialize the StringBuilder with "ABC".
        StringBuilder sb = new StringBuilder("ABC", 50);

        // Append three characters (D, E, and F) to the end of the StringBuilder.
        sb.Append(new char[] { 'D', 'E', 'F' });

        // Append a format string to the end of the StringBuilder.
        sb.AppendFormat("GHI{0}{1}", 'J', 'k');

        // Display the number of characters in the StringBuilder and its string.
        Console.WriteLine("{0} chars: {1}", sb.Length, sb.ToString());

        // Insert a string at the beginning of the StringBuilder.
        sb.Insert(0, "Alphabet: ");

        // Replace all lowercase k's with uppercase K's.
        sb.Replace('k', 'K');

        // Display the number of characters in the StringBuilder and its string.
        Console.WriteLine("{0} chars: {1}", sb.Length, sb.ToString());
    }
}

// This code produces the following output.
//
// 11 chars: ABCDEFGHIJk
// 21 chars: Alphabet: ABCDEFGHIJK