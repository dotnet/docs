// The following code example shows how to create a CultureInfo for "Spanish - Spain" with the international sort and another with the traditional sort.


// <snippet1>
using System;
using System.Collections;
using System.Globalization;

public class SamplesCultureInfo
{

   public static void Main()
   {

      // Creates and initializes the CultureInfo which uses the international sort.
      CultureInfo myCIintl = new CultureInfo("es-ES", false);

      // Creates and initializes the CultureInfo which uses the traditional sort.
      CultureInfo myCItrad = new CultureInfo(0x040A, false);

      // Displays the properties of each culture.
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "PROPERTY", "INTERNATIONAL", "TRADITIONAL");
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "CompareInfo", myCIintl.CompareInfo, myCItrad.CompareInfo);
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "DisplayName", myCIintl.DisplayName, myCItrad.DisplayName);
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "EnglishName", myCIintl.EnglishName, myCItrad.EnglishName);
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "IsNeutralCulture", myCIintl.IsNeutralCulture, myCItrad.IsNeutralCulture);
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "IsReadOnly", myCIintl.IsReadOnly, myCItrad.IsReadOnly);
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "LCID", myCIintl.LCID, myCItrad.LCID);
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "Name", myCIintl.Name, myCItrad.Name);
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "NativeName", myCIintl.NativeName, myCItrad.NativeName);
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "Parent", myCIintl.Parent, myCItrad.Parent);
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "TextInfo", myCIintl.TextInfo, myCItrad.TextInfo);
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "ThreeLetterISOLanguageName", myCIintl.ThreeLetterISOLanguageName, myCItrad.ThreeLetterISOLanguageName);
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "ThreeLetterWindowsLanguageName", myCIintl.ThreeLetterWindowsLanguageName, myCItrad.ThreeLetterWindowsLanguageName);
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "TwoLetterISOLanguageName", myCIintl.TwoLetterISOLanguageName, myCItrad.TwoLetterISOLanguageName);
      Console.WriteLine();

      // Compare two strings using myCIintl.
      Console.WriteLine("Comparing \"llegar\" and \"lugar\"");
      Console.WriteLine("   With myCIintl.CompareInfo.Compare: {0}", myCIintl.CompareInfo.Compare("llegar", "lugar"));
      Console.WriteLine("   With myCItrad.CompareInfo.Compare: {0}", myCItrad.CompareInfo.Compare("llegar", "lugar"));

   }

}

/*
This code produces the following output.

PROPERTY                       INTERNATIONAL                                  TRADITIONAL              
CompareInfo                    CompareInfo - es-ES                            CompareInfo - es-ES_tradnl
DisplayName                    Spanish (Spain)                                Spanish (Spain)          
EnglishName                    Spanish (Spain, International Sort)            Spanish (Spain, Traditional Sort)
IsNeutralCulture               False                                          False                    
IsReadOnly                     False                                          False                    
LCID                           3082                                           1034                     
Name                           es-ES                                          es-ES                    
NativeName                     Español (España, alfabetización internacional) Español (España, alfabetización tradicional)
Parent                         es                                             es                       
TextInfo                       TextInfo - es-ES                               TextInfo - es-ES_tradnl  
ThreeLetterISOLanguageName     spa                                            spa                      
ThreeLetterWindowsLanguageName ESN                                            ESP                      
TwoLetterISOLanguageName       es                                             es                       

Comparing "llegar" and "lugar"
   With myCIintl.CompareInfo.Compare: -1
   With myCItrad.CompareInfo.Compare: 1

*/
// </snippet1>
