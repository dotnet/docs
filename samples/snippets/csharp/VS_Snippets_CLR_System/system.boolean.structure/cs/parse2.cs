// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      string[] values = { null, String.Empty, "True", "False", 
                          "true", "false", "    true    ", 
                           "TrUe", "fAlSe", "fa lse", "0",  
                          "1", "-1", "string" };
      // Parse strings using the Boolean.Parse method.                    
      foreach (var value in values) {
         try {
            bool flag = Boolean.Parse(value);
            Console.WriteLine("'{0}' --> {1}", value, flag);
         }
         catch (ArgumentException) {
            Console.WriteLine("Cannot parse a null string.");
         }   
         catch (FormatException) {
            Console.WriteLine("Cannot parse '{0}'.", value);
         }         
      }
      Console.WriteLine();
      // Parse strings using the Boolean.TryParse method.                    
      foreach (var value in values) {
         bool flag = false;
         if (Boolean.TryParse(value, out flag))
            Console.WriteLine("'{0}' --> {1}", value, flag);
         else
            Console.WriteLine("Unable to parse '{0}'", value);
      }                                     
   }
}
// The example displays the following output:
//       Cannot parse a null string.
//       Cannot parse ''.
//       'True' --> True
//       'False' --> False
//       'true' --> True
//       'false' --> False
//       '    true    ' --> True
//       'TrUe' --> True
//       'fAlSe' --> False
//       Cannot parse 'fa lse'.
//       Cannot parse '0'.
//       Cannot parse '1'.
//       Cannot parse '-1'.
//       Cannot parse 'string'.
//       
//       Unable to parse ''
//       Unable to parse ''
//       'True' --> True
//       'False' --> False
//       'true' --> True
//       'false' --> False
//       '    true    ' --> True
//       'TrUe' --> True
//       'fAlSe' --> False
//       Cannot parse 'fa lse'.
//       Unable to parse '0'
//       Unable to parse '1'
//       Unable to parse '-1'
//       Unable to parse 'string'
// </Snippet2>
