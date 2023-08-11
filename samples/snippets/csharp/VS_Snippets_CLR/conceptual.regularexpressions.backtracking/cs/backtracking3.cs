// <Snippet3>
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

public class Example
{
    public static void Main()
    {
        string pattern = "^(a+)+$";
        string[] inputs = { "aaaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaa!" };
        Regex rgx = new Regex(pattern);
        Stopwatch sw;

        foreach (string input in inputs)
        {
            sw = Stopwatch.StartNew();
            Match match = rgx.Match(input);
            sw.Stop();
            if (match.Success)
                Console.WriteLine($"Matched {match.Value} in {sw.Elapsed}");
            else
                Console.WriteLine($"No match found in {sw.Elapsed}");
        }
    }
}
//    Matched aaaaaaaaaaaaaaaaaaaaaaaaaaa in 00:00:00.0018281
//    No match found in 00:00:05.1882144
// </Snippet3>
