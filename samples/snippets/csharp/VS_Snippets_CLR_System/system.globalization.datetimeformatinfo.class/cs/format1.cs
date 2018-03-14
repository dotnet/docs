// <Snippet5>
using System;
using System.Globalization;
using System.Reflection;

public class Example
{
   public static void Main()
   {
      // Get the properties of an en-US DateTimeFormatInfo object.
      DateTimeFormatInfo dtfi = CultureInfo.GetCultureInfo("en-US").DateTimeFormat;
      Type typ = dtfi.GetType();
      PropertyInfo[] props = typ.GetProperties();
      DateTime value = new DateTime(2012, 5, 28, 11, 35, 0); 
      
      foreach (var prop in props) {
         // Is this a format pattern-related property?
         if (prop.Name.Contains("Pattern")) {
            string fmt = prop.GetValue(dtfi, null).ToString();
            Console.WriteLine("{0,-33} {1} \n{2,-37}Example: {3}\n", 
                              prop.Name + ":", fmt, "",
                              value.ToString(fmt)); 
         }
      }
   }
}
// The example displays the following output:
//    FullDateTimePattern:              dddd, MMMM dd, yyyy h:mm:ss tt
//                                         Example: Monday, May 28, 2012 11:35:00 AM
//    
//    LongDatePattern:                  dddd, MMMM dd, yyyy
//                                         Example: Monday, May 28, 2012
//    
//    LongTimePattern:                  h:mm:ss tt
//                                         Example: 11:35:00 AM
//    
//    MonthDayPattern:                  MMMM dd
//                                         Example: May 28
//    
//    RFC1123Pattern:                   ddd, dd MMM yyyy HH':'mm':'ss 'GMT'
//                                         Example: Mon, 28 May 2012 11:35:00 GMT
//    
//    ShortDatePattern:                 M/d/yyyy
//                                         Example: 5/28/2012
//    
//    ShortTimePattern:                 h:mm tt
//                                         Example: 11:35 AM
//    
//    SortableDateTimePattern:          yyyy'-'MM'-'dd'T'HH':'mm':'ss
//                                         Example: 2012-05-28T11:35:00
//    
//    UniversalSortableDateTimePattern: yyyy'-'MM'-'dd HH':'mm':'ss'Z'
//                                         Example: 2012-05-28 11:35:00Z
//    
//    YearMonthPattern:                 MMMM, yyyy
//                                         Example: May, 2012
// </Snippet5>
