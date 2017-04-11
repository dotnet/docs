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
      float number;
      
      number = 1.6E20F;
      // Displays 1.6E+20.
      Console.WriteLine(number.ToString());

      number = 1.6E2F;
      // Displays 160.
      Console.WriteLine(number.ToString());
      
      number = -3.541F;
      // Displays -3.541.
      Console.WriteLine(number.ToString());

      number = -1502345222199E-07F;
      // Displays -150234.5222199.
      Console.WriteLine(number.ToString());
      
      number = -15023452221990199574E-09F;
      // Displays -15023452221.9902.
      Console.WriteLine(number.ToString());
      
      number = .60344F;
      // Displays 0.60344.
      Console.WriteLine(number.ToString());
      
      number = .000000001F;
      // Displays 1E-09.
      Console.WriteLine(number.ToString());
     // </Snippet1>
   }

   private static void CallToStringWithFormatProvider()
   {
      // <Snippet2>
      float value;
      
      value = -16325.62015F;
      // Display value using the invariant culture.
      Console.WriteLine(value.ToString(CultureInfo.InvariantCulture));
      // Display value using the en-GB culture.
      Console.WriteLine(value.ToString(CultureInfo.CreateSpecificCulture("en-GB")));
      // Display value using the de-DE culture.
      Console.WriteLine(value.ToString(CultureInfo.CreateSpecificCulture("de-DE")));

      value = 16034.125E21F;
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
      float[] numbers= { 1054.32179F, -195489100.8377F, 1.0437E21F, 
                         -1.0573e-05F };
      string[] specifiers = { "C", "E", "e", "F", "G", "N", "P", 
                              "R", "#,000.000", "0.###E-000",
                              "000,000,000,000.00###" };

      foreach (float number in numbers)
      {
         Console.WriteLine("Formatting of {0}:", number);
         foreach (string specifier in specifiers)
            Console.WriteLine("   {0,5}: {1}", 
                              specifier, number.ToString(specifier));

         Console.WriteLine();
      }
      // The example displays the following output to the console:
      //       Formatting of 1054.32179:
      //              C: $1,054.32
      //              E: 1.054322E+003
      //              e: 1.054322e+003
      //              F: 1054.32
      //              G: 1054.32179
      //              N: 1,054.32
      //              P: 105,432.18 %
      //              R: 1054.32179
      //          #,000.000: 1,054.322
      //          0.###E-000: 1.054E003
      //          000,000,000,000.00###: 000,000,001,054.322
      //       
      //       Formatting of -195489100.8377:
      //              C: ($195,489,100.84)
      //              E: -1.954891E+008
      //              e: -1.954891e+008
      //              F: -195489100.84
      //              G: -195489100.8377
      //              N: -195,489,100.84
      //              P: -19,548,910,083.77 %
      //              R: -195489100.8377
      //          #,000.000: -195,489,100.838
      //          0.###E-000: -1.955E008
      //          000,000,000,000.00###: -000,195,489,100.00
      //       
      //       Formatting of 1.0437E+21:
      //              C: $1,043,700,000,000,000,000,000.00
      //              E: 1.043700E+021
      //              e: 1.043700e+021
      //              F: 1043700000000000000000.00
      //              G: 1.0437E+21
      //              N: 1,043,700,000,000,000,000,000.00
      //              P: 104,370,000,000,000,000,000,000.00 %
      //              R: 1.0437E+21
      //          #,000.000: 1,043,700,000,000,000,000,000.000
      //          0.###E-000: 1.044E021
      //          000,000,000,000.00###: 1,043,700,000,000,000,000,000.00
      //       
      //       Formatting of -1.0573E-05:
      //              C: $0.00
      //              E: -1.057300E-005
      //              e: -1.057300e-005
      //              F: 0.00
      //              G: -1.0573E-05
      //              N: 0.00
      //              P: 0.00 %
      //              R: -1.0573E-05
      //          #,000.000: 000.000
      //          0.###E-000: -1.057E-005
      //          000,000,000,000.00###: -000,000,000,000.00001 
      // </Snippet3>       
   }

   private static void CallToStringWithFormatStringAndProvider()
   {
      // <Snippet4>
      float value = 16325.62901F;
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
