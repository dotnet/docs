//Types:System.Globalization.StringInfo Vendor: Richter
//<snippet1>
using System;
using System.Text;
using System.Globalization;

public sealed class App {
   static void Main() {
      // The string below contains combining characters.
      String s = "a\u0304\u0308bc\u0327";

      // Show each 'character' in the string.
      EnumTextElements(s);

      // Show the index in the string where each 'character' starts.
      EnumTextElementIndexes(s);
   }

   // Show how to enumerate each real character (honoring surrogates) in a string.
   static void EnumTextElements(String s) {
      // This StringBuilder holds the output results.
      StringBuilder sb = new StringBuilder();

      // Use the enumerator returned from GetTextElementEnumerator 
      // method to examine each real character.
      TextElementEnumerator charEnum = StringInfo.GetTextElementEnumerator(s);
      while (charEnum.MoveNext()) {
         sb.AppendFormat(
           "Character at index {0} is '{1}'{2}",
           charEnum.ElementIndex, charEnum.GetTextElement(),
           Environment.NewLine);
      }

      // Show the results.
      Console.WriteLine("Result of GetTextElementEnumerator:");
      Console.WriteLine(sb);
   }

   // Show how to discover the index of each real character (honoring surrogates) in a string.
   static void EnumTextElementIndexes(String s) {
      // This StringBuilder holds the output results.
      StringBuilder sb = new StringBuilder();

      // Use the ParseCombiningCharacters method to 
      // get the index of each real character in the string.
      Int32[] textElemIndex = StringInfo.ParseCombiningCharacters(s);

      // Iterate through each real character showing the character and the index where it was found.
      for (Int32 i = 0; i < textElemIndex.Length; i++) {
         sb.AppendFormat(
            "Character {0} starts at index {1}{2}",
            i, textElemIndex[i], Environment.NewLine);
      }

      // Show the results.
      Console.WriteLine("Result of ParseCombiningCharacters:");
      Console.WriteLine(sb);
   }
}

// This code produces the following output.
//
// Result of GetTextElementEnumerator:
// Character at index 0 is 'a-"'
// Character at index 3 is 'b'
// Character at index 4 is 'c,'
// 
// Result of ParseCombiningCharacters:
// Character 0 starts at index 0
// Character 1 starts at index 3
// Character 2 starts at index 4
//</snippet1>