// <Snippet8>
using System;
using System.Globalization;
using System.IO;
using System.Threading;

public class Example
{
   public static void Main()
   {
      StreamWriter sw = new StreamWriter(@".\eras.txt");
      DateTime dt = new DateTime(2012, 5, 1);

      CultureInfo culture = CultureInfo.CreateSpecificCulture("ja-JP");
      DateTimeFormatInfo dtfi = culture.DateTimeFormat;
      dtfi.Calendar = new JapaneseCalendar();
      Thread.CurrentThread.CurrentCulture = culture;

      sw.WriteLine("\n{0,-43} {1}", "Full Date and Time Pattern:", dtfi.FullDateTimePattern);
      sw.WriteLine(dt.ToString("F"));
      sw.WriteLine();

      sw.WriteLine("\n{0,-43} {1}", "Long Date Pattern:", dtfi.LongDatePattern);
      sw.WriteLine(dt.ToString("D"));

      sw.WriteLine("\n{0,-43} {1}", "Short Date Pattern:", dtfi.ShortDatePattern);
      sw.WriteLine(dt.ToString("d"));
      sw.Close();
    }
}
// The example writes the following output to a file:
//    Full Date and Time Pattern:                 gg y'年'M'月'd'日' H:mm:ss
//    平成 24年5月1日 0:00:00
//
//    Long Date Pattern:                          gg y'年'M'月'd'日'
//    平成 24年5月1日
//
//    Short Date Pattern:                         gg y/M/d
//    平成 24/5/1
// </Snippet8>
