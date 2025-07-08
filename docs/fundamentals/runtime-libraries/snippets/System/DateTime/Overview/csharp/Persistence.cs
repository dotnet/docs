using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Xml.Serialization;

namespace SystemDateTimeReference
{
    public static class Persistence
    {
        private const string filenameTxt = @".\BadDates.txt";

        public static void Snippets()
        {
            File.Delete(filenameTxt);
            PersistAsLocalStrings();
            File.Delete(filenameTxt);
            PersistAsInvariantStrings();
            File.Delete(filenameTxt);

            File.Delete(filenameInts);
            PersistAsIntegers();
            File.Delete(filenameInts);

            File.Delete(filenameXml);
            PersistAsXML();
            File.Delete(filenameXml);
        }

        // <Snippet1>
        public static void PersistAsLocalStrings()
        {
            SaveLocalDatesAsString();
            RestoreLocalDatesFromString();
        }

        private static void SaveLocalDatesAsString()
        {
            DateTime[] dates = { new DateTime(2014, 6, 14, 6, 32, 0),
                           new DateTime(2014, 7, 10, 23, 49, 0),
                           new DateTime(2015, 1, 10, 1, 16, 0),
                           new DateTime(2014, 12, 20, 21, 45, 0),
                           new DateTime(2014, 6, 2, 15, 14, 0) };
            string? output = null;

            Console.WriteLine($"Current Time Zone: {TimeZoneInfo.Local.DisplayName}");
            Console.WriteLine($"The dates on an {Thread.CurrentThread.CurrentCulture.Name} system:");
            for (int ctr = 0; ctr < dates.Length; ctr++)
            {
                Console.WriteLine(dates[ctr].ToString("f"));
                output += dates[ctr].ToString() + (ctr != dates.Length - 1 ? "|" : "");
            }
            var sw = new StreamWriter(filenameTxt);
            sw.Write(output);
            sw.Close();
            Console.WriteLine("Saved dates...");
        }

        private static void RestoreLocalDatesFromString()
        {
            TimeZoneInfo.ClearCachedData();
            Console.WriteLine($"Current Time Zone: {TimeZoneInfo.Local.DisplayName}");
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
            StreamReader sr = new StreamReader(filenameTxt);
            string[] inputValues = sr.ReadToEnd().Split(new char[] { '|' },
                                                        StringSplitOptions.RemoveEmptyEntries);
            sr.Close();
            Console.WriteLine($"The dates on an {Thread.CurrentThread.CurrentCulture.Name} system:");
            foreach (var inputValue in inputValues)
            {
                DateTime dateValue;
                if (DateTime.TryParse(inputValue, out dateValue))
                {
                    Console.WriteLine($"'{inputValue}' --> {dateValue:f}");
                }
                else
                {
                    Console.WriteLine($"Cannot parse '{inputValue}'");
                }
            }
            Console.WriteLine("Restored dates...");
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
        //       Cannot parse //6/14/2014 6:32:00 AM//
        //       //7/10/2014 11:49:00 PM// --> 07 October 2014 23:49
        //       //1/10/2015 1:16:00 AM// --> 01 October 2015 01:16
        //       Cannot parse //12/20/2014 9:45:00 PM//
        //       //6/2/2014 3:14:00 PM// --> 06 February 2014 15:14
        //       Restored dates...
        // </Snippet1>

        // <Snippet2>
        public static void PersistAsInvariantStrings()
        {
            SaveDatesAsInvariantStrings();
            RestoreDatesAsInvariantStrings();
        }

        private static void SaveDatesAsInvariantStrings()
        {
            DateTime[] dates = { new DateTime(2014, 6, 14, 6, 32, 0),
                           new DateTime(2014, 7, 10, 23, 49, 0),
                           new DateTime(2015, 1, 10, 1, 16, 0),
                           new DateTime(2014, 12, 20, 21, 45, 0),
                           new DateTime(2014, 6, 2, 15, 14, 0) };
            string? output = null;

            Console.WriteLine($"Current Time Zone: {TimeZoneInfo.Local.DisplayName}");
            Console.WriteLine($"The dates on an {Thread.CurrentThread.CurrentCulture.Name} system:");
            for (int ctr = 0; ctr < dates.Length; ctr++)
            {
                Console.WriteLine(dates[ctr].ToString("f"));
                output += dates[ctr].ToUniversalTime().ToString("O", CultureInfo.InvariantCulture)
                          + (ctr != dates.Length - 1 ? "|" : "");
            }
            var sw = new StreamWriter(filenameTxt);
            sw.Write(output);
            sw.Close();
            Console.WriteLine("Saved dates...");
        }

        private static void RestoreDatesAsInvariantStrings()
        {
            TimeZoneInfo.ClearCachedData();
            Console.WriteLine($"Current Time Zone: {TimeZoneInfo.Local.DisplayName}");
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
            StreamReader sr = new StreamReader(filenameTxt);
            string[] inputValues = sr.ReadToEnd().Split(new char[] { '|' },
                                                        StringSplitOptions.RemoveEmptyEntries);
            sr.Close();
            Console.WriteLine($"The dates on an {Thread.CurrentThread.CurrentCulture.Name} system:");
            foreach (var inputValue in inputValues)
            {
                DateTime dateValue;
                if (DateTime.TryParseExact(inputValue, "O", CultureInfo.InvariantCulture,
                                      DateTimeStyles.RoundtripKind, out dateValue))
                {
                    Console.WriteLine($"'{inputValue}' --> {dateValue.ToLocalTime():f}");
                }
                else
                {
                    Console.WriteLine($"Cannot parse '{inputValue}'");
                }
            }
            Console.WriteLine("Restored dates...");
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

        private const string filenameInts = @".\IntDates.bin";

        // <Snippet3>
        public static void PersistAsIntegers()
        {
            SaveDatesAsInts();
            RestoreDatesAsInts();
        }

        private static void SaveDatesAsInts()
        {
            DateTime[] dates = { new DateTime(2014, 6, 14, 6, 32, 0),
                           new DateTime(2014, 7, 10, 23, 49, 0),
                           new DateTime(2015, 1, 10, 1, 16, 0),
                           new DateTime(2014, 12, 20, 21, 45, 0),
                           new DateTime(2014, 6, 2, 15, 14, 0) };

            Console.WriteLine($"Current Time Zone: {TimeZoneInfo.Local.DisplayName}");
            Console.WriteLine($"The dates on an {Thread.CurrentThread.CurrentCulture.Name} system:");
            var ticks = new long[dates.Length];
            for (int ctr = 0; ctr < dates.Length; ctr++)
            {
                Console.WriteLine(dates[ctr].ToString("f"));
                ticks[ctr] = dates[ctr].ToUniversalTime().Ticks;
            }
            var fs = new FileStream(filenameInts, FileMode.Create);
            var bw = new BinaryWriter(fs);
            bw.Write(ticks.Length);
            foreach (var tick in ticks)
                bw.Write(tick);

            bw.Close();
            Console.WriteLine("Saved dates...");
        }

        private static void RestoreDatesAsInts()
        {
            TimeZoneInfo.ClearCachedData();
            Console.WriteLine($"Current Time Zone: {TimeZoneInfo.Local.DisplayName}");
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
            FileStream fs = new FileStream(filenameInts, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            int items;
            DateTime[] dates;

            try
            {
                items = br.ReadInt32();
                dates = new DateTime[items];

                for (int ctr = 0; ctr < items; ctr++)
                {
                    long ticks = br.ReadInt64();
                    dates[ctr] = new DateTime(ticks).ToLocalTime();
                }
            }
            catch (EndOfStreamException)
            {
                Console.WriteLine("File corruption detected. Unable to restore data...");
                return;
            }
            catch (IOException)
            {
                Console.WriteLine("Unspecified I/O error. Unable to restore data...");
                return;
            }
            // Thrown during array initialization.
            catch (OutOfMemoryException)
            {
                Console.WriteLine("File corruption detected. Unable to restore data...");
                return;
            }
            finally
            {
                br.Close();
            }

            Console.WriteLine($"The dates on an {Thread.CurrentThread.CurrentCulture.Name} system:");
            foreach (var value in dates)
                Console.WriteLine(value.ToString("f"));

            Console.WriteLine("Restored dates...");
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
        // </Snippet3>

        private const string filenameXml = @".\LeapYears.xml";

        // <Snippet4>
        public static void PersistAsXML()
        {
            // Serialize the data.
            var leapYears = new List<DateTime>();
            for (int year = 2000; year <= 2100; year += 4)
            {
                if (DateTime.IsLeapYear(year))
                    leapYears.Add(new DateTime(year, 2, 29));
            }
            DateTime[] dateArray = leapYears.ToArray();

            var serializer = new XmlSerializer(dateArray.GetType());
            TextWriter sw = new StreamWriter(filenameXml);

            try
            {
                serializer.Serialize(sw, dateArray);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.InnerException?.Message);
            }
            finally
            {
                if (sw != null) sw.Close();
            }

            // Deserialize the data.
            DateTime[]? deserializedDates;
            using (var fs = new FileStream(filenameXml, FileMode.Open))
            {
                deserializedDates = (DateTime[]?)serializer.Deserialize(fs);
            }

            // Display the dates.
            Console.WriteLine($"Leap year days from 2000-2100 on an {Thread.CurrentThread.CurrentCulture.Name} system:");
            int nItems = 0;
            if (deserializedDates is not null)
            {
                foreach (var dat in deserializedDates)
                {
                    Console.Write($"   {dat:d}     ");
                    nItems++;
                    if (nItems % 5 == 0)
                        Console.WriteLine();
                }
            }
        }
        // The example displays the following output:
        //    Leap year days from 2000-2100 on an en-GB system:
        //       29/02/2000       29/02/2004       29/02/2008       29/02/2012       29/02/2016
        //       29/02/2020       29/02/2024       29/02/2028       29/02/2032       29/02/2036
        //       29/02/2040       29/02/2044       29/02/2048       29/02/2052       29/02/2056
        //       29/02/2060       29/02/2064       29/02/2068       29/02/2072       29/02/2076
        //       29/02/2080       29/02/2084       29/02/2088       29/02/2092       29/02/2096
        // </Snippet4>
    }
}
