// <Snippet1>
using System;

enum SignMagnitude { Negative = -1, Zero = 0, Positive = 1 };
 
public class Example
{
   public static void Main()
   {
      foreach (var name in Enum.GetNames(typeof(SignMagnitude))) {
         Console.WriteLine("{0,3:D}     0x{0:X}     {1}",
                           Enum.Parse(typeof(SignMagnitude), name),
                           name);
}   }
}
// The example displays the following output:
//         0     0x00000000     Zero
//         1     0x00000001     Positive
//        -1     0xFFFFFFFF     Negative
// </Snippet1>
