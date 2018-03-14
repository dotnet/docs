// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      object[] values = { (int) 12, (long) 10653, (byte) 12, (sbyte) -5,
                         16.3, "string" }; 
      foreach (var value in values) {
         Type t = value.GetType();
         if (t.Equals(typeof(byte)))
            Console.WriteLine("{0} is an unsigned byte.", value);
         else if (t.Equals(typeof(sbyte)))
            Console.WriteLine("{0} is a signed byte.", value);
         else if (t.Equals(typeof(int)))   
            Console.WriteLine("{0} is a 32-bit integer.", value);
         else if (t.Equals(typeof(long)))   
            Console.WriteLine("{0} is a 32-bit integer.", value);
         else if (t.Equals(typeof(double)))
            Console.WriteLine("{0} is a double-precision floating point.", 
                              value);
         else
            Console.WriteLine("'{0}' is another data type.", value);
      }
   }
}
// The example displays the following output:
//    12 is a 32-bit integer.
//    10653 is a 32-bit integer.
//    12 is an unsigned byte.
//    -5 is a signed byte.
//    16.3 is a double-precision floating point.
//    'string' is another data type.
// </Snippet2>




