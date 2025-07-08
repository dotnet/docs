// <Snippet16>
using System;
using System.Text.RegularExpressions;

public class EcmaScriptExample
{
    public static void Main()
    {
        string[] values = { "целый мир", "the whole world" };
        string pattern = @"\b(\w+\s*)+";
        foreach (var value in values)
        {
            Console.Write("Canonical matching: ");
            if (Regex.IsMatch(value, pattern))
                Console.WriteLine($"'{value}' matches the pattern.");
            else
                Console.WriteLine($"{value} does not match the pattern.");

            Console.Write("ECMAScript matching: ");
            if (Regex.IsMatch(value, pattern, RegexOptions.ECMAScript))
                Console.WriteLine($"'{value}' matches the pattern.");
            else
                Console.WriteLine($"{value} does not match the pattern.");
            Console.WriteLine();
        }
    }
}
// The example displays the following output:
//       Canonical matching: 'целый мир' matches the pattern.
//       ECMAScript matching: целый мир does not match the pattern.
//
//       Canonical matching: 'the whole world' matches the pattern.
//       ECMAScript matching: 'the whole world' matches the pattern.
// </Snippet16>
