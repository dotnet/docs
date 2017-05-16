// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      string[] values = { "1,643.57", "$1,643.57", "-1.643e6", 
                          "-168934617882109132", "123AE6", 
                          null, String.Empty, "ABCDEF" };
      double number;
      
      foreach (var value in values) {
         if (Double.TryParse(value, out number)) 
            Console.WriteLine("'{0}' --> {1}", value, number);
         else
            Console.WriteLine("Unable to parse '{0}'.", value);      
      }   
   }
}
// The example displays the following output:
//       '1,643.57' --> 1643.57
//       Unable to parse '$1,643.57'.
//       '-1.643e6' --> -1643000
//       '-168934617882109132' --> -1.68934617882109E+17
//       Unable to parse '123AE6'.
//       Unable to parse ''.
//       Unable to parse ''.
//       Unable to parse 'ABCDEF'.
// </Snippet1>

