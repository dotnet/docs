// <Snippet5>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = @"07/14/2007";   
      string pattern = @"(-)|(/)";
      Regex regex = new Regex(pattern);
      foreach (string result in regex.Split(input, 2)) 
      {
         Console.WriteLine("'{0}'", result);
      }
   }
}
// Under .NET 1.0 and 1.1, the method returns an array of
// 2 elements, as follows:
//    '07'
//    '14/2007'
//
// Under .NET 2.0 and later, the method returns an array of
// 3 elements, as follows:
//    '07'
//    '/'
//    '14/2007' 
// </Snippet5>     
