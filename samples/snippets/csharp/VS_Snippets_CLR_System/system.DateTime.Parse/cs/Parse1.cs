// <Snippet1>
using System;
using System.Globalization;

public class DateTimeParser
{
   public static void Main()
   {
      // Assume the current culture is en-US. 
      // The date is February 16, 2008, 12 hours, 15 minutes and 12 seconds.

      // Use standard en-US date and time value
      DateTime dateValue;
      string dateString = "2/16/2008 12:15:12 PM";
      try {
         dateValue = DateTime.Parse(dateString);
         Console.WriteLine("'{0}' converted to {1}.", dateString, dateValue);
      }   
      catch (FormatException) {
         Console.WriteLine("Unable to convert '{0}'.", dateString);
      }
            
      // Reverse month and day to conform to the fr-FR culture.
      // The date is February 16, 2008, 12 hours, 15 minutes and 12 seconds.
      dateString = "16/02/2008 12:15:12";
      try {
         dateValue = DateTime.Parse(dateString);
         Console.WriteLine("'{0}' converted to {1}.", dateString, dateValue);
      }   
      catch (FormatException) {
         Console.WriteLine("Unable to convert '{0}'.", dateString);
      }

      // Call another overload of Parse to successfully convert string
      // formatted according to conventions of fr-FR culture.      
      try {
         dateValue = DateTime.Parse(dateString, new CultureInfo("fr-FR", false));
         Console.WriteLine("'{0}' converted to {1}.", dateString, dateValue);
      }   
      catch (FormatException) {
         Console.WriteLine("Unable to convert '{0}'.", dateString);
      }
      
      // Parse string with date but no time component.
      dateString = "2/16/2008";
      try {
         dateValue = DateTime.Parse(dateString);
         Console.WriteLine("'{0}' converted to {1}.", dateString, dateValue);
      }   
      catch (FormatException) {
         Console.WriteLine("Unable to convert '{0}'.", dateString);
      }   
   }
}
// The example displays the following output to the console:
//       '2/16/2008 12:15:12 PM' converted to 2/16/2008 12:15:12 PM.
//       Unable to convert '16/02/2008 12:15:12'.
//       '16/02/2008 12:15:12' converted to 2/16/2008 12:15:12 PM.
//       '2/16/2008' converted to 2/16/2008 12:00:00 AM.
// </Snippet1>
