// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CultureInfo enUS = new CultureInfo("en-US"); 
      string dateString;
      DateTime dateValue;
      
      // Parse date with no style flags.
      dateString = " 5/01/2009 8:30 AM";
      if (DateTime.TryParseExact(dateString, "g", enUS, 
                                 DateTimeStyles.None, out dateValue))
         Console.WriteLine("Converted '{0}' to {1} ({2}).", dateString, dateValue, 
                           dateValue.Kind);
      else
         Console.WriteLine("'{0}' is not in an acceptable format.", dateString);

      // Allow a leading space in the date string.
      if (DateTime.TryParseExact(dateString, "g", enUS, 
                                 DateTimeStyles.AllowLeadingWhite, out dateValue))
         Console.WriteLine("Converted '{0}' to {1} ({2}).", dateString, dateValue, 
                           dateValue.Kind);
      else
         Console.WriteLine("'{0}' is not in an acceptable format.", dateString);
      
      // Use custom formats with M and MM.
      dateString = "5/01/2009 09:00";
      if (DateTime.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS, 
                                 DateTimeStyles.None, out dateValue))
         Console.WriteLine("Converted '{0}' to {1} ({2}).", dateString, dateValue, 
                           dateValue.Kind);
      else
         Console.WriteLine("'{0}' is not in an acceptable format.", dateString);

      // Allow a leading space in the date string.
      if (DateTime.TryParseExact(dateString, "MM/dd/yyyy hh:mm", enUS, 
                              DateTimeStyles.None, out dateValue))
         Console.WriteLine("Converted '{0}' to {1} ({2}).", dateString, dateValue, 
                           dateValue.Kind);
      else
         Console.WriteLine("'{0}' is not in an acceptable format.", dateString);

      // Parse a string with time zone information.
      dateString = "05/01/2009 01:30:42 PM -05:00"; 
      if (DateTime.TryParseExact(dateString, "MM/dd/yyyy hh:mm:ss tt zzz", enUS, 
                              DateTimeStyles.None, out dateValue))
         Console.WriteLine("Converted '{0}' to {1} ({2}).", dateString, dateValue, 
                           dateValue.Kind);
      else
         Console.WriteLine("'{0}' is not in an acceptable format.", dateString);

      // Allow a leading space in the date string.
      if (DateTime.TryParseExact(dateString, "MM/dd/yyyy hh:mm:ss tt zzz", enUS, 
                              DateTimeStyles.AdjustToUniversal, out dateValue))
         Console.WriteLine("Converted '{0}' to {1} ({2}).", dateString, dateValue, 
                           dateValue.Kind);
      else
         Console.WriteLine("'{0}' is not in an acceptable format.", dateString);
           
      // Parse a string represengting UTC.
      dateString = "2008-06-11T16:11:20.0904778Z";
      if (DateTime.TryParseExact(dateString, "o", CultureInfo.InvariantCulture, 
                                     DateTimeStyles.None, out dateValue))
         Console.WriteLine("Converted '{0}' to {1} ({2}).", dateString, dateValue, 
                           dateValue.Kind);
      else
         Console.WriteLine("'{0}' is not in an acceptable format.", dateString);

      if (DateTime.TryParseExact(dateString, "o", CultureInfo.InvariantCulture, 
                                 DateTimeStyles.RoundtripKind, out dateValue))
         Console.WriteLine("Converted '{0}' to {1} ({2}).", dateString, dateValue, 
                           dateValue.Kind);
      else
         Console.WriteLine("'{0}' is not in an acceptable format.", dateString);

   }
}
// The example displays the following output:
//    ' 5/01/2009 8:30 AM' is not in an acceptable format.
//    Converted ' 5/01/2009 8:30 AM' to 5/1/2009 8:30:00 AM (Unspecified).
//    Converted '5/01/2009 09:00' to 5/1/2009 9:00:00 AM (Unspecified).
//    '5/01/2009 09:00' is not in an acceptable format.
//    Converted '05/01/2009 01:30:42 PM -05:00' to 5/1/2009 11:30:42 AM (Local).
//    Converted '05/01/2009 01:30:42 PM -05:00' to 5/1/2009 6:30:42 PM (Utc).
//    Converted '2008-06-11T16:11:20.0904778Z' to 6/11/2008 9:11:20 AM (Local).
//    Converted '2008-06-11T16:11:20.0904778Z' to 6/11/2008 4:11:20 PM (Utc).
// </Snippet1>
