using System;
using System.Text.RegularExpressions;

namespace Examples
{
    public class Example3
    {
        public static void Main()
        {
            string input = "Zip code: 98052";
            var regex = new Regex(@"(?<=Zip code: )\d{5}");
            Match match = regex.Match(input, 5);
            if (match.Success)
                Console.WriteLine($"Match found: {match.Value}");
        }
    }
}

// This code prints the following output:
// Match found: 98052
