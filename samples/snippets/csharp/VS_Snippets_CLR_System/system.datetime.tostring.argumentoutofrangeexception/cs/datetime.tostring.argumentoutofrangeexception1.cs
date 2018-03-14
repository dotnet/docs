// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CultureInfo jaJP = new CultureInfo("ja-JP");
      jaJP.DateTimeFormat.Calendar = new JapaneseCalendar(); 
      DateTime date1 = new DateTime(1867, 1, 1);

      try {
         Console.WriteLine(date1.ToString(jaJP));
      }
      catch (ArgumentOutOfRangeException) {
         Console.WriteLine("{0:d} is earlier than {1:d} or later than {2:d}", 
                           date1, 
                           jaJP.DateTimeFormat.Calendar.MinSupportedDateTime,  
                           jaJP.DateTimeFormat.Calendar.MaxSupportedDateTime); 
      }
   }
}
// The example displays the following output:
//    1/1/1867 is earlier than 9/8/1868 or later than 12/31/9999   }
// </Snippet1>
