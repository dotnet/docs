// <Snippet8>
using System;

public class Example3
{
   public static void Main()
   {
      bool flag = true;

      byte byteValue;
      byteValue = Convert.ToByte(flag);
      Console.WriteLine($"{flag} -> {byteValue}");

      sbyte sbyteValue;
      sbyteValue = Convert.ToSByte(flag);
      Console.WriteLine($"{flag} -> {sbyteValue}");

      double dblValue;
      dblValue = Convert.ToDouble(flag);
      Console.WriteLine($"{flag} -> {dblValue}");

      int intValue;
      intValue = Convert.ToInt32(flag);
      Console.WriteLine($"{flag} -> {intValue}");
   }
}
// The example displays the following output:
//       True -> 1
//       True -> 1
//       True -> 1
//       True -> 1
// </Snippet8>
