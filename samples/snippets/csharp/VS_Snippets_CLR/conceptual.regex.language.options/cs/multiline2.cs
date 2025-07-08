// <Snippet4>
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Multiline2Example
{
    public static void Main()
    {
        SortedList<int, string> scores = new SortedList<int, string>(new DescendingComparer<int>());

        string input = "Joe 164\n" +
                       "Sam 208\n" +
                       "Allison 211\n" +
                       "Gwen 171\n";
        string pattern = @"(?m)^(\w+)\s(\d+)\r*$";

        foreach (Match match in Regex.Matches(input, pattern, RegexOptions.Multiline))
            scores.Add(Convert.ToInt32(match.Groups[2].Value), match.Groups[1].Value);

        // List scores in descending order.
        foreach (KeyValuePair<int, string> score in scores)
            Console.WriteLine($"{score.Value}: {score.Key}");
    }
}

public class DescendingComparer<T> : IComparer<T>
{
    public int Compare(T x, T y)
    {
        return Comparer<T>.Default.Compare(x, y) * -1;
    }
}
// The example displays the following output:
//    Allison: 211
//    Sam: 208
//    Gwen: 171
//    Joe: 164
// </Snippet4>
