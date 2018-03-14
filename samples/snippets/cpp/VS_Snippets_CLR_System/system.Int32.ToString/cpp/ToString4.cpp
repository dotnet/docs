// <Snippet4>
using namespace System;
using namespace System::Globalization;

void main()
{
    // Define cultures whose formatting conventions are to be used.
    array<CultureInfo^>^ cultures = { CultureInfo::CreateSpecificCulture("en-US"), 
                                      CultureInfo::CreateSpecificCulture("fr-FR"), 
                                      CultureInfo::CreateSpecificCulture("es-ES") };
    int positiveNumber = 1679;
    int negativeNumber = -3045;
    array<String^>^ specifiers = {"G", "C", "D8", "E2", "F", "N", "P", "X8"}; 
    
    for each (String^ specifier in specifiers)
    {
       for each (CultureInfo^ culture in cultures)
       {
          // Display values with "G" format specifier.
          Console::WriteLine("{0} format using {1} culture: {2, 16} {3, 16}",  
                            specifier, culture->Name, 
                            positiveNumber.ToString(specifier, culture), 
                            negativeNumber.ToString(specifier, culture));
       }
       Console::WriteLine();
    }
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
