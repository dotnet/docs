// <Snippet3>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string[] inputs = { "3", "16:42", "1:6:52:35.0625", 
                          "1:6:52:35,0625" }; 
      string[] formats = { "g", "G", "%h"};
      TimeSpan interval;
      CultureInfo culture = new CultureInfo("fr-FR");
      
      // Parse each string in inputs using formats and the fr-FR culture.
      foreach (string input in inputs) {
         try {
            interval = TimeSpan.ParseExact(input, formats, culture);
            Console.WriteLine("{0} --> {1:c}", input, interval);
         }
         catch (FormatException) {
            Console.WriteLine("{0} --> Bad Format", input);
         }      
         catch (OverflowException) {
            Console.WriteLine("{0} --> Overflow", input);   
         }            
      }
   }
}
// The example displays the following output:
//       3 --> 03:00:00
//       16:42 --> 16:42:00
//       1:6:52:35.0625 --> Bad Format
//       1:6:52:35,0625 --> 1.06:52:35.0625000
// </Snippet3>
