// <Snippet4>
using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
      // Define an array of string values.
      string[] values = { " 987.654E-2", " 987,654E-2",  "(98765,43210)", 
                          "9,876,543.210", "9.876.543,210",  "98_76_54_32,19" };
      // Create a custom culture based on the invariant culture.
      CultureInfo ci = new CultureInfo("");
      ci.NumberFormat.NumberGroupSizes = new int[] { 2 };
      ci.NumberFormat.NumberGroupSeparator = "_";
      
      // Define an array of format providers.
      CultureInfo[] providers = { new CultureInfo("en-US"),
                                  new CultureInfo("nl-NL"), ci };       
      
      // Define an array of styles.
      NumberStyles[] styles = { NumberStyles.Currency, NumberStyles.Float };
      
      // Iterate the array of format providers.
      foreach (CultureInfo provider in providers)
      {
         Console.WriteLine("Parsing using the {0} culture:", 
                           provider.Name == String.Empty ? "Invariant" : provider.Name);
         // Parse each element in the array of string values.
         foreach (string value in values)
         {
            foreach (NumberStyles style in styles)
            {
               try {
                  float number = Single.Parse(value, style, provider);            
                  Console.WriteLine("   {0} ({1}) -> {2}", 
                                    value, style, number);
               }
               catch (FormatException) {
                  Console.WriteLine("   '{0}' is invalid using {1}.", value, style);
               }
               catch (OverflowException) {
                  Console.WriteLine("   '{0}' is out of the range of a Single.", value);
               } 
            }            
         }         
         Console.WriteLine();
      }
   }   
} 
// The example displays the following output:
//       Parsing using the en-US culture:
//       The format of // 987.654E-2// is invalid.
//       The format of // 987,654E-2// is invalid.
//       (98765,43210) (Currency) -> -9.876543E+09
//       9,876,543.210 (Currency) -> 9876543
//       The format of '9.876.543,210// is invalid.
//       The format of '98_76_54_32,19// is invalid.
//       
//       Parsing using the nl-NL culture:
//       The format of // 987.654E-2// is invalid.
//       The format of // 987,654E-2// is invalid.
//       (98765,43210) (Currency) -> -98765.43
//       The format of '9,876,543.210// is invalid.
//       9.876.543,210 (Currency) -> 9876543
//       The format of '98_76_54_32,19// is invalid.
//       
//       Parsing using the Invariant culture:
//       The format of // 987.654E-2// is invalid.
//       The format of // 987,654E-2// is invalid.
//       (98765,43210) (Currency) -> -9.876543E+09
//       9,876,543.210 (Currency) -> 9876543
//       The format of '9.876.543,210// is invalid.
//       98_76_54_32,19 (Currency) -> 9.876543E+09
// </Snippet4>
