// <Snippet5>
using System;
using System.Text.RegularExpressions;

public class SingleLineExample
{
    public static void Main()
    {
        string pattern = "(?s)^.+";
        string input = "This is one line and" + Environment.NewLine + "this is the second.";

        foreach (Match match in Regex.Matches(input, pattern))
            Console.WriteLine(Regex.Escape(match.Value));
    }
}
// The example displays the following output:
//       This\ is\ one\ line\ and\r\nthis\ is\ the\ second\.
// </Snippet5>
