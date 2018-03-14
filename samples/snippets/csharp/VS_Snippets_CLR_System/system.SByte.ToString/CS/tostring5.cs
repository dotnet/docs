// <Snippet5>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      // Define cultures whose formatting conventions are to be used.
      CultureInfo[] cultures = { CultureInfo.CreateSpecificCulture("en-US"), 
                                 CultureInfo.CreateSpecificCulture("fr-FR"), 
                                 CultureInfo.CreateSpecificCulture("es-ES") };
      sbyte positiveNumber = 119;
      sbyte negativeNumber = -45;
      string[] specifiers = {"G", "C", "D4", "E2", "F", "N", "P", "X2"}; 
      
      foreach (string specifier in specifiers)
      {
         foreach (CultureInfo culture in cultures)
            Console.WriteLine("{0,2} format using {1} culture: {2, 16} {3, 16}",  
                              specifier, culture.Name, 
                              positiveNumber.ToString(specifier, culture), 
                              negativeNumber.ToString(specifier, culture));
         Console.WriteLine();
      }
   }
}
// The example displays the following output:
//     G format using en-US culture:              119              -45
//     G format using fr-FR culture:              119              -45
//     G format using es-ES culture:              119              -45
//    
//     C format using en-US culture:          $119.00         ($45.00)
//     C format using fr-FR culture:         119,00 €         -45,00 €
//     C format using es-ES culture:         119,00 €         -45,00 €
//    
//    D4 format using en-US culture:             0119            -0045
//    D4 format using fr-FR culture:             0119            -0045
//    D4 format using es-ES culture:             0119            -0045
//    
//    E2 format using en-US culture:        1.19E+002       -4.50E+001
//    E2 format using fr-FR culture:        1,19E+002       -4,50E+001
//    E2 format using es-ES culture:        1,19E+002       -4,50E+001
//    
//     F format using en-US culture:           119.00           -45.00
//     F format using fr-FR culture:           119,00           -45,00
//     F format using es-ES culture:           119,00           -45,00
//    
//     N format using en-US culture:           119.00           -45.00
//     N format using fr-FR culture:           119,00           -45,00
//     N format using es-ES culture:           119,00           -45,00
//    
//     P format using en-US culture:      11,900.00 %      -4,500.00 %
//     P format using fr-FR culture:      11 900,00 %      -4 500,00 %
//     P format using es-ES culture:      11.900,00 %      -4.500,00 %
//    
//    X2 format using en-US culture:               77               D3
//    X2 format using fr-FR culture:               77               D3
//    X2 format using es-ES culture:               77               D3
// </Snippet5>
