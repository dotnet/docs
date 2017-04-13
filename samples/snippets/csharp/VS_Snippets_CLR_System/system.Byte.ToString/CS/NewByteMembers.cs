using System;
using System.Globalization;

public class Class1
{
   public static void Main()
   {
      CallToString();
      Console.WriteLine();
      SpecifyFormatProvider();
      Console.WriteLine();
      SpecifyFormatString();
      Console.WriteLine();
      FormatWithProviders();
   }

   private static void CallToString()
   {
      // <Snippet2>
      byte[] bytes = {0, 1, 14, 168, 255};
      foreach (byte byteValue in bytes)
         Console.WriteLine(byteValue);
      // The example displays the following output to the console if the current
      // culture is en-US:
      //       0
      //       1
      //       14
      //       168
      //       255
      // </Snippet2>
   }

   private static void SpecifyFormatProvider()
   {
      // <Snippet3>
      byte[] bytes = {0, 1, 14, 168, 255};
      CultureInfo[] providers = {new CultureInfo("en-us"), 
                                 new CultureInfo("fr-fr"), 
                                 new CultureInfo("de-de"), 
                                 new CultureInfo("es-es")};
      foreach (byte byteValue in bytes)
      {
         foreach (CultureInfo provider in providers)
            Console.Write("{0,3} ({1})      ", 
                          byteValue.ToString(provider), provider.Name);

         Console.WriteLine();                                        
      }
      // The example displays the following output to the console:
      //      0 (en-US)        0 (fr-FR)        0 (de-DE)        0 (es-ES)
      //      1 (en-US)        1 (fr-FR)        1 (de-DE)        1 (es-ES)
      //     14 (en-US)       14 (fr-FR)       14 (de-DE)       14 (es-ES)
      //    168 (en-US)      168 (fr-FR)      168 (de-DE)      168 (es-ES)
      //    255 (en-US)      255 (fr-FR)      255 (de-DE)      255 (es-ES)            
      // </Snippet3>
      
   }

   private static void SpecifyFormatString()
   {
      // <Snippet4>
      string[] formats = {"C3", "D4", "e1", "E2", "F1", "G", "N1", 
                          "P0", "X4", "0000.0000"};
      byte number = 240;
      foreach (string format in formats)
         Console.WriteLine("'{0}' format specifier: {1}", 
                           format, number.ToString(format));

      // The example displays the following output to the console if the
      // current culture is en-us:
      //       'C3' format specifier: $240.000
      //       'D4' format specifier: 0240
      //       'e1' format specifier: 2.4e+002
      //       'E2' format specifier: 2.40E+002
      //       'F1' format specifier: 240.0
      //       'G' format specifier: 240
      //       'N1' format specifier: 240.0
      //       'P0' format specifier: 24,000 %
      //       'X4' format specifier: 00F0
      //       '0000.0000' format specifier: 0240.0000           
      // </Snippet4>                   
   }

   private static void FormatWithProviders()
   {
      // <Snippet5>
      byte byteValue = 250;
      CultureInfo[] providers = {new CultureInfo("en-us"), 
                                 new CultureInfo("fr-fr"), 
                                 new CultureInfo("es-es"), 
                                 new CultureInfo("de-de")}; 
      
      foreach (CultureInfo provider in providers) 
         Console.WriteLine("{0} ({1})", 
                           byteValue.ToString("N2", provider), provider.Name);
      // The example displays the following output to the console:
      //       250.00 (en-US)
      //       250,00 (fr-FR)
      //       250,00 (es-ES)
      //       250,00 (de-DE)      
      // </Snippet5>
   }
}
