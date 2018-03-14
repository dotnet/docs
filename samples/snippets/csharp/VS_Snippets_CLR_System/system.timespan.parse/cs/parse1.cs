// <Snippet1>
using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()
   {
      string[] values = { "6", "6:12", "6:12:14", "6:12:14:45", 
                          "6.12:14:45", "6:12:14:45.3448", 
                          "6:12:14:45,3448", "6:34:14:45" };
      string[] cultureNames = { "hr-HR", "en-US"};
      
      // Change the current culture.
      foreach (string cultureName in cultureNames)
      {
         Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);
         Console.WriteLine("Current Culture: {0}", 
                           Thread.CurrentThread.CurrentCulture.Name);
         foreach (string value in values)
         {
            try {
               TimeSpan ts = TimeSpan.Parse(value);
               Console.WriteLine("{0} --> {1}", value, ts.ToString("c"));
            }
            catch (FormatException) {
               Console.WriteLine("{0}: Bad Format", value);
            }   
            catch (OverflowException) {
               Console.WriteLine("{0}: Overflow", value);
            }
         } 
         Console.WriteLine();                                
      }
   }
}
// The example displays the following output:
//    Current Culture: hr-HR
//    6 --> 6.00:00:00
//    6:12 --> 06:12:00
//    6:12:14 --> 06:12:14
//    6:12:14:45 --> 6.12:14:45
//    6.12:14:45 --> 6.12:14:45
//    6:12:14:45.3448: Bad Format
//    6:12:14:45,3448 --> 6.12:14:45.3448000
//    6:34:14:45: Overflow
//    
//    Current Culture: en-US
//    6 --> 6.00:00:00
//    6:12 --> 06:12:00
//    6:12:14 --> 06:12:14
//    6:12:14:45 --> 6.12:14:45
//    6.12:14:45 --> 6.12:14:45
//    6:12:14:45.3448 --> 6.12:14:45.3448000
//    6:12:14:45,3448: Bad Format
//    6:34:14:45: Overflow
// </Snippet1>