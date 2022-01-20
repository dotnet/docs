// <Snippet4>
using System;
using System.Text.RegularExpressions;

public class Example
{
    public static void Main()
    {
        string input = "<PRIVATE> This is not for public consumption." + Environment.NewLine +
                       "But this is for public consumption." + Environment.NewLine +
                       "<PRIVATE> Again, this is confidential.\n";
        string pattern = @"^(?<Pvt>\<PRIVATE\>\s)?(?(Pvt)((\w+\p{P}?\s)+)|((\w+\p{P}?\s)+))\r?$";
        string publicDocument = null, privateDocument = null;

        foreach (Match match in Regex.Matches(input, pattern, RegexOptions.Multiline))
        {
            if (match.Groups[1].Success)
            {
                privateDocument += match.Groups[1].Value + "\n";
            }
            else
            {
                publicDocument += match.Groups[3].Value + "\n";
                privateDocument += match.Groups[3].Value + "\n";
            }
        }

        Console.WriteLine("Private Document:");
        Console.WriteLine(privateDocument);
        Console.WriteLine("Public Document:");
        Console.WriteLine(publicDocument);
    }
}
// The example displays the following output:
//    Private Document:
//    This is not for public consumption.
//    But this is for public consumption.
//    Again, this is confidential.
//
//    Public Document:
//    But this is for public consumption.
// </Snippet4>
