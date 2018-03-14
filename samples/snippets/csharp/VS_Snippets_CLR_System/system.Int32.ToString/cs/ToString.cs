using System;
using System.Globalization;

public class IntToString
{
   public static void Main()
   {
      CallDefaultToString();
      Console.WriteLine();
      CallToStringWithSpecificCultures();
      Console.WriteLine();
      CallToStringWithSpecificSpecifiers();
      Console.WriteLine();
      CallToStringWithSpecifiersAndCultures();
   }

   private static void CallDefaultToString()
   {
      // <Snippet1>
      int value = -16325;
      // Display value using default ToString method.
      Console.WriteLine(value.ToString());            // Displays -16325
      // Display value using some standard format specifiers.
      Console.WriteLine(value.ToString("G"));         // Displays -16325
      Console.WriteLine(value.ToString("C"));         // Displays ($16,325.00)
      Console.WriteLine(value.ToString("D"));         // Displays -16325
      Console.WriteLine(value.ToString("F"));         // Displays -16325.00
      Console.WriteLine(value.ToString("N"));         // Displays -16,325.00
      Console.WriteLine(value.ToString("X"));         // Displays FFFFC03B      
      // </Snippet1>
   }

   private static void CallToStringWithSpecificCultures()
   {
      // <Snippet2>
      int value = -16325;
      // Display value using the invariant culture.
      Console.WriteLine(value.ToString(CultureInfo.InvariantCulture));
      // Display value using the en-GB culture.
      Console.WriteLine(value.ToString(CultureInfo.CreateSpecificCulture("en-GB")));
      // Display value using the de-DE culture.
      Console.WriteLine(value.ToString(CultureInfo.CreateSpecificCulture("de-DE")));
      // This example displays the following output to the console:
      //       -16325
      //       -16325
      //       -16325
      // </Snippet2>
   }
   
   private static void CallToStringWithSpecificSpecifiers()
   {
      // <Snippet3>
      int value = -16325;
      string specifier;
      
      // Use standard numeric format specifier.
      specifier = "G";
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
      // Displays:    G: -16325
      specifier = "C";
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
      // Displays:    C: ($16,325.00)
      specifier = "D8";
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
      // Displays:    D8: -00016325
      specifier = "E4";
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
      // Displays:    E4: -1.6325E+004
      specifier = "e3";
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
      // Displays:    e3: -1.633e+004
      specifier = "F";
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
      // Displays:    F: -16325.00
      specifier = "N";
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
      // Displays:    N: -16,325.00
      specifier = "P";
      Console.WriteLine("{0}: {1}", specifier, (value/100000).ToString(specifier));
      // Displays:    P: -16.33 %
      specifier = "X";
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
      // Displays:    X: FFFFC03B 
      
      // Use custom numeric format specifiers.
      specifier = "0,0.000";
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
      // Displays:    0,0.000: -16,325.000
      specifier = "#,#.00#;(#,#.00#)";
      Console.WriteLine("{0}: {1}", specifier, (value*-1).ToString(specifier));
      // Displays:    #,#.00#;(#,#.00#): 16,325.00
      // </Snippet3>
   }   

   private static void CallToStringWithSpecifiersAndCultures()
   {
      // <Snippet4>
      // Define cultures whose formatting conventions are to be used.
      CultureInfo[] cultures = {CultureInfo.CreateSpecificCulture("en-US"), 
                                CultureInfo.CreateSpecificCulture("fr-FR"), 
                                CultureInfo.CreateSpecificCulture("es-ES") };
      int positiveNumber = 1679;
      int negativeNumber = -3045;
      string[] specifiers = {"G", "C", "D8", "E2", "F", "N", "P", "X8"}; 
      
      foreach (string specifier in specifiers)
      {
         foreach (CultureInfo culture in cultures)
         {
            // Display values with "G" format specifier.
            Console.WriteLine("{0} format using {1} culture: {2, 16} {3, 16}",  
                              specifier, culture.Name, 
                              positiveNumber.ToString(specifier, culture), 
                              negativeNumber.ToString(specifier, culture));
         }
         Console.WriteLine();
      }
      // The example displays the following output:
      //       G format using en-US culture:             1679            -3045
      //       G format using fr-FR culture:             1679            -3045
      //       G format using es-ES culture:             1679            -3045
      //       
      //       C format using en-US culture:        $1,679.00      ($3,045.00)
      //       C format using fr-FR culture:       1 679,00 €      -3 045,00 €
      //       C format using es-ES culture:       1.679,00 €      -3.045,00 €
      //       
      //       D8 format using en-US culture:         00001679        -00003045
      //       D8 format using fr-FR culture:         00001679        -00003045
      //       D8 format using es-ES culture:         00001679        -00003045
      //       
      //       E2 format using en-US culture:        1.68E+003       -3.05E+003
      //       E2 format using fr-FR culture:        1,68E+003       -3,05E+003
      //       E2 format using es-ES culture:        1,68E+003       -3,05E+003
      //       
      //       F format using en-US culture:          1679.00         -3045.00
      //       F format using fr-FR culture:          1679,00         -3045,00
      //       F format using es-ES culture:          1679,00         -3045,00
      //       
      //       N format using en-US culture:         1,679.00        -3,045.00
      //       N format using fr-FR culture:         1 679,00        -3 045,00
      //       N format using es-ES culture:         1.679,00        -3.045,00
      //       
      //       P format using en-US culture:     167,900.00 %    -304,500.00 %
      //       P format using fr-FR culture:     167 900,00 %    -304 500,00 %
      //       P format using es-ES culture:     167.900,00 %    -304.500,00 %
      //       
      //       X8 format using en-US culture:         0000068F         FFFFF41B
      //       X8 format using fr-FR culture:         0000068F         FFFFF41B
      //       X8 format using es-ES culture:         0000068F         FFFFF41B
      // </Snippet4>                                      
   }
}
