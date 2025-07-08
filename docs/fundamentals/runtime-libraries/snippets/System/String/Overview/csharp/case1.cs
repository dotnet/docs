// <Snippet7>
using System;
using System.Globalization;
using System.IO;

public class Example
{
   public static void Main()
   {
      StreamWriter sw = new StreamWriter(@".\case.txt");   
      string[] words = { "file", "sıfır", "ǅenana" };
      CultureInfo[] cultures = { CultureInfo.InvariantCulture, 
                                 new CultureInfo("en-US"),  
                                 new CultureInfo("tr-TR") };

      foreach (var word in words) {
         sw.WriteLine("{0}:", word);
         foreach (var culture in cultures) {
            string name = String.IsNullOrEmpty(culture.Name) ? 
                                 "Invariant" : culture.Name;
            string upperWord = word.ToUpper(culture);
            sw.WriteLine("   {0,10}: {1,7} {2, 38}", name, 
                         upperWord, ShowHexValue(upperWord));
         }
         sw.WriteLine();  
      }
      sw.Close();
   }

   private static string ShowHexValue(string s)
   {
      string retval = null;
      foreach (var ch in s) {
         byte[] bytes = BitConverter.GetBytes(ch);
         retval += String.Format("{0:X2} {1:X2} ", bytes[1], bytes[0]);     
      }
      return retval;
   } 
}
// The example displays the following output:
//    file:
//        Invariant:    FILE               00 46 00 49 00 4C 00 45 
//            en-US:    FILE               00 46 00 49 00 4C 00 45 
//            tr-TR:    FİLE               00 46 01 30 00 4C 00 45 
//    
//    sıfır:
//        Invariant:   SıFıR         00 53 01 31 00 46 01 31 00 52 
//            en-US:   SIFIR         00 53 00 49 00 46 00 49 00 52 
//            tr-TR:   SIFIR         00 53 00 49 00 46 00 49 00 52 
//    
//    ǅenana:
//        Invariant:  ǅENANA   01 C5 00 45 00 4E 00 41 00 4E 00 41 
//            en-US:  ǄENANA   01 C4 00 45 00 4E 00 41 00 4E 00 41 
//            tr-TR:  ǄENANA   01 C4 00 45 00 4E 00 41 00 4E 00 41 
// </Snippet7>  
