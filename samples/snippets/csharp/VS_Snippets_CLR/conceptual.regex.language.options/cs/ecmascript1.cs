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
                Console.WriteLine("'{0}' matches the pattern.", value);
            else
                Console.WriteLine("{0} does not match the pattern.", value);

            Console.Write("ECMAScript matching: ");
            if (Regex.IsMatch(value, pattern, RegexOptions.ECMAScript))
                Console.WriteLine("'{0}' matches the pattern.", value);
            else
                Console.WriteLine("{0} does not match the pattern.", value);
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
