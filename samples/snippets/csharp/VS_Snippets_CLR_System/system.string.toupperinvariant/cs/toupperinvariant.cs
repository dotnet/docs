// <Snippet1>
using System;
using System.IO;

public class Example
{
   public static void Main()
   {
      string[] words = { "Tuesday", "Salı", "Вторник", "Mardi", 
                         "Τρίτη", "Martes", "יום שלישי", 
                         "الثلاثاء", "วันอังคาร" };
      StreamWriter sw = new StreamWriter(@".\output.txt");
            
      // Display array in unsorted order.
      foreach (string word in words)
         sw.WriteLine(word);

      sw.WriteLine();

      // Create parallel array of words by calling ToUpperInvariant.
      string[] upperWords = new string[words.Length];
      for (int ctr = words.GetLowerBound(0); ctr <= words.GetUpperBound(0); ctr++)
         upperWords[ctr] = words[ctr].ToUpperInvariant();
      
      // Sort the words array based on the order of upperWords.
      Array.Sort(upperWords, words, StringComparer.InvariantCulture);
      
      // Display the sorted array.
      foreach (string word in words)
         sw.WriteLine(word);

      sw.Close();      
   }
}
// The example produces the following output:
//       Tuesday
//       Salı
//       Вторник
//       Mardi
//       Τρίτη
//       Martes
//       יום שלישי
//       الثلاثاء
//       วันอังคาร
//       
//       Mardi
//       Martes
//       Salı
//       Tuesday
//       Τρίτη
//       Вторник
//       יום שלישי
//       الثلاثاء
//       วันอังคาร
// </Snippet1>
