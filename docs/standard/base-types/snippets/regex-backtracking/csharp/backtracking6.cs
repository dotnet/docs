// <Snippet6>
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

public class Example6
{
    public static void Run()
    {
        string input = "aaaaaaaaaaaaaaaaaaaaaa.";
        bool result;
        Stopwatch sw;

        string pattern = @"^(([A-Z]\w*)+\.)*[A-Z]\w*$";
        sw = Stopwatch.StartNew();
        result = Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
        sw.Stop();
        Console.WriteLine($"{result} in {sw.Elapsed}");

        string aheadPattern = @"^((?=[A-Z])\w+\.)*[A-Z]\w*$";
        sw = Stopwatch.StartNew();
        result = Regex.IsMatch(input, aheadPattern, RegexOptions.IgnoreCase);
        sw.Stop();
        Console.WriteLine($"{result} in {sw.Elapsed}");
    }
}
// The example displays the following output:
//       False in 00:00:03.8003793
//       False in 00:00:00.0000866
// </Snippet6>
