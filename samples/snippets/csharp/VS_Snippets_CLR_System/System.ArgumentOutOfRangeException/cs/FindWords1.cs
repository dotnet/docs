// <Snippet19>
using System;
using System.Collections.Generic;

public class Example
{
   public static void Main()
   {
      String sentence = "This is a simple, short sentence.";
      Console.WriteLine("Words in '{0}':", sentence);
      foreach (var word in FindWords(sentence))
         Console.WriteLine("   '{0}'", word);
   }
   
   static String[] FindWords(String s)
   {
      int start = 0, end = 0;
      Char[] delimiters = { ' ', '.', ',', ';', ':', '(', ')' };
      var words = new List<String>();

      while (end >= 0) {
         end = s.IndexOfAny(delimiters, start);
         if (end >= 0) {
            if (end - start > 0)
               words.Add(s.Substring(start, end - start)); 

            start = end++;
         }
         else {
            if (start < s.Length - 1)
               words.Add(s.Substring(start));
         }
      }    
      return words.ToArray();                         
   }
}
// The example displays the following output:
//       Words in 'This is a simple, short sentence.':
//          'This'
//          'is'
//          'a'
//          'simple'
//          'short'
//          'sentence'
// </Snippet19>


