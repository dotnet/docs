// <Snippet8>
using System;
using System.Text.RegularExpressions;

public class Example
{
    public static void Main()
    {
        string input = "equity queen equip acquaint quiet";
        string pattern = @"\Bqu\w+";
        foreach (Match match in Regex.Matches(input, pattern))
            Console.WriteLine($"'{match.Value}' found at position {match.Index}");
    }
}
// The example displays the following output:
//       'quity' found at position 1
//       'quip' found at position 14
//       'quaint' found at position 21
// </Snippet8>
