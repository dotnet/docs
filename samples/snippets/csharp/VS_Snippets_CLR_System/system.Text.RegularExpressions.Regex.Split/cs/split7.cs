// <Snippet7>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = "(-)|([|])";     // possible delimiters found in string
      string input = "apple|apricot|plum|pear|pomegranate|pineapple|peach";

      Regex regex = new Regex(pattern);    
      // Split on delimiters from 15th character on
      string[] substrings = regex.Split(input, 4, 15);
      foreach (string match in substrings)
      {
         Console.WriteLine("'{0}'", match);
      }
   }
}
// In .NET 2.0 and later, the method returns an array of
// 7 elements, as follows:
//    apple|apricot|plum'
//    '|'
//    'pear'
//    '|'
//    'pomegranate'
//    '|'
//    'pineapple|peach'
// In .NET 1.0 and 1.1, the method returns an array of
// 4 elements, as follows:
//    'apple|apricot|plum'
//    'pear'
//    'pomegranate'
//    'pineapple|peach'
// </Snippet7>
