using System;

public class Example
{
   public static void Main()
   {
      dSpecifier();
      Console.WriteLine("-------");
      ddSpecifier();
      Console.WriteLine("-------");
      hSpecifier();
      Console.WriteLine("-------");
      ParseH();
      Console.WriteLine("-------");
      ParseHH();
      Console.WriteLine("-------");
      hhSpecifier();
      Console.WriteLine("-------");
      ParseM();
      Console.WriteLine("-------");
      mSpecifier();
      Console.WriteLine("-------");
      ParseMM();
      Console.WriteLine("-------");
      mmSpecifier();
      Console.WriteLine("-------");
      sSpecifier();
      Console.WriteLine("-------");
      ParseS();
      Console.WriteLine("-------");
      ParseSS();
      Console.WriteLine("-------");
      ssSpecifier();
      Console.WriteLine("-------");
   }

   private static void dSpecifier()
   {
      // <Snippet3>
      TimeSpan ts1 = new TimeSpan(16, 4, 3, 17, 250);
      Console.WriteLine(ts1.ToString("%d"));
      // Displays 16
      // </Snippet3>
      Console.WriteLine();

      // <Snippet4>
      TimeSpan ts2 = new TimeSpan(4, 3, 17);
      Console.WriteLine(ts2.ToString(@"d\.hh\:mm\:ss"));

      TimeSpan ts3 = new TimeSpan(3, 4, 3, 17);
      Console.WriteLine(ts3.ToString(@"d\.hh\:mm\:ss"));
      // The example displays the following output:
      //       0.04:03:17
      //       3.04:03:17
      // </Snippet4>
   }

   private static void ddSpecifier()
   {
      // <Snippet5>
      TimeSpan ts1 = new TimeSpan(0, 23, 17, 47);
      TimeSpan ts2 = new TimeSpan(365, 21, 19, 45);

      for (int ctr = 2; ctr <= 8; ctr++)
      {
         string fmt = new String('d', ctr) + @"\.hh\:mm\:ss";
         Console.WriteLine($"{fmt} --> {1:" + fmt + "}");
         Console.WriteLine($"{fmt} --> {1:" + fmt + "}");
         Console.WriteLine();
      }
      // The example displays the following output:
      //       dd\.hh\:mm\:ss --> 00.23:17:47
      //       dd\.hh\:mm\:ss --> 365.21:19:45
      //
      //       ddd\.hh\:mm\:ss --> 000.23:17:47
      //       ddd\.hh\:mm\:ss --> 365.21:19:45
      //
      //       dddd\.hh\:mm\:ss --> 0000.23:17:47
      //       dddd\.hh\:mm\:ss --> 0365.21:19:45
      //
      //       ddddd\.hh\:mm\:ss --> 00000.23:17:47
      //       ddddd\.hh\:mm\:ss --> 00365.21:19:45
      //
      //       dddddd\.hh\:mm\:ss --> 000000.23:17:47
      //       dddddd\.hh\:mm\:ss --> 000365.21:19:45
      //
      //       ddddddd\.hh\:mm\:ss --> 0000000.23:17:47
      //       ddddddd\.hh\:mm\:ss --> 0000365.21:19:45
      //
      //       dddddddd\.hh\:mm\:ss --> 00000000.23:17:47
      //       dddddddd\.hh\:mm\:ss --> 00000365.21:19:45
      // </Snippet5>
   }

   private static void hSpecifier()
   {
      // <Snippet6>
      TimeSpan ts = new TimeSpan(3, 42, 0);
      Console.WriteLine($"{0:%h} hours {0:%m} minutes");
      // The example displays the following output:
      //       3 hours 42 minutes
      // </Snippet6>

      // <Snippet7>
      TimeSpan ts1 = new TimeSpan(14, 3, 17);
      Console.WriteLine(ts1.ToString(@"d\.h\:mm\:ss"));

      TimeSpan ts2 = new TimeSpan(3, 4, 3, 17);
      Console.WriteLine(ts2.ToString(@"d\.h\:mm\:ss"));
      // The example displays the following output:
      //       0.14:03:17
      //       3.4:03:17
      // </Snippet7>
   }

   private static void ParseH()
   {
      // <Snippet8>
      string value = "8";
      TimeSpan interval;
      if (TimeSpan.TryParseExact(value, "%h", null, out interval))
         Console.WriteLine(interval.ToString("c"));
      else
         Console.WriteLine($"Unable to convert '{value}' to a time interval");
      // The example displays the following output:
      //       08:00:00
      // </Snippet8>
   }

   private static void ParseHH()
   {
      // <Snippet9>
      string value = "08";
      TimeSpan interval;
      if (TimeSpan.TryParseExact(value, "hh", null, out interval))
         Console.WriteLine(interval.ToString("c"));
      else
         Console.WriteLine($"Unable to convert '{value}' to a time interval");
      // The example displays the following output:
      //       08:00:00
      // </Snippet9>
   }

   private static void hhSpecifier()
   {
      // <Snippet10>
      TimeSpan ts1 = new TimeSpan(14, 3, 17);
      Console.WriteLine(ts1.ToString(@"d\.hh\:mm\:ss"));

      TimeSpan ts2 = new TimeSpan(3, 4, 3, 17);
      Console.WriteLine(ts2.ToString(@"d\.hh\:mm\:ss"));
      // The example displays the following output:
      //       0.14:03:17
      //       3.04:03:17
      // </Snippet10>
   }

   private static void ParseM()
   {
      // <Snippet11>
      string value = "3";
      TimeSpan interval;
      if (TimeSpan.TryParseExact(value, "%m", null, out interval))
         Console.WriteLine(interval.ToString("c"));
      else
         Console.WriteLine($"Unable to convert '{value}' to a time interval");
      // The example displays the following output:
      //       00:03:00
      // </Snippet11>
   }

   private static void mSpecifier()
   {
      // <Snippet12>
      TimeSpan ts1 = new TimeSpan(0, 6, 32);
      Console.WriteLine($"{0:m\\:ss} minutes");

      TimeSpan ts2 = new TimeSpan(3, 4, 3, 17);
      Console.WriteLine($"Elapsed time: {0:m\\:ss}");
      // The example displays the following output:
      //       6:32 minutes
      //       Elapsed time: 18:44
      // </Snippet12>
   }

   private static void ParseMM()
   {
      // <Snippet13>
      string value = "07";
      TimeSpan interval;
      if (TimeSpan.TryParseExact(value, "mm", null, out interval))
         Console.WriteLine(interval.ToString("c"));
      else
         Console.WriteLine($"Unable to convert '{value}' to a time interval");
      // The example displays the following output:
      //       00:07:00
      // </Snippet13>
   }

   private static void mmSpecifier()
   {
      // <Snippet14>
      TimeSpan departTime = new TimeSpan(11, 12, 00);
      TimeSpan arriveTime = new TimeSpan(16, 28, 00);
      Console.WriteLine($"Travel time: {0:hh\\:mm}");
      // The example displays the following output:
      //       Travel time: 05:16
      // </Snippet14>
   }

   private static void sSpecifier()
   {
      // <Snippet15>
      TimeSpan ts = TimeSpan.FromSeconds(12.465);
      Console.WriteLine(ts.ToString("%s"));
      // The example displays the following output:
      //       12
      // </Snippet15>
      Console.WriteLine();

      // <Snippet16>
      TimeSpan startTime = new TimeSpan(0, 12, 30, 15, 0);
      TimeSpan endTime = new TimeSpan(0, 12, 30, 21, 3);
      Console.WriteLine(@"Elapsed Time: {0:s\:fff} seconds",
                        endTime - startTime);
      // The example displays the following output:
      //       Elapsed Time: 6:003 seconds
      // </Snippet16>
   }

   private static void ParseS()
   {
      // <Snippet17>
      string value = "9";
      TimeSpan interval;
      if (TimeSpan.TryParseExact(value, "%s", null, out interval))
         Console.WriteLine(interval.ToString("c"));
      else
         Console.WriteLine($"Unable to convert '{value}' to a time interval");
      // The example displays the following output:
      //       00:00:09
      // </Snippet17>
   }

   private static void ParseSS()
   {
      // <Snippet18>
      string[] values = { "49", "9", "06" };
      TimeSpan interval;
      foreach (string value in values)
      {
         if (TimeSpan.TryParseExact(value, "ss", null, out interval))
            Console.WriteLine(interval.ToString("c"));
         else
            Console.WriteLine($"Unable to convert '{value}' to a time interval");
      }
      // The example displays the following output:
      //       00:00:49
      //       Unable to convert '9' to a time interval
      //       00:00:06
      // </Snippet18>
   }

   private static void ssSpecifier()
   {
      // <Snippet19>
      TimeSpan interval1 = TimeSpan.FromSeconds(12.60);
      Console.WriteLine(interval1.ToString(@"ss\.fff"));

      TimeSpan interval2 = TimeSpan.FromSeconds(6.485);
      Console.WriteLine(interval2.ToString(@"ss\.fff"));
      // The example displays the following output:
      //       12.600
      //       06.485
      // </Snippet19>
   }
}
