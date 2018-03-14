// <Snippet1>
using System;

public class TryParse
{
   private static void ParseTimeSpan(string intervalStr)
   {
      // Write the first part of the output line.
      Console.Write( "{0,20}   ", intervalStr );

      // Parse the parameter, and then convert it back to a string.
      TimeSpan intervalVal; 
      if (TimeSpan.TryParse(intervalStr, out intervalVal)) 
      {
         string intervalToStr = intervalVal.ToString();
  
         // Pad the end of the TimeSpan string with spaces if it 
         // does not contain milliseconds.
         int pIndex = intervalToStr.IndexOf(':');
         pIndex = intervalToStr.IndexOf('.', pIndex);
         if (pIndex < 0)
            intervalToStr += "        ";
   
         Console.WriteLine("{0,21}", intervalToStr);
         // Handle failure of TryParse method.
      }
      else
      {
         Console.WriteLine("Parse operation failed.");
      }
   } 
   
   public static void Main()
   {
        Console.WriteLine( "{0,20}   {1,21}", 
            "String to Parse", "TimeSpan" );    
        Console.WriteLine( "{0,20}   {1,21}", 
            "---------------", "---------------------" );    

        ParseTimeSpan("0");
        ParseTimeSpan("14");
        ParseTimeSpan("1:2:3");
        ParseTimeSpan("0:0:0.250");
        ParseTimeSpan("10.20:30:40.50");
        ParseTimeSpan("99.23:59:59.9999999");
        ParseTimeSpan("0023:0059:0059.0099");
        ParseTimeSpan("23:0:0");
        ParseTimeSpan("24:0:0");
        ParseTimeSpan("0:59:0");
        ParseTimeSpan("0:60:0");
        ParseTimeSpan("0:0:59");
        ParseTimeSpan("0:0:60");
        ParseTimeSpan("10:");
        ParseTimeSpan("10:0");
        ParseTimeSpan(":10");
        ParseTimeSpan("0:10");
        ParseTimeSpan("10:20:");
        ParseTimeSpan("10:20:0");
        ParseTimeSpan(".123");
        ParseTimeSpan("0.12:00");
        ParseTimeSpan("10.");
        ParseTimeSpan("10.12");
        ParseTimeSpan("10.12:00");
   }
}
//            String to Parse                TimeSpan
//            ---------------   ---------------------
//                          0        00:00:00
//                         14     14.00:00:00
//                      1:2:3        01:02:03
//                  0:0:0.250        00:00:00.2500000
//             10.20:30:40.50     10.20:30:40.5000000
//        99.23:59:59.9999999     99.23:59:59.9999999
//        0023:0059:0059.0099        23:59:59.0099000
//                     23:0:0        23:00:00
//                     24:0:0   Parse operation failed.
//                     0:59:0        00:59:00
//                     0:60:0   Parse operation failed.
//                     0:0:59        00:00:59
//                     0:0:60   Parse operation failed.
//                        10:   Parse operation failed.
//                       10:0        10:00:00
//                        :10   Parse operation failed.
//                       0:10        00:10:00
//                     10:20:   Parse operation failed.
//                    10:20:0        10:20:00
//                       .123   Parse operation failed.
//                    0.12:00        12:00:00
//                        10.   Parse operation failed.
//                      10.12   Parse operation failed.
//                   10.12:00     10.12:00:00
// </Snippet1>
