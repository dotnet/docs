// <Snippet27>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      // Create a NumberFormatInfo object and set its NegativeSigns
      // property to use for integer formatting.
      NumberFormatInfo provider = new NumberFormatInfo();
      provider.NegativeSign = "minus ";

      int[] values = { -20, 0, 100 };
      
      Console.WriteLine("{0,-8} --> {1,10} {2,10}\n", "Value",
                         CultureInfo.CurrentCulture.Name,
                         "Custom");
      foreach (int value in values)
         Console.WriteLine("{0,-8} --> {1,10} {2,10}",
                           value, Convert.ToString(value),
                           Convert.ToString(value, provider));
      // The example displays output like the following:
      //       Value    -->      en-US     Custom
      //
      //       -20      -->        -20   minus 20
      //       0        -->          0          0
      //       100      -->        100        100
      // </Snippet27>
   }
}
