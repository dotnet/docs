// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string[] values = { Convert.ToString(12, 16),
                          Convert.ToString(123, 16),
                          Convert.ToString(245, 16) };

      byte mask = 0xFE;
      foreach (string value in values) {
         Byte byteValue = Byte.Parse(value, NumberStyles.AllowHexSpecifier);
         Console.WriteLine($"{byteValue} And {mask} = {byteValue & mask}");
      }
   }
}
// The example displays the following output:
//       12 And 254 = 12
//       123 And 254 = 122
//       245 And 254 = 244
// </Snippet1>
