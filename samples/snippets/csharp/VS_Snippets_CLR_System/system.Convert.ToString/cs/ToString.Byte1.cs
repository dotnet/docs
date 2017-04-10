// <Snippet3> 
using System;

public class Example
{
   public static void Main()
   {
      byte[] values = { Byte.MinValue, 12, 100, 179, Byte.MaxValue } ;

      foreach (var value in values)
         Console.WriteLine("{0,3} ({1}) --> {2}", value, 
                           value.GetType().Name, 
                           Convert.ToString(value));      
   }
}
// The example displays the following output:
//       0 (Byte) --> 0
//      12 (Byte) --> 12
//     100 (Byte) --> 100
//     179 (Byte) --> 179
//     255 (Byte) --> 255
// </Snippet3> 
