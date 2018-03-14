// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      String[] values = { null, "160519", "9432.0", "16,667",
                          "   -322   ", "+4302", "(100);", "01FA" };
      foreach (var value in values) {
         int number;
   
         bool result = Int32.TryParse(value, out number);
         if (result)
         {
            Console.WriteLine("Converted '{0}' to {1}.", value, number);         
         }
         else
         {
//            if (value == null) value = ""; 
            Console.WriteLine("Attempted conversion of '{0}' failed.", 
                               value == null ? "<null>" : value);
         }
      }
   }
}
// The example displays the following output:
//       Attempted conversion of '<null>' failed.
//       Converted '160519' to 160519.
//       Attempted conversion of '9432.0' failed.
//       Attempted conversion of '16,667' failed.
//       Converted '   -322   ' to -322.
//       Converted '+4302' to 4302.
//       Attempted conversion of '(100);' failed.
//       Attempted conversion of '01FA' failed.
// </Snippet1>
