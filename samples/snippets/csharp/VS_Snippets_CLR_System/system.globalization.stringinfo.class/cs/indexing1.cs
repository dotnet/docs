// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      // The Unicode code points specify Arabic base characters and 
      // combining character sequences.
      string strCombining = "\u0627\u0655\u0650\u064A\u0647\u064E" +
                            "\u0627\u0628\u064C";

      // The Unicode code points specify private surrogate pairs.
      string strSurrogates = Char.ConvertFromUtf32(0x10148) +
                             Char.ConvertFromUtf32(0x20026) + "a" +
                             Char.ConvertFromUtf32(0xF1001);
      
      EnumerateTextElements(strCombining);
      EnumerateTextElements(strSurrogates);
   }

   public static void EnumerateTextElements(string str)
   {
      // Get the Enumerator.
      TextElementEnumerator teEnum = null;      

      // Parse the string using the ParseCombiningCharacters method.
      Console.WriteLine("\nParsing with ParseCombiningCharacters:");
      int[] teIndices = StringInfo.ParseCombiningCharacters(str);
      
      for (int i = 0; i < teIndices.Length; i++) {
         if (i < teIndices.Length - 1)
            Console.WriteLine("Text Element {0} ({1}..{2})= {3}", i, 
               teIndices[i], teIndices[i + 1] - 1, 
               ShowHexValues(str.Substring(teIndices[i], teIndices[i + 1] - 
                             teIndices[i])));
         else
            Console.WriteLine("Text Element {0} ({1}..{2})= {3}", i, 
               teIndices[i], str.Length - 1, 
               ShowHexValues(str.Substring(teIndices[i])));
      }
      Console.WriteLine();

      // Parse the string with the GetTextElementEnumerator method.
      Console.WriteLine("Parsing with TextElementEnumerator:");
      teEnum = StringInfo.GetTextElementEnumerator(str);

      int teCount = - 1;

      while (teEnum.MoveNext()) {
         // Displays the current element.
         // Both GetTextElement() and Current retrieve the current
         // text element. The latter returns it as an Object.
         teCount++;
         Console.WriteLine("Text Element {0} ({1}..{2})= {3}", teCount, 
            teEnum.ElementIndex, teEnum.ElementIndex + 
            teEnum.GetTextElement().Length - 1, ShowHexValues((string)(teEnum.Current)));
      }
   }
   
   private static string ShowHexValues(string s)
   {
      string hexString = "";
      foreach (var ch in s)
         hexString += String.Format("{0:X4} ", Convert.ToUInt16(ch));

      return hexString;
   }
}
// The example displays the following output:
//       Parsing with ParseCombiningCharacters:
//       Text Element 0 (0..2)= 0627 0655 0650
//       Text Element 1 (3..3)= 064A
//       Text Element 2 (4..5)= 0647 064E
//       Text Element 3 (6..6)= 0627
//       Text Element 4 (7..8)= 0628 064C
//       
//       Parsing with TextElementEnumerator:
//       Text Element 0 (0..2)= 0627 0655 0650
//       Text Element 1 (3..3)= 064A
//       Text Element 2 (4..5)= 0647 064E
//       Text Element 3 (6..6)= 0627
//       Text Element 4 (7..8)= 0628 064C
//       
//       Parsing with ParseCombiningCharacters:
//       Text Element 0 (0..1)= D800 DD48
//       Text Element 1 (2..3)= D840 DC26
//       Text Element 2 (4..4)= 0061
//       Text Element 3 (5..6)= DB84 DC01
//       
//       Parsing with TextElementEnumerator:
//       Text Element 0 (0..1)= D800 DD48
//       Text Element 1 (2..3)= D840 DC26
//       Text Element 2 (4..4)= 0061
//       Text Element 3 (5..6)= DB84 DC01
// </Snippet1>