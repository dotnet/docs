// <Snippet10>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = @"07/14/2007";   
      string pattern = @"(-)|(/)";

      foreach (string result in Regex.Split(input, pattern)) 
      {
         Console.WriteLine("'{0}'", result);
      }
   }
}
// In .NET 1.0 and 1.1, the method returns an array of
// 3 elements, as follows:
//    '07'
//    '14'
//    '2007'
//
// In .NET 2.0 and later, the method returns an array of
// 5 elements, as follows:
//    '07'
//    '/'
//    '14'
//    '/'
//    '2007' 
// </Snippet10>     
