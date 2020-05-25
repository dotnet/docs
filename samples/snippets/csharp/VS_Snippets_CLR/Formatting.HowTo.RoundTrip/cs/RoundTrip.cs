using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class Class1
{
   public static void Main()
   {
      RoundTripDateTime();
      Console.WriteLine();
      RoundTripDateTimeOffset();
      Console.WriteLine();
      RoundTripTimeWithTimeZone();
   }

   private static void RoundTripDateTime()
   {
      // <Snippet1>
      const string fileName = @".\DateFile.txt";

      StreamWriter outFile = new StreamWriter(fileName);

      // Save DateTime value.
      DateTime dateToSave = DateTime.SpecifyKind(new DateTime(2008, 6, 12, 18, 45, 15),
                                                 DateTimeKind.Local);
      string dateString = dateToSave.ToString("o");
      Console.WriteLine("Converted {0} ({1}) to {2}.",
                        dateToSave.ToString(),
                        dateToSave.Kind.ToString(),
                        dateString);
      outFile.WriteLine(dateString);
      Console.WriteLine("Wrote {0} to {1}.", dateString, fileName);
      outFile.Close();

      // Restore DateTime value.
      DateTime restoredDate;

      StreamReader inFile = new StreamReader(fileName);
      dateString = inFile.ReadLine();
      inFile.Close();
      restoredDate = DateTime.Parse(dateString, null, DateTimeStyles.RoundtripKind);
      Console.WriteLine("Read {0} ({2}) from {1}.", restoredDate.ToString(),
                                                    fileName,
                                                    restoredDate.Kind.ToString());
      // The example displays the following output:
      //    Converted 6/12/2008 6:45:15 PM (Local) to 2008-06-12T18:45:15.0000000-05:00.
      //    Wrote 2008-06-12T18:45:15.0000000-05:00 to .\DateFile.txt.
      //    Read 6/12/2008 6:45:15 PM (Local) from .\DateFile.txt.
      // </Snippet1>
   }

   private static void RoundTripDateTimeOffset()
   {
      // <Snippet2>
      const string fileName = @".\DateOff.txt";

      StreamWriter outFile = new StreamWriter(fileName);

      // Save DateTime value.
      DateTimeOffset dateToSave = new DateTimeOffset(2008, 6, 12, 18, 45, 15,
                                                     new TimeSpan(7, 0, 0));
      string dateString = dateToSave.ToString("o");
      Console.WriteLine("Converted {0} to {1}.", dateToSave.ToString(),
                        dateString);
      outFile.WriteLine(dateString);
      Console.WriteLine("Wrote {0} to {1}.", dateString, fileName);
      outFile.Close();

      // Restore DateTime value.
      DateTimeOffset restoredDateOff;

      StreamReader inFile = new StreamReader(fileName);
      dateString = inFile.ReadLine();
      inFile.Close();
      restoredDateOff = DateTimeOffset.Parse(dateString, null,
                                             DateTimeStyles.RoundtripKind);
      Console.WriteLine("Read {0} from {1}.", restoredDateOff.ToString(),
                        fileName);
      // The example displays the following output:
      //    Converted 6/12/2008 6:45:15 PM +07:00 to 2008-06-12T18:45:15.0000000+07:00.
      //    Wrote 2008-06-12T18:45:15.0000000+07:00 to .\DateOff.txt.
      //    Read 6/12/2008 6:45:15 PM +07:00 from .\DateOff.txt.
      // </Snippet2>
   }

   private static void RoundTripTimeWithTimeZone()
   {
      // <Snippet4>
      const string fileName = @".\DateWithTz.dat";

      DateTime tempDate = new DateTime(2008, 9, 3, 19, 0, 0);
      TimeZoneInfo tempTz = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
      DateInTimeZone dateWithTz = new DateInTimeZone(new DateTimeOffset(tempDate,
                                      tempTz.GetUtcOffset(tempDate)),
                                      tempTz);

      // Store DateInTimeZone value to a file
      FileStream outFile = new FileStream(fileName, FileMode.Create);
      try
      {
         BinaryFormatter formatter = new BinaryFormatter();
         formatter.Serialize(outFile, dateWithTz);
         Console.WriteLine("Saving {0} {1} to {2}", dateWithTz.DateAndTime,
                           dateWithTz.TimeZone.IsDaylightSavingTime(dateWithTz.DateAndTime) ?
                           dateWithTz.TimeZone.DaylightName : dateWithTz.TimeZone.DaylightName,
                           fileName);
      }
      catch (SerializationException)
      {
         Console.WriteLine("Unable to serialize time data to {0}.", fileName);
      }
      finally
      {
         outFile.Close();
      }

      // Retrieve DateInTimeZone value
      if (File.Exists(fileName))
      {
         FileStream inFile = new FileStream(fileName, FileMode.Open);
         DateInTimeZone dateWithTz2 = new DateInTimeZone();
         try
         {
            BinaryFormatter formatter = new BinaryFormatter();
            dateWithTz2 = formatter.Deserialize(inFile) as DateInTimeZone;
            Console.WriteLine("Restored {0} {1} from {2}", dateWithTz2.DateAndTime,
                              dateWithTz2.TimeZone.IsDaylightSavingTime(dateWithTz2.DateAndTime) ?
                              dateWithTz2.TimeZone.DaylightName : dateWithTz2.TimeZone.DaylightName,
                              fileName);
         }
         catch (SerializationException)
         {
            Console.WriteLine("Unable to retrieve date and time information from {0}",
                              fileName);
         }
         finally
         {
            inFile.Close();
         }
      }
      // This example displays the following output to the console:
      //    Saving 9/3/2008 7:00:00 PM -05:00 Central Daylight Time to .\DateWithTz.dat
      //    Restored 9/3/2008 7:00:00 PM -05:00 Central Daylight Time from .\DateWithTz.dat
      // </Snippet4>
   }
}

// <Snippet3>
[Serializable] public class DateInTimeZone
{
   private TimeZoneInfo tz;
   private DateTimeOffset thisDate;

   public DateInTimeZone() {}

   public DateInTimeZone(DateTimeOffset date, TimeZoneInfo timeZone)
   {
      if (timeZone == null)
         throw new ArgumentNullException("The time zone cannot be null.");

      this.thisDate = date;
      this.tz = timeZone;
   }

   public DateTimeOffset DateAndTime
   {
      get {
         return this.thisDate;
      }
      set {
         if (value.Offset != this.tz.GetUtcOffset(value))
            this.thisDate = TimeZoneInfo.ConvertTime(value, tz);
         else
            this.thisDate = value;
      }
   }

   public TimeZoneInfo TimeZone
   {
      get {
         return this.tz;
      }
   }
}
// </Snippet3>
