
// <Snippet4>
using System;
using System.Globalization;
using System.IO;
using System.Threading;

class Example
{
   private const string filename = @".\IntDates.bin";

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
 
      Console.WriteLine("Current Time Zone: {0}",
                        TimeZoneInfo.Local.DisplayName);
      Console.WriteLine("The dates on an {0} system:", 
                        Thread.CurrentThread.CurrentCulture.Name);
      long[] ticks = new long[dates.Length];
      for (int ctr = 0; ctr < dates.Length; ctr++) { 
         Console.WriteLine(dates[ctr].ToString("f"));
         ticks[ctr] = dates[ctr].ToUniversalTime().Ticks; 
      }
      FileStream fs = new FileStream(filename, FileMode.Create);
      BinaryWriter bw = new BinaryWriter(fs);
      bw.Write(ticks.Length);
      foreach (var tick in ticks)
         bw.Write(tick);

      bw.Close();
      Console.WriteLine("Saved dates...");
   }

   private static void RestoreDates()
   {
      TimeZoneInfo.ClearCachedData();
      Console.WriteLine("Current Time Zone: {0}",
                        TimeZoneInfo.Local.DisplayName);
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
      FileStream fs = new FileStream(filename, FileMode.Open);
      BinaryReader br = new BinaryReader(fs);
      int items;
      DateTime[] dates;

      try { 
         items = br.ReadInt32();
         dates = new DateTime[items];
      
         for (int ctr = 0; ctr < items; ctr++) {
            long ticks = br.ReadInt64();
            dates[ctr] = new DateTime(ticks).ToLocalTime();
         }
      }   
      catch (EndOfStreamException) {
         Console.WriteLine("File corruption detected. Unable to restore data...");
         return;
      }   
      catch (IOException) {
         Console.WriteLine("Unspecified I/O error. Unable to restore data...");
         return;
      }
      // Thrown during array initialization.
      catch (OutOfMemoryException) {
         Console.WriteLine("File corruption detected. Unable to restore data...");
         return;
      }
      finally {      
         br.Close();
      }   
      
      Console.WriteLine("The dates on an {0} system:", 
                        Thread.CurrentThread.CurrentCulture.Name);
      foreach (var value in dates)
         Console.WriteLine(value.ToString("f"));

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
//       14 June 2014 14:32
//       11 July 2014 07:49
//       10 January 2015 09:16
//       21 December 2014 05:45
//       02 June 2014 23:14
//       Restored dates...
// </Snippet4>
