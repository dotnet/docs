// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      object[] values = { (short) 10, (short) 20, 10, 20,
                          10L, 20L, 10D, 20D, (ushort) 10,
                          (ushort) 20, 10U, 20U,
                          10ul, 20ul };
      UInt64 baseValue = 20;
      String baseType = baseValue.GetType().Name;
      
      foreach (var value in values)
         Console.WriteLine("{0} ({1}) = {2} ({3}): {4}",
                           baseValue, baseType,
                           value, value.GetType().Name,
                           baseValue.Equals(value));

   }
}
// The example displays the following output:
//       20 (UInt64) = 10 (Int16): False
//       20 (UInt64) = 20 (Int16): False
//       20 (UInt64) = 10 (Int32): False
//       20 (UInt64) = 20 (Int32): False
//       20 (UInt64) = 10 (Int64): False
//       20 (UInt64) = 20 (Int64): False
//       20 (UInt64) = 10 (Double): False
//       20 (UInt64) = 20 (Double): False
//       20 (UInt64) = 10 (UInt16): False
//       20 (UInt64) = 20 (UInt16): False
//       20 (UInt64) = 10 (UInt32): False
//       20 (UInt64) = 20 (UInt32): False
//       20 (UInt64) = 10 (UInt64): False
//       20 (UInt64) = 20 (UInt64): True
// </Snippet1>