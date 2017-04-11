// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      object[] values = { "word", true, 120, 136.34, 'a' };
      foreach (var value in values)
         Console.WriteLine("{0} - type {1}", value, 
                           value.GetType().Name);
   }
}
// The example displays the following output:
//       word - type String
//       True - type Boolean
//       120 - type Int32
//       136.34 - type Double
//       a - type Char
// </Snippet2>

