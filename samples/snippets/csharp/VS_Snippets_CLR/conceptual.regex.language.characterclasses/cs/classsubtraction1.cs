// <Snippet15>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string[] inputs = { "123", "13579753", "3557798", "335599901" };
      string pattern = @"^[0-9-[2468]]+$";
      
      foreach (string input in inputs)
      {
         Match match = Regex.Match(input, pattern);
         if (match.Success) 
            Console.WriteLine(match.Value);
      }      
   }
}
// The example displays the following output:
//       13579753
//       335599901
// </Snippet15>
