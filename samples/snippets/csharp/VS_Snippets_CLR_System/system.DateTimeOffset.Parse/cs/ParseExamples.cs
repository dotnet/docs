using System;
using System.Globalization;

public class Class1
{
   public static void Main()
   {
      ParseOverload1();
      ParseOverload2();
      ParseOverload3();
   }
   
   private static void ParseOverload1()
   {
      // <Snippet1>
      string dateString;
      DateTimeOffset offsetDate; 

      // String with date only
      dateString = "05/01/2008";
      offsetDate = DateTimeOffset.Parse(dateString);
      Console.WriteLine(offsetDate.ToString());

      // String with time only
      dateString = "11:36 PM";
      offsetDate = DateTimeOffset.Parse(dateString);
      Console.WriteLine(offsetDate.ToString());

      // String with date and offset 
      dateString = "05/01/2008 +1:00";
      offsetDate = DateTimeOffset.Parse(dateString);
      Console.WriteLine(offsetDate.ToString());

      // String with day abbreviation
      dateString = "Thu May 01, 2008";
      offsetDate = DateTimeOffset.Parse(dateString);
      Console.WriteLine(offsetDate.ToString());
      // </Snippet1>
   }

   private static void ParseOverload2()
   {
      // <Snippet2>   
      DateTimeFormatInfo fmt = new CultureInfo("fr-fr").DateTimeFormat;
      string dateString;
      DateTimeOffset offsetDate;
      
      dateString = "03-12-07";
      offsetDate = DateTimeOffset.Parse(dateString, fmt);
      Console.WriteLine("{0} returns {1}", 
                        dateString, 
                        offsetDate.ToString());
      
      dateString = "15/09/07 08:45:00 +1:00";
      offsetDate = DateTimeOffset.Parse(dateString, fmt);
      Console.WriteLine("{0} returns {1}", 
                        dateString, 
                        offsetDate.ToString());
      
      dateString = "mar. 1 janvier 2008 1:00:00 +1:00"; 
      offsetDate = DateTimeOffset.Parse(dateString, fmt);
      Console.WriteLine("{0} returns {1}", 
                        dateString, 
                        offsetDate.ToString());
      // The example displays the following output to the console:
      //    03-12-07 returns 12/3/2007 12:00:00 AM -08:00
      //    15/09/07 08:45:00 +1:00 returns 9/15/2007 8:45:00 AM +01:00
      //    mar. 1 janvier 2008 1:00:00 +1:00 returns 1/1/2008 1:00:00 AM +01:00                              
      // </Snippet2>         
   }

   private static void ParseOverload3()
   {
      // <Snippet3>
      string dateString;
      DateTimeOffset offsetDate;

      dateString = "05/01/2008 6:00:00";
      // Assume time is local 
      offsetDate = DateTimeOffset.Parse(dateString, null, DateTimeStyles.AssumeLocal);
      Console.WriteLine(offsetDate.ToString());   // Displays 5/1/2008 6:00:00 AM -07:00

      // Assume time is UTC
      offsetDate = DateTimeOffset.Parse(dateString, null, DateTimeStyles.AssumeUniversal);
      Console.WriteLine(offsetDate.ToString());   // Displays 5/1/2008 6:00:00 AM +00:00

      // Parse and convert to UTC 
      dateString = "05/01/2008 6:00:00AM +5:00";
      offsetDate = DateTimeOffset.Parse(dateString, null, DateTimeStyles.AdjustToUniversal);
      Console.WriteLine(offsetDate.ToString());   // Displays 5/1/2008 1:00:00 AM +00:00
      // </Snippet3>
   }
}
