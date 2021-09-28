﻿// <Snippet2>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "Essential services are provided by regular expressions.";
      string pattern = ".*(es)";
      Match m = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
      if (m.Success) {
         Console.WriteLine("'{0}' found at position {1}",
                           m.Value, m.Index);
         Console.WriteLine("'es' found at position {0}",
                           m.Groups[1].Index);
      }
   }
}
//    'Essential services are provided by regular expres' found at position 0
//    'es' found at position 47
// </Snippet2>
