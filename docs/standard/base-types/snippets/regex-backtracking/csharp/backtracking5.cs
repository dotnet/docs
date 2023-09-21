// <Snippet5>
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

public class Example5
{
    public static void Run()
    {
        Stopwatch sw;
        string input = "test@contoso.com";
        bool result;

        string pattern = @"^[0-9A-Z]([-.\w]*[0-9A-Z])?@";
        sw = Stopwatch.StartNew();
        result = Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
        sw.Stop();
        Console.WriteLine("Match: {0} in {1}", result, sw.Elapsed);

        string behindPattern = @"^[0-9A-Z][-.\w]*(?<=[0-9A-Z])@";
        sw = Stopwatch.StartNew();
        result = Regex.IsMatch(input, behindPattern, RegexOptions.IgnoreCase);
        sw.Stop();
        Console.WriteLine("Match with Lookbehind: {0} in {1}", result, sw.Elapsed);
    }
}
// The example displays output similar to the following:
//       Match: True in 00:00:00.0017549
//       Match with Lookbehind: True in 00:00:00.0000659
// </Snippet5>
