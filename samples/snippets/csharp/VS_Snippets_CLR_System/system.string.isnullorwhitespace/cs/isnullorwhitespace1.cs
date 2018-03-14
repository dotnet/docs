// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      string[] values = { null, String.Empty, "ABCDE", 
                          new String(' ', 20), "  \t   ", 
                          new String('\u2000', 10) };
      foreach (string value in values)
         Console.WriteLine(String.IsNullOrWhiteSpace(value));
   }
}
// The example displays the following output:
//       True
//       True
//       False
//       True
//       True
//       True
// </Snippet1>