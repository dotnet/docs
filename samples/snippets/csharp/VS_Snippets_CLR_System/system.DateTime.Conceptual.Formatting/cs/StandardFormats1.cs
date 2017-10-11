using System;
using System.Globalization;

public class Class1
{
   public static void Main()
   {
      ShowDefaultFormat();
      UseSpecificCulture();
      UseSpecificFormattingInfo();
   }

   private static void ShowDefaultFormat() 
   {  
      // <Snippet1> (Lines 16 - 18)
      // Display using current (en-us) culture's short date format
      DateTime thisDate = new DateTime(2008, 3, 15);
      Console.WriteLine(thisDate.ToString("d"));           // Displays 3/15/2008
      // </Snippet1>
   }
   
    private static void UseSpecificCulture()
    {
      // <Snippet2> (Lines 25-28)
      // Display using pt-BR culture's short date format
      DateTime thisDate = new DateTime(2008, 3, 15);
      CultureInfo culture = new CultureInfo("pt-BR");      
      Console.WriteLine(thisDate.ToString("d", culture));  // Displays 15/3/2008
      // </Snippet2>
   }
   
   private static void UseSpecificFormattingInfo()
   {
      // <Snippet3> (Lines 35-38)
      // Display using date format information from hr-HR culture
      DateTime thisDate = new DateTime(2008, 3, 15);
      DateTimeFormatInfo fmt = (new CultureInfo("hr-HR")).DateTimeFormat;
      Console.WriteLine(thisDate.ToString("d", fmt));      // Displays 15.3.2008
      // </Snippet3>
   }
}
