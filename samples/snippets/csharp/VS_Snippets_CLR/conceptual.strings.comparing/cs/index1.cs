// <Snippet2>
using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()
   {
      string str1 = "æble";
      string str2 = "aeble";
      char find = 'æ';

      // Create CultureInfo objects representing the Danish (Denmark)
      // and English (United States) cultures.
      CultureInfo[] cultures = { CultureInfo.CreateSpecificCulture("da-DK"), 
                                 CultureInfo.CreateSpecificCulture("en-US") };

      foreach (var ci in cultures) {
         Thread.CurrentThread.CurrentCulture = ci;
                                                  
         int result1 = ci.CompareInfo.IndexOf(str1, find);
         int result2 = ci.CompareInfo.IndexOf(str2, find);
         int result3 = ci.CompareInfo.IndexOf(str1, find,  
                                              CompareOptions.Ordinal);
         int result4 = ci.CompareInfo.IndexOf(str2, find, 
                                              CompareOptions.Ordinal);      
   
         Console.WriteLine("\nThe current culture is {0}", 
                           CultureInfo.CurrentCulture.Name);
         Console.WriteLine("\n   CompareInfo.IndexOf(string, char) method:");
         Console.WriteLine("   Position of {0} in the string {1}: {2}", 
                           find, str1, result1);

         Console.WriteLine("\n   CompareInfo.IndexOf(string, char) method:");
         Console.WriteLine("   Position of {0} in the string {1}: {2}", 
                           find, str2, result2);

         Console.WriteLine("\n   CompareInfo.IndexOf(string, char, CompareOptions.Ordinal) method");
         Console.WriteLine("   Position of {0} in the string {1}: {2}", 
                           find, str1, result3);

         Console.WriteLine("\n   CompareInfo.IndexOf(string, char, CompareOptions.Ordinal) method");
         Console.WriteLine("   Position of {0} in the string {1}: {2}", 
                           find, str2, result4);
         Console.WriteLine();
      }   
   }
}
// The example displays the following output
//    The current culture is da-DK
//    
//       CompareInfo.IndexOf(string, char) method:
//       Position of æ in the string æble: 0
//    
//       CompareInfo.IndexOf(string, char) method:
//       Position of æ in the string aeble: -1
//    
//       CompareInfo.IndexOf(string, char, CompareOptions.Ordinal) method
//       Position of æ in the string æble: 0
//    
//       CompareInfo.IndexOf(string, char, CompareOptions.Ordinal) method
//       Position of æ in the string aeble: -1
//    
//    
//    The current culture is en-US
//    
//       CompareInfo.IndexOf(string, char) method:
//       Position of æ in the string æble: 0
//    
//       CompareInfo.IndexOf(string, char) method:
//       Position of æ in the string aeble: 0
//    
//       CompareInfo.IndexOf(string, char, CompareOptions.Ordinal) method
//       Position of æ in the string æble: 0
//    
//       CompareInfo.IndexOf(string, char, CompareOptions.Ordinal) method
//       Position of æ in the string aeble: -1
// </Snippet2>