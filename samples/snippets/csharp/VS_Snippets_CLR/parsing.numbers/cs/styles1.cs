// <Snippet2>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string value = "1,304";
      int number;
      IFormatProvider provider = CultureInfo.CreateSpecificCulture("en-US");
      if (Int32.TryParse(value, out number))
         Console.WriteLine($"{value} --> {number}");
      else
         Console.WriteLine($"Unable to convert '{value}'");

      if (Int32.TryParse(value, NumberStyles.Integer | NumberStyles.AllowThousands,
                        provider, out number))
         Console.WriteLine($"{value} --> {number}");
      else
         Console.WriteLine($"Unable to convert '{value}'");
   }
}
// The example displays the following output:
//       Unable to convert '1,304'
//       1,304 --> 1304
// </Snippet2>