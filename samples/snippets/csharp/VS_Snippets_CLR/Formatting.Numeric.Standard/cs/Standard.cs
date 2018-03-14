using System;
using System.Globalization;

class formatting
{
   public static void Main()
   {
      Console.Clear();
      Console.WriteLine(CultureInfo.CurrentUICulture.Name);
      Console.WriteLine(CultureInfo.CurrentCulture.Name);
      Console.WriteLine();
      Console.WriteLine("Currency Format Specifier:");
      ShowCurrency();
      Console.WriteLine();
      Console.WriteLine("Decimal Format Specifier:");
      ShowDecimal();
      Console.WriteLine();
      Console.WriteLine("Exponentiation Format Specifier:");
      ShowExponentiation();
      Console.WriteLine();
      Console.WriteLine("Fixed Point Format Specifier:");
      ShowFixedPoint();
      Console.WriteLine();
      Console.WriteLine("'G' Format Specifier:");
      ShowGeneral();
      Console.WriteLine();
      Console.WriteLine("'N' Format Specifier:");
      ShowNumeric();
      Console.WriteLine();
      Console.WriteLine("Percent Format Specifier:");
      ShowPercent();
      Console.WriteLine();
      Console.WriteLine("Round-trip Format Specifier:");
      ShowRoundTrip();
      Console.WriteLine();
      Console.WriteLine("Hexadecimal Format Specifier:");
      ShowHex();
   }
   
   public static void ShowCurrency()
   {
      // <Snippet1>
      double value = 12345.6789;
      Console.WriteLine(value.ToString("C", CultureInfo.CurrentCulture));

      Console.WriteLine(value.ToString("C3", CultureInfo.CurrentCulture));

      Console.WriteLine(value.ToString("C3", 
                        CultureInfo.CreateSpecificCulture("da-DK")));
      // The example displays the following output on a system whose
      // current culture is English (United States):
      //       $12,345.68
      //       $12,345.679
      //       kr 12.345,679
      // </Snippet1> 
   }
   
   public static void ShowDecimal()
   {
      // <Snippet2>
      int value; 
      
      value = 12345;
      Console.WriteLine(value.ToString("D"));
      // Displays 12345
      Console.WriteLine(value.ToString("D8"));
      // Displays 00012345

      value = -12345;
      Console.WriteLine(value.ToString("D"));
      // Displays -12345
      Console.WriteLine(value.ToString("D8"));
      // Displays -00012345
      // </Snippet2>
   }
   
   public static void ShowExponentiation()
   {
      // <Snippet3>
      double value = 12345.6789;
      Console.WriteLine(value.ToString("E", CultureInfo.InvariantCulture));
      // Displays 1.234568E+004
      
      Console.WriteLine(value.ToString("E10", CultureInfo.InvariantCulture));
      // Displays 1.2345678900E+004
      
      Console.WriteLine(value.ToString("e4", CultureInfo.InvariantCulture));
      // Displays 1.2346e+004
      
      Console.WriteLine(value.ToString("E", 
                        CultureInfo.CreateSpecificCulture("fr-FR")));
      // Displays 1,234568E+004
      // </Snippet3>
   }
   
   public static void ShowFixedPoint()
   {
      // <Snippet4>
      int integerNumber;
      integerNumber = 17843;
      Console.WriteLine(integerNumber.ToString("F", 
                        CultureInfo.InvariantCulture));
      // Displays 17843.00
      
      integerNumber = -29541;
      Console.WriteLine(integerNumber.ToString("F3", 
                        CultureInfo.InvariantCulture));
      // Displays -29541.000
      
      double doubleNumber;
      doubleNumber = 18934.1879;
      Console.WriteLine(doubleNumber.ToString("F", CultureInfo.InvariantCulture));
      // Displays 18934.19
      
      Console.WriteLine(doubleNumber.ToString("F0", CultureInfo.InvariantCulture));
      // Displays 18934
      
      doubleNumber = -1898300.1987;
      Console.WriteLine(doubleNumber.ToString("F1", CultureInfo.InvariantCulture));  
      // Displays -1898300.2

      Console.WriteLine(doubleNumber.ToString("F3", 
                        CultureInfo.CreateSpecificCulture("es-ES")));
      // Displays -1898300,199                        
      // </Snippet4>
   }
   
   public static void ShowGeneral()
   {
      // <Snippet5>
      double number;
      
      number = 12345.6789;      
      Console.WriteLine(number.ToString("G", CultureInfo.InvariantCulture));
      // Displays  12345.6789
      Console.WriteLine(number.ToString("G", 
                        CultureInfo.CreateSpecificCulture("fr-FR")));
      // Displays 12345,6789
                              
      Console.WriteLine(number.ToString("G7", CultureInfo.InvariantCulture));
      // Displays 12345.68 
      
      number = .0000023;
      Console.WriteLine(number.ToString("G", CultureInfo.InvariantCulture));
      // Displays 2.3E-06       
      Console.WriteLine(number.ToString("G", 
                        CultureInfo.CreateSpecificCulture("fr-FR")));
      // Displays 2,3E-06
      
      number = .0023;
      Console.WriteLine(number.ToString("G", CultureInfo.InvariantCulture));
      // Displays 0.0023

      number = 1234;
      Console.WriteLine(number.ToString("G2", CultureInfo.InvariantCulture));
      // Displays 1.2E+03

      number = Math.PI;
      Console.WriteLine(number.ToString("G5", CultureInfo.InvariantCulture));
      // Displays 3.1416    
      // </Snippet5>
   }
   
   public static void ShowNumeric()
   {
      // <Snippet6>
      double dblValue = -12445.6789;
      Console.WriteLine(dblValue.ToString("N", CultureInfo.InvariantCulture));
      // Displays -12,445.68
      Console.WriteLine(dblValue.ToString("N1", 
                        CultureInfo.CreateSpecificCulture("sv-SE")));
      // Displays -12 445,7
      
      int intValue = 123456789;
      Console.WriteLine(intValue.ToString("N1", CultureInfo.InvariantCulture));
      // Displays 123,456,789.0 
      // </Snippet6>
   }
   
   public static void ShowPercent()
   {
      // <Snippet7>
      double number = .2468013;
      Console.WriteLine(number.ToString("P", CultureInfo.InvariantCulture));
      // Displays 24.68 %
      Console.WriteLine(number.ToString("P", 
                        CultureInfo.CreateSpecificCulture("hr-HR")));
      // Displays 24,68%     
      Console.WriteLine(number.ToString("P1", CultureInfo.InvariantCulture));
      // Displays 24.7 %
      // </Snippet7>
   }
   
   public static void ShowRoundTrip()
   {
      // <Snippet8>
      double value;
      
      value = Math.PI;
      Console.WriteLine(value.ToString("r"));
      // Displays 3.1415926535897931
      Console.WriteLine(value.ToString("r", 
                        CultureInfo.CreateSpecificCulture("fr-FR")));
      // Displays 3,1415926535897931
      value = 1.623e-21;
      Console.WriteLine(value.ToString("r"));
      // Displays 1.623E-21
      // </Snippet8>
   }
   
   public static void ShowHex()
   {
      // <Snippet9>
      int value; 
      
      value = 0x2045e;
      Console.WriteLine(value.ToString("x"));
      // Displays 2045e
      Console.WriteLine(value.ToString("X"));
      // Displays 2045E
      Console.WriteLine(value.ToString("X8"));
      // Displays 0002045E
      
      value = 123456789;
      Console.WriteLine(value.ToString("X"));
      // Displays 75BCD15
      Console.WriteLine(value.ToString("X2"));
      // Displays 75BCD15
      // </Snippet9>
   }
}
