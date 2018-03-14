// <Snippet23>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = "[a-z]+";
      string input = "Abc1234Def5678Ghi9012Jklm";
      string[] result = Regex.Split(input, pattern, 
                                    RegexOptions.IgnoreCase,
                                    TimeSpan.FromMilliseconds(500));
      for (int ctr = 0; ctr < result.Length; ctr++) {
         Console.Write("'{0}'", result[ctr]);
         if (ctr < result.Length - 1) 
            Console.Write(", ");
      }
      Console.WriteLine();
   }
}
// The example displays the following output:
//       '', '1234', '5678', '9012', ''
// </Snippet23>
