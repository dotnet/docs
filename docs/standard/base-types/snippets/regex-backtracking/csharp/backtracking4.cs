// <Snippet4>
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

public class Example4
{
    public static void Run()
    {
        string input = "b51:4:1DB:9EE1:5:27d60:f44:D4:cd:E:5:0A5:4a:D24:41Ad:";
        bool matched;
        Stopwatch sw;

        Console.WriteLine("With backtracking:");
        string backPattern = "^(([0-9a-fA-F]{1,4}:)*([0-9a-fA-F]{1,4}))*(::)$";
        sw = Stopwatch.StartNew();
        matched = Regex.IsMatch(input, backPattern);
        sw.Stop();
        Console.WriteLine($"Match: {Regex.IsMatch(input, backPattern)} in {sw.Elapsed}");
        Console.WriteLine();

        Console.WriteLine("Without backtracking:");
        string noBackPattern = "^((?>[0-9a-fA-F]{1,4}:)*(?>[0-9a-fA-F]{1,4}))*(::)$";
        sw = Stopwatch.StartNew();
        matched = Regex.IsMatch(input, noBackPattern);
        sw.Stop();
        Console.WriteLine($"Match: {Regex.IsMatch(input, noBackPattern)} in {sw.Elapsed}");
    }
}
// The example displays output like the following:
//       With backtracking:
//       Match: False in 00:00:27.4282019
//
//       Without backtracking:
//       Match: False in 00:00:00.0001391
// </Snippet4>
