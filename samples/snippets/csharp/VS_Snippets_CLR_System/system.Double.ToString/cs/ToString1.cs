using System;
using System.Globalization;

public class Class1
{
   public static void Main()
   {
      CallDefaultToString();
      Console.WriteLine("----------");
      CallToStringWithFormatProvider();
      Console.WriteLine("----------");
      CallToStringWithFormatString();
      Console.WriteLine("----------");
      CallToStringWithFormatStringAndProvider();
   }

   private static void CallDefaultToString()
   {
      // <Snippet1>
      double number;
      
      number = 1.6E20;
      // Displays 1.6E+20.
      Console.WriteLine(number.ToString());

      number = 1.6E2;
      // Displays 160.
      Console.WriteLine(number.ToString());
      
      number = -3.541;
      // Displays -3.541.
      Console.WriteLine(number.ToString());

      number = -1502345222199E-07;
      // Displays -150234.5222199.
      Console.WriteLine(number.ToString());
      
      number = -15023452221990199574E-09;
      // Displays -15023452221.9902.
      Console.WriteLine(number.ToString());
      
      number = .60344;
      // Displays 0.60344.
      Console.WriteLine(number.ToString());
      
      number = .000000001;
      // Displays 1E-09.
      Console.WriteLine(number.ToString());
     // </Snippet1>
   }

   private static void CallToStringWithFormatProvider()
   {
      // <Snippet2>
      double value;
      
      value = -16325.62015;
      // Display value using the invariant culture.
      Console.WriteLine(value.ToString(CultureInfo.InvariantCulture));
      // Display value using the en-GB culture.
      Console.WriteLine(value.ToString(CultureInfo.CreateSpecificCulture("en-GB")));
      // Display value using the de-DE culture.
      Console.WriteLine(value.ToString(CultureInfo.CreateSpecificCulture("de-DE")));

      value = 16034.125E21;
      // Display value using the invariant culture.
      Console.WriteLine(value.ToString(CultureInfo.InvariantCulture));
      // Display value using the en-GB culture.
      Console.WriteLine(value.ToString(CultureInfo.CreateSpecificCulture("en-GB")));
      // Display value using the de-DE culture.
      Console.WriteLine(value.ToString(CultureInfo.CreateSpecificCulture("de-DE")));
      // This example displays the following output to the console:
      //       -16325.62015
      //       -16325.62015
      //       -16325,62015
      //       1.6034125E+25
      //       1.6034125E+25
      //       1,6034125E+25
      // </Snippet2>      
   }

   private static void CallToStringWithFormatString()
   {
      // <Snippet3>
      double[] numbers= {1054.32179, -195489100.8377, 1.0437E21, 
                         -1.0573e-05};
      string[] specifiers = { "C", "E", "e", "F", "G", "N", "P", 
                              "R", "#,000.000", "0.###E-000",
                              "000,000,000,000.00###" };
      foreach (double number in numbers)
      {
         Console.WriteLine("Formatting of {0}:", number);
         foreach (string specifier in specifiers) {
            Console.WriteLine("   {0,-22} {1}", 
                              specifier + ":", number.ToString(specifier));
            // Add precision specifiers from 0 to 3.
            if (specifier.Length == 1 & ! specifier.Equals("R")) {
               for (int precision = 0; precision <= 3; precision++) {
                  string pSpecifier = String.Format("{0}{1}", specifier, precision);
                  Console.WriteLine("   {0,-22} {1}", 
                                    pSpecifier + ":", number.ToString(pSpecifier));
               }    
               Console.WriteLine();
            }   
         }
         Console.WriteLine();
      }
      // The example displays the following output to the console:
      //       Formatting of 1054.32179:
      //          C:                     $1,054.32
      //          C0:                    $1,054
      //          C1:                    $1,054.3
      //          C2:                    $1,054.32
      //          C3:                    $1,054.322
      //       
      //          E:                     1.054322E+003
      //          E0:                    1E+003
      //          E1:                    1.1E+003
      //          E2:                    1.05E+003
      //          E3:                    1.054E+003
      //       
      //          e:                     1.054322e+003
      //          e0:                    1e+003
      //          e1:                    1.1e+003
      //          e2:                    1.05e+003
      //          e3:                    1.054e+003
      //       
      //          F:                     1054.32
      //          F0:                    1054
      //          F1:                    1054.3
      //          F2:                    1054.32
      //          F3:                    1054.322
      //       
      //          G:                     1054.32179
      //          G0:                    1054.32179
      //          G1:                    1E+03
      //          G2:                    1.1E+03
      //          G3:                    1.05E+03
      //       
      //          N:                     1,054.32
      //          N0:                    1,054
      //          N1:                    1,054.3
      //          N2:                    1,054.32
      //          N3:                    1,054.322
      //       
      //          P:                     105,432.18 %
      //          P0:                    105,432 %
      //          P1:                    105,432.2 %
      //          P2:                    105,432.18 %
      //          P3:                    105,432.179 %
      //       
      //          R:                     1054.32179
      //          #,000.000:             1,054.322
      //          0.###E-000:            1.054E003
      //          000,000,000,000.00###: 000,000,001,054.32179
      //       
      //       Formatting of -195489100.8377:
      //          C:                     ($195,489,100.84)
      //          C0:                    ($195,489,101)
      //          C1:                    ($195,489,100.8)
      //          C2:                    ($195,489,100.84)
      //          C3:                    ($195,489,100.838)
      //       
      //          E:                     -1.954891E+008
      //          E0:                    -2E+008
      //          E1:                    -2.0E+008
      //          E2:                    -1.95E+008
      //          E3:                    -1.955E+008
      //       
      //          e:                     -1.954891e+008
      //          e0:                    -2e+008
      //          e1:                    -2.0e+008
      //          e2:                    -1.95e+008
      //          e3:                    -1.955e+008
      //       
      //          F:                     -195489100.84
      //          F0:                    -195489101
      //          F1:                    -195489100.8
      //          F2:                    -195489100.84
      //          F3:                    -195489100.838
      //       
      //          G:                     -195489100.8377
      //          G0:                    -195489100.8377
      //          G1:                    -2E+08
      //          G2:                    -2E+08
      //          G3:                    -1.95E+08
      //       
      //          N:                     -195,489,100.84
      //          N0:                    -195,489,101
      //          N1:                    -195,489,100.8
      //          N2:                    -195,489,100.84
      //          N3:                    -195,489,100.838
      //       
      //          P:                     -19,548,910,083.77 %
      //          P0:                    -19,548,910,084 %
      //          P1:                    -19,548,910,083.8 %
      //          P2:                    -19,548,910,083.77 %
      //          P3:                    -19,548,910,083.770 %
      //       
      //          R:                     -195489100.8377
      //          #,000.000:             -195,489,100.838
      //          0.###E-000:            -1.955E008
      //          000,000,000,000.00###: -000,195,489,100.8377
      //       
      //       Formatting of 1.0437E+21:
      //          C:                     $1,043,700,000,000,000,000,000.00
      //          C0:                    $1,043,700,000,000,000,000,000
      //          C1:                    $1,043,700,000,000,000,000,000.0
      //          C2:                    $1,043,700,000,000,000,000,000.00
      //          C3:                    $1,043,700,000,000,000,000,000.000
      //       
      //          E:                     1.043700E+021
      //          E0:                    1E+021
      //          E1:                    1.0E+021
      //          E2:                    1.04E+021
      //          E3:                    1.044E+021
      //       
      //          e:                     1.043700e+021
      //          e0:                    1e+021
      //          e1:                    1.0e+021
      //          e2:                    1.04e+021
      //          e3:                    1.044e+021
      //       
      //          F:                     1043700000000000000000.00
      //          F0:                    1043700000000000000000
      //          F1:                    1043700000000000000000.0
      //          F2:                    1043700000000000000000.00
      //          F3:                    1043700000000000000000.000
      //       
      //          G:                     1.0437E+21
      //          G0:                    1.0437E+21
      //          G1:                    1E+21
      //          G2:                    1E+21
      //          G3:                    1.04E+21
      //       
      //          N:                     1,043,700,000,000,000,000,000.00
      //          N0:                    1,043,700,000,000,000,000,000
      //          N1:                    1,043,700,000,000,000,000,000.0
      //          N2:                    1,043,700,000,000,000,000,000.00
      //          N3:                    1,043,700,000,000,000,000,000.000
      //       
      //          P:                     104,370,000,000,000,000,000,000.00 %
      //          P0:                    104,370,000,000,000,000,000,000 %
      //          P1:                    104,370,000,000,000,000,000,000.0 %
      //          P2:                    104,370,000,000,000,000,000,000.00 %
      //          P3:                    104,370,000,000,000,000,000,000.000 %
      //       
      //          R:                     1.0437E+21
      //          #,000.000:             1,043,700,000,000,000,000,000.000
      //          0.###E-000:            1.044E021
      //          000,000,000,000.00###: 1,043,700,000,000,000,000,000.00
      //       
      //       Formatting of -1.0573E-05:
      //          C:                     $0.00
      //          C0:                    $0
      //          C1:                    $0.0
      //          C2:                    $0.00
      //          C3:                    $0.000
      //       
      //          E:                     -1.057300E-005
      //          E0:                    -1E-005
      //          E1:                    -1.1E-005
      //          E2:                    -1.06E-005
      //          E3:                    -1.057E-005
      //       
      //          e:                     -1.057300e-005
      //          e0:                    -1e-005
      //          e1:                    -1.1e-005
      //          e2:                    -1.06e-005
      //          e3:                    -1.057e-005
      //       
      //          F:                     0.00
      //          F0:                    0
      //          F1:                    0.0
      //          F2:                    0.00
      //          F3:                    0.000
      //       
      //          G:                     -1.0573E-05
      //          G0:                    -1.0573E-05
      //          G1:                    -1E-05
      //          G2:                    -1.1E-05
      //          G3:                    -1.06E-05
      //       
      //          N:                     0.00
      //          N0:                    0
      //          N1:                    0.0
      //          N2:                    0.00
      //          N3:                    0.000
      //       
      //          P:                     0.00 %
      //          P0:                    0 %
      //          P1:                    0.0 %
      //          P2:                    0.00 %
      //          P3:                    -0.001 %
      //       
      //          R:                     -1.0573E-05
      //          #,000.000:             000.000
      //          0.###E-000:            -1.057E-005
      //          000,000,000,000.00###: -000,000,000,000.00001 
      // </Snippet3>       
   }

   private static void CallToStringWithFormatStringAndProvider()
   {
      // <Snippet4>
      double value = 16325.62901;
      string specifier;
      CultureInfo culture;

      // Use standard numeric format specifiers.
      specifier = "G";
      culture = CultureInfo.CreateSpecificCulture("eu-ES");
      Console.WriteLine(value.ToString(specifier, culture));
      // Displays:    16325,62901
      Console.WriteLine(value.ToString(specifier, CultureInfo.InvariantCulture));
      // Displays:    16325.62901
      
      specifier = "C";
      culture = CultureInfo.CreateSpecificCulture("en-US");
      Console.WriteLine(value.ToString(specifier, culture));
      // Displays:    $16,325.63
      culture = CultureInfo.CreateSpecificCulture("en-GB");
      Console.WriteLine(value.ToString(specifier, culture));
      // Displays:    £16,325.63
      
      specifier = "E04";
      culture = CultureInfo.CreateSpecificCulture("sv-SE");
      Console.WriteLine(value.ToString(specifier, culture));
      // Displays: 1,6326E+004   
       culture = CultureInfo.CreateSpecificCulture("en-NZ");
       Console.WriteLine(value.ToString(specifier, culture));
      // Displays:    1.6326E+004   
      
      specifier = "F";
      culture = CultureInfo.CreateSpecificCulture("fr-FR");
      Console.WriteLine(value.ToString(specifier, culture));
      // Displays:    16325,63
      culture = CultureInfo.CreateSpecificCulture("en-CA");
      Console.WriteLine(value.ToString(specifier, culture));
      // Displays:    16325.63
      
      specifier = "N";
      culture = CultureInfo.CreateSpecificCulture("es-ES");
      Console.WriteLine(value.ToString(specifier, culture));
      // Displays:    16.325,63
      culture = CultureInfo.CreateSpecificCulture("fr-CA");
      Console.WriteLine(value.ToString(specifier, culture));
      // Displays:    16 325,63
      
      specifier = "P";
      culture = CultureInfo.InvariantCulture;
      Console.WriteLine((value/10000).ToString(specifier, culture));
      // Displays:    163.26 %
      culture = CultureInfo.CreateSpecificCulture("ar-EG");
      Console.WriteLine((value/10000).ToString(specifier, culture));
      // Displays:    163.256 %
      // </Snippet4>   
   }
}
