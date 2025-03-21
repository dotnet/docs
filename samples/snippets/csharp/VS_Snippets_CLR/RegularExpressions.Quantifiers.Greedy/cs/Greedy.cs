using System;
using System.Text.RegularExpressions;

[assembly: CLSCompliant(true)]
public class Class1
{
   public static void Main()
   {
      // <Snippet1>
      string greedyPattern = @"\b.*([0-9]{4})\b";
      string input1 = "1112223333 3992991999";
      foreach (Match match in Regex.Matches(input1, greedyPattern))
         Console.WriteLine($"Account ending in ******{match.Groups[1].Value}.");

      // The example displays the following output:
      //       Account ending in ******1999.
      // </Snippet1>
      Console.WriteLine();

      // <Snippet2>
      string lazyPattern = @"\b.*?([0-9]{4})\b";
      string input2 = "1112223333 3992991999";
      foreach (Match match in Regex.Matches(input2, lazyPattern))
         Console.WriteLine($"Account ending in ******{match.Groups[1].Value}.");

      // The example displays the following output:
      //       Account ending in ******3333.
      //       Account ending in ******1999.
      // </Snippet2>
   }
}
