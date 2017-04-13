// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
       var nullInt = new Nullable<int>(172);
       // Convert with CInt conversion method.
       Console.WriteLine((int)nullInt);
       // Convert with Convert.ChangeType.
       Console.WriteLine(Convert.ChangeType(nullInt, typeof(int)));
   }
}
// The example displays the following output:
//       172
//       172
// </Snippet1>