// <Snippet4>
using System;
using System.Globalization;

public class ParseDateExample
{
   public static void Main()
   {
      string dateString;
      CultureInfo culture ;
      DateTimeStyles styles;
      DateTime result;
      
      // Parse a date and time with no styles.
      dateString = "03/01/2009 10:00 AM";
      culture = CultureInfo.CreateSpecificCulture("en-US");
      styles = DateTimeStyles.None;
      try {
         result = DateTime.Parse(dateString, culture, styles);
         Console.WriteLine("{0} converted to {1} {2}.", 
                           dateString, result, result.Kind.ToString());
      }
      catch (FormatException) {
         Console.WriteLine("Unable to convert {0} to a date and time.", 
                           dateString);
      }      
      
      // Parse the same date and time with the AssumeLocal style.
      styles = DateTimeStyles.AssumeLocal;
      try {
         result = DateTime.Parse(dateString, culture, styles);
         Console.WriteLine("{0} converted to {1} {2}.", 
                           dateString, result, result.Kind.ToString());
      }
      catch (FormatException) {
         Console.WriteLine("Unable to convert {0} to a date and time.", dateString);
      }      
      
      // Parse a date and time that is assumed to be local.
      // This time is five hours behind UTC. The local system's time zone is 
      // eight hours behind UTC.
      dateString = "2009/03/01T10:00:00-5:00";
      styles = DateTimeStyles.AssumeLocal;
      try {
         result = DateTime.Parse(dateString, culture, styles);
         Console.WriteLine("{0} converted to {1} {2}.", 
                           dateString, result, result.Kind.ToString());
      }
      catch (FormatException) {
         Console.WriteLine("Unable to convert {0} to a date and time.", dateString);
      }      
      
      // Attempt to convert a string in improper ISO 8601 format.
      dateString = "03/01/2009T10:00:00-5:00";
      try {
         result = DateTime.Parse(dateString, culture, styles);
         Console.WriteLine("{0} converted to {1} {2}.", 
                           dateString, result, result.Kind.ToString());
      }                     
      catch (FormatException) {
         Console.WriteLine("Unable to convert {0} to a date and time.", dateString);
      }      

      // Assume a date and time string formatted for the fr-FR culture is the local 
      // time and convert it to UTC.
      dateString = "2008-03-01 10:00";
      culture = CultureInfo.CreateSpecificCulture("fr-FR");
      styles = DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeLocal;
      try {
         result = DateTime.Parse(dateString, culture, styles);
         Console.WriteLine("{0} converted to {1} {2}.", 
                           dateString, result, result.Kind.ToString());
      }
      catch (FormatException) {
         Console.WriteLine("Unable to convert {0} to a date and time.", dateString);
      }      
   }
}
// The example displays the following output to the console:
//       03/01/2009 10:00 AM converted to 3/1/2009 10:00:00 AM Unspecified.
//       03/01/2009 10:00 AM converted to 3/1/2009 10:00:00 AM Local.
//       2009/03/01T10:00:00-5:00 converted to 3/1/2009 7:00:00 AM Local.
//       Unable to convert 03/01/2009T10:00:00-5:00 to a date and time.
//       2008-03-01 10:00 converted to 3/1/2008 6:00:00 PM Utc.
// </Snippet4>
