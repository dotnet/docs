//<Snippet1>
using System;

class Example
{
   public static void Main( )
   {
      // Define Boolean true and false values.
      bool[] values = { true, false };

      // Display the value and its corresponding byte array.
      Console.WriteLine("{0,10}{1,16}\n", "Boolean", "Bytes");
      foreach (var value in values) {
         byte[] bytes = BitConverter.GetBytes(value); 
         Console.WriteLine("{0,10}{1,16}", value, 
                           BitConverter.ToString(bytes));
      }
   }
}
// The example displays the following output:
//        Boolean           Bytes
//     
//           True              01
//          False              00
//</Snippet1>
