using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      int ctr = 1;
      Match match = Regex.Match("aaabbbaaacccaaaddd", "(aaa)");
      if (match.Success)
      {
         // <Snippet13>
         Group group = match.Groups[ctr];         
         // </Snippet13>
      }
   }
}
