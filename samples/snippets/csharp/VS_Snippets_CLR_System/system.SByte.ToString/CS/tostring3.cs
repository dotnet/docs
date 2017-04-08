// <Snippet3>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      // Define a custom NumberFormatInfo object with "~" as its negative sign.
      NumberFormatInfo nfi = new NumberFormatInfo();
      nfi.NegativeSign = "~";
      
      // Initialize an array of SByte values.
      sbyte[] bytes = { -122, 17, 124 };

      // Display the formatted result using the custom provider.
      Console.WriteLine("Using the custom NumberFormatInfo object:");
      foreach (sbyte value in bytes)
         Console.WriteLine(value.ToString(nfi));

      Console.WriteLine();
          
      // Display the formatted result using the invariant culture.
      Console.WriteLine("Using the invariant culture:");
      foreach (sbyte value in bytes)
         Console.WriteLine(value.ToString(NumberFormatInfo.InvariantInfo));
   }
}
// The example displays the following output:
//       Using the custom NumberFormatInfo object:
//       ~122
//       17
//       124
//       
//       Using the invariant culture:
//       -122
//       17
//       124
// </Snippet3>
