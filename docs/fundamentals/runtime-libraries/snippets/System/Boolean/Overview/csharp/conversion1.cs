// <Snippet6>
using System;

public class Example2
{
   public static void Main()
   {
      Byte byteValue = 12;
      Console.WriteLine(Convert.ToBoolean(byteValue));
      Byte byteValue2 = 0;
      Console.WriteLine(Convert.ToBoolean(byteValue2));
      int intValue = -16345;
      Console.WriteLine(Convert.ToBoolean(intValue));
      long longValue = 945;
      Console.WriteLine(Convert.ToBoolean(longValue));
      SByte sbyteValue = -12;
      Console.WriteLine(Convert.ToBoolean(sbyteValue));
      double dblValue = 0;
      Console.WriteLine(Convert.ToBoolean(dblValue));
      float sngValue = .0001f;
      Console.WriteLine(Convert.ToBoolean(sngValue));
   }
}
// The example displays the following output:
//       True
//       False
//       True
//       True
//       True
//       False
//       True
// </Snippet6>
