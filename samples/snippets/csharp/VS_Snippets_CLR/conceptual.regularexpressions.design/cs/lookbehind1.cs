// <Snippet5>
using System;
using System.Text.RegularExpressions;

public class Example
{
    public static void Main()
    {
        string[] inputs = { "jack.sprat", "dog#", "dog#1", "me.myself",
                          "me.myself!" };
        string pattern = @"^[A-Z0-9]([-!#$%&'.*+/=?^`{}|~\w])*(?<=[A-Z0-9])$";
        foreach (string input in inputs)
        {
            if (Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase))
                Console.WriteLine($"{input}: Valid");
            else
                Console.WriteLine($"{input}: Invalid");
        }
    }
}
// The example displays the following output:
//       jack.sprat: Valid
//       dog#: Invalid
//       dog#1: Valid
//       me.myself: Valid
//       me.myself!: Invalid
// </Snippet5>
