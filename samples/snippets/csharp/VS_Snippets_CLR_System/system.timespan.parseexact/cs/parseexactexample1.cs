// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string intervalString, format;
      TimeSpan interval;
      CultureInfo culture;
      
      // Parse hour:minute value with "g" specifier current culture.
      intervalString = "17:14";
      format = "g";
      culture = CultureInfo.CurrentCulture;
      try {
         interval = TimeSpan.ParseExact(intervalString, format, culture);
         Console.WriteLine("'{0}' --> {1}", intervalString, interval);
      }
      catch (FormatException) {
         Console.WriteLine("'{0}': Bad Format for '{1}'", 
                           intervalString, format);
      }                     
      catch (OverflowException) {
         Console.WriteLine("'{0}': Overflow", intervalString);
      }      
      
      // Parse hour:minute:second value with "G" specifier.
      intervalString = "17:14:48";
      format = "G";
      culture = CultureInfo.InvariantCulture;
      try {
         interval = TimeSpan.ParseExact(intervalString, format, culture);
         Console.WriteLine("'{0}' --> {1}", intervalString, interval);
      }
      catch (FormatException) {
         Console.WriteLine("'{0}': Bad Format for '{1}'", intervalString, format);
      }   
      catch (OverflowException) {
         Console.WriteLine("'{0}': Overflow", intervalString);
      } 
      
      // Parse hours:minute.second value with "G" specifier 
      // and current (en-US) culture.     
      intervalString = "17:14:48.153";
      format = "G";
      culture = CultureInfo.CurrentCulture;
      try {
         interval = TimeSpan.ParseExact(intervalString, format, culture);
         Console.WriteLine("'{0}' --> {1}", intervalString, interval);
      }   
      catch (FormatException) {
         Console.WriteLine("'{0}': Bad Format for '{1}'", intervalString, format);
      }
      catch (OverflowException) {
         Console.WriteLine("'{0}': Overflow", intervalString);
      } 

      // Parse days:hours:minute.second value with "G" specifier 
      // and current (en-US) culture.     
      intervalString = "3:17:14:48.153";
      format = "G";
      culture = CultureInfo.CurrentCulture;
      try {
         interval = TimeSpan.ParseExact(intervalString, format, culture);
         Console.WriteLine("'{0}' --> {1}", intervalString, interval);
      }   
      catch (FormatException) {
         Console.WriteLine("'{0}': Bad Format for '{1}'", intervalString, format);
      }   
      catch (OverflowException) {
         Console.WriteLine("'{0}': Overflow", intervalString);
      } 
            
      // Parse days:hours:minute.second value with "G" specifier 
      // and fr-FR culture.     
      intervalString = "3:17:14:48.153";
      format = "G";
      culture = new CultureInfo("fr-FR");
      try {
         interval = TimeSpan.ParseExact(intervalString, format, culture);
         Console.WriteLine("'{0}' --> {1}", intervalString, interval);
      }
      catch (FormatException) {
         Console.WriteLine("'{0}': Bad Format for '{1}'", intervalString, format);
      }
      catch (OverflowException) {
         Console.WriteLine("'{0}': Overflow", intervalString);
      } 
      
      // Parse days:hours:minute.second value with "G" specifier 
      // and fr-FR culture.     
      intervalString = "3:17:14:48,153";
      format = "G";
      try {
         interval = TimeSpan.ParseExact(intervalString, format, culture);
         Console.WriteLine("'{0}' --> {1}", intervalString, interval);
      }   
      catch (FormatException) {
         Console.WriteLine("'{0}': Bad Format for '{1}'", intervalString, format);
      }
      catch (OverflowException) {
         Console.WriteLine("'{0}': Overflow", intervalString);
      } 

      // Parse a single number using the "c" standard format string. 
      intervalString = "12";
      format = "c";
      try {
         interval = TimeSpan.ParseExact(intervalString, format, null);
         Console.WriteLine("'{0}' --> {1}", intervalString, interval);
      }
      catch (FormatException) {
         Console.WriteLine("'{0}': Bad Format for '{1}'", intervalString, format);
      }
      catch (OverflowException) {
         Console.WriteLine("'{0}': Overflow", intervalString);
      } 
      
      // Parse a single number using the "%h" custom format string. 
      format = "%h";
      try {
         interval = TimeSpan.ParseExact(intervalString, format, null);
         Console.WriteLine("'{0}' --> {1}", intervalString, interval);
      }
      catch (FormatException) {
         Console.WriteLine("'{0}': Bad Format for '{1}'", intervalString, format);
      }
      catch (OverflowException) {
         Console.WriteLine("'{0}': Overflow", intervalString);
      } 
      
      // Parse a single number using the "%s" custom format string. 
      format = "%s";
      try {
         interval = TimeSpan.ParseExact(intervalString, format, null);
         Console.WriteLine("'{0}' --> {1}", intervalString, interval);
      }
      catch (FormatException) {
         Console.WriteLine("'{0}': Bad Format for '{1}'", intervalString, format);
      }
      catch (OverflowException) {
         Console.WriteLine("'{0}': Overflow", intervalString);
      }
   }
}
// The example displays the following output:
//       '17:14' --> 17:14:00
//       '17:14:48': Bad Format for 'G'
//       '17:14:48.153': Bad Format for 'G'
//       '3:17:14:48.153' --> 3.17:14:48.1530000
//       '3:17:14:48.153': Bad Format for 'G'
//       '3:17:14:48,153' --> 3.17:14:48.1530000
//       '12' --> 12.00:00:00
//       '12' --> 12:00:00
//       '12' --> 00:00:12
// </Snippet1>
