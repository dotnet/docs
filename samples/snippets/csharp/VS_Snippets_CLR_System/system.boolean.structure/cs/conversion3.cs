// <Snippet8>
using System;

public class Example
{
   public static void Main()
   {
      bool flag = true;
      
      byte byteValue;   
      byteValue = Convert.ToByte(flag);
      Console.WriteLine("{0} -> {1}", flag, byteValue);         
      
      sbyte sbyteValue;
      sbyteValue = Convert.ToSByte(flag);
      Console.WriteLine("{0} -> {1}", flag, sbyteValue);         

      double dblValue;
      dblValue = Convert.ToDouble(flag);
      Console.WriteLine("{0} -> {1}", flag, dblValue);         

      int intValue;
      intValue = Convert.ToInt32(flag);
      Console.WriteLine("{0} -> {1}", flag, intValue);         
   }
}
// The example displays the following output:
//       True -> 1
//       True -> 1
//       True -> 1
//       True -> 1
// </Snippet8>
