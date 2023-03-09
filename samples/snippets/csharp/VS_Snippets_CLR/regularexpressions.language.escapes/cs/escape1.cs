// <Snippet1>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string delimited = @"\G(.+)[\t\u007c](.+)\r?\n";
      string input = "Mumbai, India|13,922,125\t\n" +
                            "Shanghai, China\t13,831,900\n" +
                            "Karachi, Pakistan|12,991,000\n" +
                            "Delhi, India\t12,259,230\n" +
                            "Istanbul, Türkiye|11,372,613\n";
      Console.WriteLine("Population of the World's Largest Cities, 2009");
      Console.WriteLine();
      Console.WriteLine("{0,-20} {1,10}", "City", "Population");
      Console.WriteLine();
      foreach (Match match in Regex.Matches(input, delimited))
         Console.WriteLine("{0,-20} {1,10}", match.Groups[1].Value,
                                            match.Groups[2].Value);
   }
}
// The example displays the following output:
//       Population of the World's Largest Cities, 2009
//
//       City                 Population
//
//       Mumbai, India        13,922,125
//       Shanghai, China      13,831,900
//       Karachi, Pakistan    12,991,000
//       Delhi, India         12,259,230
//       Istanbul, Türkiye     11,372,613
// </Snippet1>
