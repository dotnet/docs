using System;
using System.Globalization;
using System.IO;

public class Class1
{
   public static void Main()
   {
      TryParseExact1(); 
      Console.WriteLine();
      TryParseExact2();
   }

   private static void TryParseExact1()
   {
      // <Snippet1>
      string dateString, format;  
      DateTimeOffset result;
      IFormatProvider provider = CultureInfo.InvariantCulture;
      
      // Parse date-only value with invariant culture and assume time is UTC.
      dateString = "06/15/2008";
      format = "d";
      if (DateTimeOffset.TryParseExact(dateString, format, provider, 
                                       DateTimeStyles.AssumeUniversal, 
                                       out result))
         Console.WriteLine("'{0}' converts to {1}.", dateString, result.ToString());
      else
         Console.WriteLine("'{0}' is not in the correct format.", dateString);
      
      // Parse date-only value with leading white space.
      // Should return False because only trailing whitespace is  
      // specified in method call.
      dateString = " 06/15/2008";
      if (DateTimeOffset.TryParseExact(dateString, format, provider, 
                                       DateTimeStyles.AllowTrailingWhite, 
                                       out result))
         Console.WriteLine("'{0}' converts to {1}.", dateString, result.ToString());
      else
         Console.WriteLine("'{0}' is not in the correct format.", dateString);

      // Parse date and time value, and allow all white space.
      dateString = " 06/15/   2008  15:15    -05:00";
      format = "MM/dd/yyyy H:mm zzz";
      if (DateTimeOffset.TryParseExact(dateString, format, provider, 
                                       DateTimeStyles.AllowWhiteSpaces, 
                                       out result))
         Console.WriteLine("'{0}' converts to {1}.", dateString, result.ToString());
      else
         Console.WriteLine("'{0}' is not in the correct format.", dateString);
      
      // Parse date and time and convert to UTC.
      dateString = "  06/15/2008 15:15:30 -05:00";   
      format = "MM/dd/yyyy H:mm:ss zzz";       
      if (DateTimeOffset.TryParseExact(dateString, format, provider, 
                                      DateTimeStyles.AllowWhiteSpaces | 
                                      DateTimeStyles.AdjustToUniversal, 
                                      out result))
         Console.WriteLine("'{0}' converts to {1}.", dateString, result.ToString());
      else
         Console.WriteLine("'{0}' is not in the correct format.", dateString);
      // The example displays the following output:
      //    '06/15/2008' converts to 6/15/2008 12:00:00 AM +00:00.
      //    ' 06/15/2008' is not in the correct format.
      //    ' 06/15/   2008  15:15    -05:00' converts to 6/15/2008 3:15:00 PM -05:00.
      //    '  06/15/2008 15:15:30 -05:00' converts to 6/15/2008 8:15:30 PM +00:00.
      // </Snippet1>
   }   

   private static void TryParseExact2()
   {
      // <Snippet2>
      TextReader conIn = Console.In;
      TextWriter conOut = Console.Out;
      int tries = 0;
      string input = String.Empty;

      string[] formats = new string[] {"M/dd/yyyy HH:m zzz", "MM/dd/yyyy HH:m zzz", 
                                       "M/d/yyyy HH:m zzz", "MM/d/yyyy HH:m zzz", 
                                       "M/dd/yy HH:m zzz", "MM/dd/yy HH:m zzz", 
                                       "M/d/yy HH:m zzz", "MM/d/yy HH:m zzz",                                 
                                       "M/dd/yyyy H:m zzz", "MM/dd/yyyy H:m zzz", 
                                       "M/d/yyyy H:m zzz", "MM/d/yyyy H:m zzz", 
                                       "M/dd/yy H:m zzz", "MM/dd/yy H:m zzz", 
                                       "M/d/yy H:m zzz", "MM/d/yy H:m zzz",                               
                                       "M/dd/yyyy HH:mm zzz", "MM/dd/yyyy HH:mm zzz", 
                                       "M/d/yyyy HH:mm zzz", "MM/d/yyyy HH:mm zzz", 
                                       "M/dd/yy HH:mm zzz", "MM/dd/yy HH:mm zzz", 
                                       "M/d/yy HH:mm zzz", "MM/d/yy HH:mm zzz",                                 
                                       "M/dd/yyyy H:mm zzz", "MM/dd/yyyy H:mm zzz", 
                                       "M/d/yyyy H:mm zzz", "MM/d/yyyy H:mm zzz", 
                                       "M/dd/yy H:mm zzz", "MM/dd/yy H:mm zzz", 
                                       "M/d/yy H:mm zzz", "MM/d/yy H:mm zzz"};   
      IFormatProvider provider = CultureInfo.InvariantCulture.DateTimeFormat;
      DateTimeOffset result;
     
      do {
         conOut.WriteLine("Enter a date, time, and offset (MM/DD/YYYY HH:MM +/-HH:MM),");
         conOut.Write("Then press Enter: ");
         input = conIn.ReadLine();
         conOut.WriteLine(); 
         if (DateTimeOffset.TryParseExact(input, formats, provider, 
                                         DateTimeStyles.AllowWhiteSpaces, 
                                         out result))
         {                                          
            break;
         }
         else
         {  
            Console.WriteLine("Unable to parse {0}.", input);      
            tries++;
         }
      } while (tries < 3);
      if (tries >= 3)
         Console.WriteLine("Exiting application without parsing {0}", input);
      else
         Console.WriteLine("{0} was converted to {1}", input, result.ToString());                                                     
      // Some successful sample interactions with the user might appear as follows:
      //    Enter a date, time, and offset (MM/DD/YYYY HH:MM +/-HH:MM),
      //    Then press Enter: 12/08/2007 6:54 -6:00
      //    
      //    12/08/2007 6:54 -6:00 was converted to 12/8/2007 6:54:00 AM -06:00         
      //    
      //    Enter a date, time, and offset (MM/DD/YYYY HH:MM +/-HH:MM),
      //    Then press Enter: 12/8/2007 06:54 -06:00
      //    
      //    12/8/2007 06:54 -06:00 was converted to 12/8/2007 6:54:00 AM -06:00
      //    
      //    Enter a date, time, and offset (MM/DD/YYYY HH:MM +/-HH:MM),
      //    Then press Enter: 12/5/07 6:54 -6:00
      //    
      //    12/5/07 6:54 -6:00 was converted to 12/5/2007 6:54:00 AM -06:00 
      // </Snippet2>
   }
}
