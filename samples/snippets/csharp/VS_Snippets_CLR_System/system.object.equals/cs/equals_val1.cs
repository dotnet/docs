// <Snippet3>
using System;

public class Example
{
   public static void Main()
   {
      byte value1 = 12;
      int value2 = 12;
      
      object object1 = value1;
      object object2 = value2;
      
      Console.WriteLine("{0} ({1}) = {2} ({3}): {4}",
                        object1, object1.GetType().Name,
                        object2, object2.GetType().Name,
                        object1.Equals(object2));
   }
}
// The example displays the following output:
//        12 (Byte) = 12 (Int32): False
// </Snippet3>
