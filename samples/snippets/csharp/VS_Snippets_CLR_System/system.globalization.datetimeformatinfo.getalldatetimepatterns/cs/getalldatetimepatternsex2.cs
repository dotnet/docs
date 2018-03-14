// <Snippet2>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CultureInfo culture = CultureInfo.CreateSpecificCulture("ru-RU");
      char[] formats = { 'd', 'D', 'f', 'F', 'g', 'G', 'm', 'o', 
                           'r', 's', 't', 'T', 'u', 'U', 'y' };
      DateTime date1 = new DateTime(2011, 02, 01, 7, 30, 45, 0);
      DateTime date2;
      int total = 0;
      int noRoundTrip = 0;

      foreach (var fmt in formats) {
         total = 0; 
         noRoundTrip = 0;
         foreach (var pattern in culture.DateTimeFormat.GetAllDateTimePatterns(fmt)) {
            total++;
            if (! DateTime.TryParse(date1.ToString(pattern), out date2)) {
               noRoundTrip++;
               Console.WriteLine("Unable to parse {0:" + pattern + "} (format '{1}')", 
                                 date1, pattern);
            }             
         }
         if (noRoundTrip > 0)
            Console.WriteLine("{0}: Unable to round-trip {1} of {2} format strings.\n",
                              fmt, noRoundTrip, total);
         else
            Console.WriteLine("{0}: All custom format strings round trip.\n", fmt);
      }
   }
}
// The example displays the following output:
//    d: All custom format strings round trip.
//    
//    Unable to parse 1 February 2011 г. (format 'd MMMM yyyy 'г.'')
//    Unable to parse 01 February 2011 г. (format 'dd MMMM yyyy 'г.'')
//    D: Unable to round-trip 2 of 2 format strings.
//    
//    Unable to parse 1 February 2011 г. 7:30 (format 'd MMMM yyyy 'г.' H:mm')
//    Unable to parse 1 February 2011 г. 07:30 (format 'd MMMM yyyy 'г.' HH:mm')
//    Unable to parse 01 February 2011 г. 7:30 (format 'dd MMMM yyyy 'г.' H:mm')
//    Unable to parse 01 February 2011 г. 07:30 (format 'dd MMMM yyyy 'г.' HH:mm')
//    f: Unable to round-trip 4 of 4 format strings.
//    
//    Unable to parse 1 February 2011 г. 7:30:45 (format 'd MMMM yyyy 'г.' H:mm:ss')
//    Unable to parse 1 February 2011 г. 07:30:45 (format 'd MMMM yyyy 'г.' HH:mm:ss')
//    Unable to parse 01 February 2011 г. 7:30:45 (format 'dd MMMM yyyy 'г.' H:mm:ss')
//    Unable to parse 01 February 2011 г. 07:30:45 (format 'dd MMMM yyyy 'г.' HH:mm:ss')
//    F: Unable to round-trip 4 of 4 format strings.
//    
//    g: All custom format strings round trip.
//    
//    G: All custom format strings round trip.
//    
//    m: All custom format strings round trip.
//    
//    o: All custom format strings round trip.
//    
//    r: All custom format strings round trip.
//    
//    s: All custom format strings round trip.
//    
//    t: All custom format strings round trip.
//    
//    T: All custom format strings round trip.
//    
//    u: All custom format strings round trip.
//    
//    Unable to parse 1 February 2011 г. 7:30:45 (format 'd MMMM yyyy 'г.' H:mm:ss')
//    Unable to parse 1 February 2011 г. 07:30:45 (format 'd MMMM yyyy 'г.' HH:mm:ss')
//    Unable to parse 01 February 2011 г. 7:30:45 (format 'dd MMMM yyyy 'г.' H:mm:ss')
//    Unable to parse 01 February 2011 г. 07:30:45 (format 'dd MMMM yyyy 'г.' HH:mm:ss')
//    U: Unable to round-trip 4 of 4 format strings.
//    
//    y: All custom format strings round trip.
// </Snippet2>
