// <Snippet2>
using System;
using System.Globalization;
using System.IO;
using System.Threading;

public class Example
{
   private const string filename = @".\Dates.txt";

   public static void Main()
   {
      if (! File.Exists(filename))
         SaveDates();
      else
         RestoreDates();
   }

   private static void SaveDates()
   {
      DateTime[] dates = { new DateTime(2014, 6, 14, 6, 32, 0), 
                           new DateTime(2014, 7, 10, 23, 49, 0),  
                           new DateTime(2015, 1, 10, 1, 16, 0), 
                           new DateTime(2014, 12, 20, 21, 45, 0), 
                           new DateTime(2014, 6, 2, 15, 14, 0) }; 
      string output = null;
 
      Console.WriteLine("Current Time Zone: {0}",
                        TimeZoneInfo.Local.DisplayName);
      Console.WriteLine("The dates on an {0} system:", 
                        Thread.CurrentThread.CurrentCulture.Name);
      for (int ctr = 0; ctr < dates.Length; ctr++) { 
         Console.WriteLine(dates[ctr].ToString("f"));
         output += dates[ctr].ToUniversalTime().ToString("O", CultureInfo.InvariantCulture) 
                   + (ctr != dates.Length - 1 ? "|" : "");
      }
      StreamWriter sw = new StreamWriter(filename);
      sw.Write(output);
      sw.Close();
      Console.WriteLine("Saved dates...");
   }

   private static void RestoreDates()
   {
      TimeZoneInfo.ClearCachedData();
      Console.WriteLine("Current Time Zone: {0}",
                        TimeZoneInfo.Local.DisplayName);
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
      StreamReader sr = new StreamReader(filename);
      string[] inputValues = sr.ReadToEnd().Split( new char[] { '|' } , 
                                                  StringSplitOptions.RemoveEmptyEntries);
      sr.Close();
      Console.WriteLine("The dates on an {0} system:", 
                        Thread.CurrentThread.CurrentCulture.Name);
      foreach (var inputValue in inputValues) {
         DateTime dateValue;
         if (DateTime.TryParseExact(inputValue, "O", CultureInfo.InvariantCulture, 
                               DateTimeStyles.RoundtripKind, out dateValue)) {
            Console.WriteLine("'{0}' --> {1:f}", 
                              inputValue, dateValue.ToLocalTime());
         }
         else {
            Console.WriteLine("Cannot parse '{0}'", inputValue);   
         }
      }
      Console.WriteLine("Restored dates...");   
   }
}
// When saved on an en-US system, the example displays the following output:
//       Current Time Zone: (UTC-08:00) Pacific Time (US & Canada)
//       The dates on an en-US system:
//       Saturday, June 14, 2014 6:32 AM
//       Thursday, July 10, 2014 11:49 PM
//       Saturday, January 10, 2015 1:16 AM
//       Saturday, December 20, 2014 9:45 PM
//       Monday, June 02, 2014 3:14 PM
//       Saved dates...
//
// When restored on an en-GB system, the example displays the following output:
//       Current Time Zone: (UTC) Dublin, Edinburgh, Lisbon, London
//       The dates on an en-GB system:
//       '2014-06-14T13:32:00.0000000Z' --> 14 June 2014 14:32
//       '2014-07-11T06:49:00.0000000Z' --> 11 July 2014 07:49
//       '2015-01-10T09:16:00.0000000Z' --> 10 January 2015 09:16
//       '2014-12-21T05:45:00.0000000Z' --> 21 December 2014 05:45
//       '2014-06-02T22:14:00.0000000Z' --> 02 June 2014 23:14
//       Restored dates...
// </Snippet2>
