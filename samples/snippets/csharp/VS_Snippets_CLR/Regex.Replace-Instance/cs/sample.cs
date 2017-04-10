// <snippet1>
using System;
using System.Text.RegularExpressions;

class RegExSample
{
    static string CapText(Match m)
    {
        // Get the matched string.
        string x = m.ToString();
        // If the first char is lower case...
        if (char.IsLower(x[0]))
        {
            // Capitalize it.
            return char.ToUpper(x[0]) + x.Substring(1, x.Length - 1);
        }
        return x;
    }

    static void Main()
    {
        string text = "four score and seven years ago";

        System.Console.WriteLine("text=[" + text + "]");

        Regex rx = new Regex(@"\w+");

        string result = rx.Replace(text, new MatchEvaluator(RegExSample.CapText));
        
        System.Console.WriteLine("result=[" + result + "]");
    }
}
// The example displays the following output:
//       text=[four score and seven years ago]
//       result=[Four Score And Seven Years Ago]
// </snippet1>