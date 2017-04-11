// <Snippet2>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string[] formats= {"M/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm tt", 
                         "MM/dd/yyyy hh:mm:ss", "M/d/yyyy h:mm:ss", 
                         "M/d/yyyy hh:mm tt", "M/d/yyyy hh tt", 
                         "M/d/yyyy h:mm", "M/d/yyyy h:mm", 
                         "MM/dd/yyyy hh:mm", "M/dd/yyyy hh:mm"};
      string[] dateStrings = {"5/1/2009 6:32 PM", "05/01/2009 6:32:05 PM", 
                              "5/1/2009 6:32:00", "05/01/2009 06:32", 
                              "05/01/2009 06:32:00 PM", "05/01/2009 06:32:00"}; 
      DateTime dateValue;
      
      foreach (string dateString in dateStrings)
      {
         if (DateTime.TryParseExact(dateString, formats, 
                                    new CultureInfo("en-US"), 
                                    DateTimeStyles.None, 
                                    out dateValue))
            Console.WriteLine("Converted '{0}' to {1}.", dateString, dateValue);
         else
            Console.WriteLine("Unable to convert '{0}' to a date.", dateString);
      }
   }
}
// The example displays the following output:
//       Converted '5/1/2009 6:32 PM' to 5/1/2009 6:32:00 PM.
//       Converted '05/01/2009 6:32:05 PM' to 5/1/2009 6:32:05 PM.
//       Converted '5/1/2009 6:32:00' to 5/1/2009 6:32:00 AM.
//       Converted '05/01/2009 06:32' to 5/1/2009 6:32:00 AM.
//       Converted '05/01/2009 06:32:00 PM' to 5/1/2009 6:32:00 PM.
//       Converted '05/01/2009 06:32:00' to 5/1/2009 6:32:00 AM.
// </Snippet2>
