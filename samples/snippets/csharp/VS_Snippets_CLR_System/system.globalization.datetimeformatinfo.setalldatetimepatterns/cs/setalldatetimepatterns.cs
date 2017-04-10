// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      // Use standard en-US culture.
      CultureInfo enUS = new CultureInfo("en-US");
      
      string[] values = { "December 2010", "December, 2010",  
                          "Dec-2010", "December-2010" }; 
      
      Console.WriteLine("Supported Y/y patterns for {0} culture:", enUS.Name);
      foreach (var pattern in enUS.DateTimeFormat.GetAllDateTimePatterns('Y'))
         Console.WriteLine("   " + pattern);

      Console.WriteLine();
      
      // Try to parse each date string using "Y" format specifier.
      foreach (var value in values) {
         try {
            DateTime dat = DateTime.ParseExact(value, "Y", enUS);
            Console.WriteLine(String.Format(enUS, "   Parsed {0} as {1:Y}", value, dat));
         }
         catch (FormatException) {
            Console.WriteLine("   Cannot parse {0}", value);
         }   
      }   
      Console.WriteLine();
      
      //Modify supported "Y" format.
      enUS.DateTimeFormat.SetAllDateTimePatterns( new string[] { "MMM-yyyy" } , 'Y');
      
      Console.WriteLine("New supported Y/y patterns for {0} culture:", enUS.Name);
      foreach (var pattern in enUS.DateTimeFormat.GetAllDateTimePatterns('Y'))
         Console.WriteLine("   " + pattern);

      Console.WriteLine();

      // Try to parse each date string using "Y" format specifier.
      foreach (var value in values) {
         try {
            DateTime dat = DateTime.ParseExact(value, "Y", enUS);
            Console.WriteLine(String.Format(enUS, "   Parsed {0} as {1:Y}", value, dat));
         }
         catch (FormatException) {
            Console.WriteLine("   Cannot parse {0}", value);
         }   
      }   
   }
}
// The example displays the following output:
//       Supported Y/y patterns for en-US culture:
//          MMMM, yyyy
//       
//          Cannot parse December 2010
//          Parsed December, 2010 as December, 2010
//          Cannot parse Dec-2010
//          Cannot parse December-2010
//       
//       New supported Y/y patterns for en-US culture:
//          MMM-yyyy
//       
//          Cannot parse December 2010
//          Cannot parse December, 2010
//          Parsed Dec-2010 as Dec-2010
//          Cannot parse December-2010
// </Snippet1>