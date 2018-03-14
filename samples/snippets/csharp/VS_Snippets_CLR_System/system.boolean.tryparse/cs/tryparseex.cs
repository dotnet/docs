// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      string[] values = { null, String.Empty, "True", "False", 
                          "true", "false", "    true    ", "0", 
                          "1", "-1", "string" };
      foreach (var value in values) {
         bool flag;
         if (Boolean.TryParse(value, out flag))
            Console.WriteLine("'{0}' --> {1}", value, flag);
         else
            Console.WriteLine("Unable to parse '{0}'.", 
                              value == null ? "<null>" : value);
      }                                     
   }
}
// The example displays the following output:
//       Unable to parse '<null>'.
//       Unable to parse ''.
//       'True' --> True
//       'False' --> False
//       'true' --> True
//       'false' --> False
//       '    true    ' --> True
//       Unable to parse '0'.
//       Unable to parse '1'.
//       Unable to parse '-1'.
//       Unable to parse 'string'.
// </Snippet1>
