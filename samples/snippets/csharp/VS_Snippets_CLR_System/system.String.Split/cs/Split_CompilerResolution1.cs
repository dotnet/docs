// <Snippet12>
using System;

public class Example
{
   public static void Main()
   {
      String value = "This is a short string.";
      Char delimiter = 's';
      String[] substrings = value.Split(delimiter);
      foreach (var substring in substrings)
         Console.WriteLine(substring);
   }
}
// The example displays the following output:
//     Thi
//      i
//      a
//     hort
//     tring.
// </Snippet12>
