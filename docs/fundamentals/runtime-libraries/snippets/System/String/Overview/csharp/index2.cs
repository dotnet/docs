using System;

public class Example11
{
   public static void Main()
   {
      // <Snippet5>
      string s1 = "This string consists of a single short sentence.";
      int nWords = 0;

      s1 = s1.Trim();      
      foreach (var ch in s1) {
         if (Char.IsPunctuation(ch) | Char.IsWhiteSpace(ch))
            nWords++;              
      }
      Console.WriteLine($"The sentence\n   {s1}\nhas {nWords} words.");                                                                     
      // The example displays the following output:
      //       The sentence
      //          This string consists of a single short sentence.
      //       has 8 words.
      // </Snippet5>
   }
}
