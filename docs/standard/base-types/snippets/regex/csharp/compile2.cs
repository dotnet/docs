// <Snippet7>
using System;
using System.IO;
using System.Text.RegularExpressions;
using Utilities.RegularExpressions;

public class Compile2Example
{
    public static void Main()
    {
        SentencePattern pattern = new SentencePattern();
        StreamReader inFile = new StreamReader(@".\Dreiser_TheFinancier.txt");
        string input = inFile.ReadToEnd();
        inFile.Close();

        MatchCollection matches = pattern.Matches(input);
        Console.WriteLine($"Found {matches.Count:N0} sentences.");
    }
}
// The example displays the following output:
//      Found 13,443 sentences.
// </Snippet7>

// This code is here so that Parsnip will compile the example.
namespace Utilities.RegularExpressions
{
    public class SentencePattern
    {
        public MatchCollection Matches(string input)
        {
            return null;
        }
    }
}
