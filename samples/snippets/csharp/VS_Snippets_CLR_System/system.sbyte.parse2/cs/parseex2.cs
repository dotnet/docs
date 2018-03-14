// <Snippet2>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      NumberStyles style;
      sbyte number;

      // Parse value with no styles allowed.
      string[] values1 = { " 121 ", "121", "-121" };
      style = NumberStyles.None;
      Console.WriteLine("Styles: {0}", style.ToString());
      foreach (string value in values1)
      {
         try {
            number = SByte.Parse(value, style);
            Console.WriteLine("   Converted '{0}' to {1}.", value, number);
         }   
         catch (FormatException) {
            Console.WriteLine("   Unable to parse '{0}'.", value);
         }
      }
      Console.WriteLine();
            
      // Parse value with trailing sign.
      style = NumberStyles.Integer | NumberStyles.AllowTrailingSign;
      string[] values2 = { " 103+", " 103 +", "+103", "(103)", "   +103  " };
      Console.WriteLine("Styles: {0}", style.ToString());
      foreach (string value in values2)
      {
         try {
            number = SByte.Parse(value, style);
            Console.WriteLine("   Converted '{0}' to {1}.", value, number);
         }   
         catch (FormatException) {
            Console.WriteLine("   Unable to parse '{0}'.", value);
         }      
         catch (OverflowException) {
            Console.WriteLine("   '{0}' is out of range of the SByte type.", value);         
         }
      }      
      Console.WriteLine();
   }
}
// The example displays the following output:
//       Styles: None
//          Unable to parse ' 121 '.
//          Converted '121' to 121.
//          Unable to parse '-121'.
//       
//       Styles: Integer, AllowTrailingSign
//          Converted ' 103+' to 103.
//          Converted ' 103 +' to 103.
//          Converted '+103' to 103.
//          Unable to parse '(103)'.
//          Converted '   +103  ' to 103.
// </Snippet2>
