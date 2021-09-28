using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
         var enUs = new CultureInfo("en-US");
        var japaneseCal = new JapaneseCalendar();
        var jaJp = new CultureInfo("ja-JP");
        jaJp.DateTimeFormat.Calendar = japaneseCal;
        string heiseiEra = "平成";

        var date = japaneseCal.ToDateTime(1, 8, 18, 0, 0, 0, 0, GetEraIndex(heiseiEra));
        FormattableString fmt = $"{date:D}";
        Console.WriteLine($"Japanese calendar date: {fmt.ToString(jaJp)} (Gregorian: {fmt.ToString(enUs)})");

        int GetEraIndex(string eraName)
        {
           foreach (var ctr in japaneseCal.Eras)
              if (jaJp.DateTimeFormat.GetEraName(ctr) == eraName)
                 return ctr;

           return 0;
        }
    }
}
// The example displays the following output:
//    Japanese calendar date: 平成元年8月18日 (Gregorian: Friday, August 18, 1989)
