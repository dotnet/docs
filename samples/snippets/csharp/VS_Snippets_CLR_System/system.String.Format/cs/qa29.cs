// <Snippet29>
using System;

public class Example
{
   public static void Main()
   {
      int value = 1326;
      string result = String.Format("{0,10:D6} {0,10:X8}", value);
      Console.WriteLine(result);
   }
}
// The example displays the following output:
//     001326   0000052E
// </Snippet29>
