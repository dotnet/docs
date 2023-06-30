// <Snippet3>
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Multiline1Example
{
    public static void Main()
    {
        SortedList<int, string> scores = new SortedList<int, string>(new DescendingComparer1<int>());

        string input = "Joe 164\n" +
                       "Sam 208\n" +
                       "Allison 211\n" +
                       "Gwen 171\n";
        string pattern = @"^(\w+)\s(\d+)$";
        bool matched = false;

        Console.WriteLine("Without Multiline option:");
        foreach (Match match in Regex.Matches(input, pattern))
        {
            scores.Add(Int32.Parse(match.Groups[2].Value), (string)match.Groups[1].Value);
            matched = true;
        }
        if (!matched)
            Console.WriteLine("   No matches.");
        Console.WriteLine();

        // Redefine pattern to handle multiple lines.
        pattern = @"^(\w+)\s(\d+)\r*$";
        Console.WriteLine("With multiline option:");
        foreach (Match match in Regex.Matches(input, pattern, RegexOptions.Multiline))
            scores.Add(Int32.Parse(match.Groups[2].Value), (string)match.Groups[1].Value);

        // List scores in descending order.
        foreach (KeyValuePair<int, string> score in scores)
            Console.WriteLine("{0}: {1}", score.Value, score.Key);
    }
}

public class DescendingComparer1<T> : IComparer<T>
{
    public int Compare(T x, T y)
    {
        return Comparer<T>.Default.Compare(x, y) * -1;
    }
}
// The example displays the following output:
//   Without Multiline option:
//      No matches.
//
//   With multiline option:
//   Allison: 211
//   Sam: 208
//   Gwen: 171
//   Joe: 164
// </Snippet3>
