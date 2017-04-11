// <Snippet3>
using System;

public class Example
{
   public static void Main()
   {
      Object[] values = { true, 12.632, 17908, "stringValue",
                                 'a', 16907.32m };
      foreach (var value in values)
         Console.WriteLine(value);
   }
}
// The example displays the following output:
//    True
//    12.632
//    17908
//    stringValue
//    a
//    16907.32
// </Snippet3>