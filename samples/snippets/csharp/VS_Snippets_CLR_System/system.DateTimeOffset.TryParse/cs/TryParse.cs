using System;
using System.Globalization;

public class Class1
{
   public static void Main()
   {
      TryParse1();
      Console.WriteLine();
      TryParse2();      
   }

   private static void TryParse1()
   {
      // <Snippet1>
      DateTimeOffset parsedDate;
      string dateString;
      
      // String with date only
      dateString = "05/01/2008";
      if (DateTimeOffset.TryParse(dateString, out parsedDate))
         Console.WriteLine("{0} was converted to to {1}.", 
                           dateString, parsedDate);

      // String with time only
      dateString = "11:36 PM";
      if (DateTimeOffset.TryParse(dateString, out parsedDate))
         Console.WriteLine("{0} was converted to to {1}.", 
                           dateString, parsedDate);

      // String with date and offset 
      dateString = "05/01/2008 +7:00";
      if (DateTimeOffset.TryParse(dateString, out parsedDate))
         Console.WriteLine("{0} was converted to to {1}.", 
                           dateString, parsedDate);

      // String with day abbreviation
      dateString = "Thu May 01, 2008";
      if (DateTimeOffset.TryParse(dateString, out parsedDate))
         Console.WriteLine("{0} was converted to to {1}.", 
                           dateString, parsedDate);

      // String with date, time with AM/PM designator, and offset
      dateString = "5/1/2008 10:00 AM -07:00";
      if (DateTimeOffset.TryParse(dateString, out parsedDate))
         Console.WriteLine("{0} was converted to to {1}.", 
                           dateString, parsedDate);
      // if (run on 3/29/07, the example displays the following output
      // to the console:
      //    05/01/2008 was converted to to 5/1/2008 12:00:00 AM -07:00.
      //    11:36 PM was converted to to 3/29/2007 11:36:00 PM -07:00.
      //    05/01/2008 +7:00 was converted to to 5/1/2008 12:00:00 AM +07:00.
      //    Thu May 01, 2008 was converted to to 5/1/2008 12:00:00 AM -07:00.
      //    5/1/2008 10:00 AM -07:00 was converted to to 5/1/2008 10:00:00 AM -07:00.                                 
      // </Snippet1>
   }

   private static void TryParse2()
   {
      // <Snippet2>
      string dateString;
      DateTimeOffset parsedDate;

      dateString = "05/01/2008 6:00:00";
      // Assume time is local 
      if (DateTimeOffset.TryParse(dateString, null as IFormatProvider, 
                                  DateTimeStyles.AssumeLocal, 
                                  out parsedDate))
         Console.WriteLine("'{0}' was converted to to {1}.", 
                           dateString, parsedDate.ToString());
      else
         Console.WriteLine("Unable to parse '{0}'.", dateString);    
      
      // Assume time is UTC
      if (DateTimeOffset.TryParse(dateString, null as IFormatProvider, 
                                  DateTimeStyles.AssumeUniversal, 
                                  out parsedDate))
         Console.WriteLine("'{0}' was converted to to {1}.", 
                           dateString, parsedDate.ToString());
      else
         Console.WriteLine("Unable to parse '{0}'.", dateString);    

      // Parse and convert to UTC 
      dateString = "05/01/2008 6:00:00AM +5:00";
      if (DateTimeOffset.TryParse(dateString, null as IFormatProvider, 
                                 DateTimeStyles.AdjustToUniversal, 
                                 out parsedDate))
         Console.WriteLine("'{0}' was converted to to {1}.", 
                           dateString, parsedDate.ToString());
      else
         Console.WriteLine("Unable to parse '{0}'.", dateString);    
      // The example displays the following output to the console:
      //    '05/01/2008 6:00:00' was converted to to 5/1/2008 6:00:00 AM -07:00.
      //    '05/01/2008 6:00:00' was converted to to 5/1/2008 6:00:00 AM +00:00.
      //    '05/01/2008 6:00:00AM +5:00' was converted to to 5/1/2008 1:00:00 AM +00:00.      
      // </Snippet2>   
   }
}
