using System;
using System.Globalization;

public class Class1
{
   public static void Main()
   {
      Console.Clear();
      Console.WriteLine();
      Console.WriteLine("***d Specifier***");
      ShowdSpecifier();
      Console.WriteLine();
      Console.WriteLine("***D Specifier***");
      ShowDSpecifier();
      Console.WriteLine();
      Console.WriteLine("***f Specifier***");
      ShowfSpecifier();
      Console.WriteLine();
      Console.WriteLine("***F Specifier***");
      ShowFSpecifier();
      Console.WriteLine();
      Console.WriteLine("***g Specifier***");
      ShowgSpecifier();
      Console.WriteLine();
      Console.WriteLine("***G Specifier***");
      ShowGSpecifier();
      Console.WriteLine();
      Console.WriteLine("***M Specifier***");
      ShowMSpecifier();
      Console.WriteLine();
      Console.WriteLine("***O Specifier***");
      ShowOSpecifier();
      Console.WriteLine();
      Console.WriteLine("***R Specifier***");
      ShowRSpecifier();
      Console.WriteLine();
      Console.WriteLine("***S Specifier***");
      ShowSSpecifier();
      Console.WriteLine();
      Console.WriteLine("***t Specifier***");
      ShowtSpecifier();
      Console.WriteLine();
      Console.WriteLine("***T Specifier***");
      ShowTSpecifier();
      Console.WriteLine();
      Console.WriteLine("***u Specifier***");
      ShowuSpecifier();
      Console.WriteLine();
      Console.WriteLine("***U Specifier***");
      ShowUSpecifier();
      Console.WriteLine();
      Console.WriteLine("***Y Specifier***");
      ShowYSpecifier();
   }

   private static void ShowdSpecifier()
   {
      // d Format Specifier
      // <Snippet1>
      DateTime date1 = new DateTime(2008,4, 10);
      Console.WriteLine(date1.ToString("d", DateTimeFormatInfo.InvariantInfo));
      // Displays 04/10/2008
      Console.WriteLine(date1.ToString("d", 
                        CultureInfo.CreateSpecificCulture("en-US")));
      // Displays 4/10/2008                       
      Console.WriteLine(date1.ToString("d", 
                        CultureInfo.CreateSpecificCulture("en-NZ")));
      // Displays 10/04/2008                       
      Console.WriteLine(date1.ToString("d", 
                        CultureInfo.CreateSpecificCulture("de-DE")));
      // Displays 10.04.2008                       
      // </Snippet1>
   }
   
   private static void ShowDSpecifier()
   {
      // D Format Specifier
      // <Snippet2>
      DateTime date1 = new DateTime(2008, 4, 10);
      Console.WriteLine(date1.ToString("D", 
                        CultureInfo.CreateSpecificCulture("en-US")));
      // Displays Thursday, April 10, 2008                        
      Console.WriteLine(date1.ToString("D", 
                        CultureInfo.CreateSpecificCulture("pt-BR")));
      // Displays quinta-feira, 10 de abril de 2008                        
      Console.WriteLine(date1.ToString("D", 
                        CultureInfo.CreateSpecificCulture("es-MX")));
      // Displays jueves, 10 de abril de 2008                        
      // </Snippet2>
   }
   
   private static void ShowfSpecifier()
   {
      // f Format Specifier
      // <Snippet3>
      DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
      Console.WriteLine(date1.ToString("f", 
                        CultureInfo.CreateSpecificCulture("en-US")));
      // Displays Thursday, April 10, 2008 6:30 AM                        
      Console.WriteLine(date1.ToString("f", 
                        CultureInfo.CreateSpecificCulture("fr-FR")));
      // Displays jeudi 10 avril 2008 06:30                       
      // </Snippet3>   
   }
   
   private static void ShowFSpecifier()
   {
      // F Format Specifier
      // <Snippet4>
      DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
      Console.WriteLine(date1.ToString("F", 
                        CultureInfo.CreateSpecificCulture("en-US")));
      // Displays Thursday, April 10, 2008 6:30:00 AM                        
      Console.WriteLine(date1.ToString("F", 
                        CultureInfo.CreateSpecificCulture("fr-FR")));
      // Displays jeudi 10 avril 2008 06:30:00                       
      // </Snippet4>   
   }

   private static void ShowgSpecifier()
   {
      // g Format Specifier
      // <Snippet5>
      DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
      Console.WriteLine(date1.ToString("g", 
                        DateTimeFormatInfo.InvariantInfo));
      // Displays 04/10/2008 06:30                      
      Console.WriteLine(date1.ToString("g", 
                        CultureInfo.CreateSpecificCulture("en-us")));
      // Displays 4/10/2008 6:30 AM                       
      Console.WriteLine(date1.ToString("g", 
                        CultureInfo.CreateSpecificCulture("fr-BE")));
      // Displays 10/04/2008 6:30                        
      // </Snippet5>   
   }
   
   private static void ShowGSpecifier()
   {
      // G Format Specifier
      // <Snippet6>
      DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
      Console.WriteLine(date1.ToString("G", 
                        DateTimeFormatInfo.InvariantInfo));
      // Displays 04/10/2008 06:30:00
      Console.WriteLine(date1.ToString("G", 
                        CultureInfo.CreateSpecificCulture("en-us")));
      // Displays 4/10/2008 6:30:00 AM                        
      Console.WriteLine(date1.ToString("G", 
                        CultureInfo.CreateSpecificCulture("nl-BE")));
      // Displays 10/04/2008 6:30:00                       
      // </Snippet6>   
   }
   
   private static void ShowMSpecifier()
   {
      // M Format Specifier
      // <Snippet7>
      DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
      Console.WriteLine(date1.ToString("m", 
                        CultureInfo.CreateSpecificCulture("en-us")));
      // Displays April 10                        
      Console.WriteLine(date1.ToString("m", 
                        CultureInfo.CreateSpecificCulture("ms-MY")));
      // Displays 10 April                       
      // </Snippet7>   
   }
   
   private static void ShowOSpecifier()
   {
      // O Format Specifier

      DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
      DateTimeOffset dateOffset = new DateTimeOffset(date1, 
                                  TimeZoneInfo.Local.GetUtcOffset(date1));
      Console.WriteLine(date1.ToString("o"));
      // Displays 2008-04-10T06:30:00.0000000                        
      Console.WriteLine(dateOffset.ToString("o"));
      // Displays 2008-04-10T06:30:00.0000000-07:00                       

   }
   
   private static void ShowRSpecifier()
   {
      // R Format Specifier
      // <Snippet9>
      DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
      DateTimeOffset dateOffset = new DateTimeOffset(date1, 
                                  TimeZoneInfo.Local.GetUtcOffset(date1));
      Console.WriteLine(date1.ToUniversalTime().ToString("r"));
      // Displays Thu, 10 Apr 2008 13:30:00 GMT                       
      Console.WriteLine(dateOffset.ToUniversalTime().ToString("r"));
      // Displays Thu, 10 Apr 2008 13:30:00 GMT                        
      // </Snippet9>   
   }
   
   private static void ShowSSpecifier()
   {
      // S Format Specifier
      // <Snippet10>
      DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
      Console.WriteLine(date1.ToString("s"));
      // Displays 2008-04-10T06:30:00                       
      // </Snippet10>   
   }

   private static void ShowtSpecifier()
   {
      // t Format Specifier
      // <Snippet11>
      DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
      Console.WriteLine(date1.ToString("t", 
                        CultureInfo.CreateSpecificCulture("en-us")));
      // Displays 6:30 AM                        
      Console.WriteLine(date1.ToString("t", 
                        CultureInfo.CreateSpecificCulture("es-ES")));
      // Displays 6:30                      
      // </Snippet11>   
   }
   
   private static void ShowTSpecifier()
   {
      // T Format Specifier
      // <Snippet12>
      DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
      Console.WriteLine(date1.ToString("T", 
                        CultureInfo.CreateSpecificCulture("en-us")));
      // Displays 6:30:00 AM                       
      Console.WriteLine(date1.ToString("T", 
                        CultureInfo.CreateSpecificCulture("es-ES")));
      // Displays 6:30:00                      
      // </Snippet12>   
   }
   
   private static void ShowuSpecifier()
   {
      // u Format Specifier
      // <Snippet13>
      DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
      Console.WriteLine(date1.ToUniversalTime().ToString("u"));
      // Displays 2008-04-10 13:30:00Z                       
      // </Snippet13>   
   }
   
   private static void ShowUSpecifier()
   {
      // U Format Specifier
      // <Snippet14>
      DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
      Console.WriteLine(date1.ToString("U", 
                        CultureInfo.CreateSpecificCulture("en-US")));
      // Displays Thursday, April 10, 2008 1:30:00 PM                       
      Console.WriteLine(date1.ToString("U", 
                        CultureInfo.CreateSpecificCulture("sv-FI")));
      // Displays den 10 april 2008 13:30:00                       
      // </Snippet14>   
   }
   
   private static void ShowYSpecifier()
   {
      // Y/y Format Specifier
      // <Snippet15>
      DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
      Console.WriteLine(date1.ToString("Y", 
                        CultureInfo.CreateSpecificCulture("en-US")));
      // Displays April, 2008                       
      Console.WriteLine(date1.ToString("y", 
                        CultureInfo.CreateSpecificCulture("af-ZA")));
      // Displays April 2008                       
      // </Snippet15>   
   }
}
