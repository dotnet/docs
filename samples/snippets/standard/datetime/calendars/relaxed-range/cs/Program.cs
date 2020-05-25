using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      var jaJp = new CultureInfo("ja-JP");
      var cal = new JapaneseCalendar();
      jaJp.DateTimeFormat.Calendar = cal;
      string showaEra = "昭和";

      var dt = cal.ToDateTime(65, 1, 9, 15, 0, 0, 0, GetEraIndex(showaEra));
      FormattableString fmt = $"{dt:d}";

      Console.WriteLine($"Japanese calendar date: {fmt.ToString(jaJp)}");
      Console.WriteLine($"Gregorian calendar date: {fmt}");

      int GetEraIndex(string eraName)
      {
         foreach (var ctr in cal.Eras)
            if (jaJp.DateTimeFormat.GetEraName(ctr) == eraName)
               return ctr;

         return 0;
      }
   }
}
// The example displays the following output:
//   Japanese calendar date: 平成2/1/9
//   Gregorian calendar date: 1/9/1990
