using System;

public class Example7
{
   public static void Main()
   {
      // <Snippet4>
      string s1 = "This string consists of a single short sentence.";
      int nWords = 0;

      s1 = s1.Trim();      
      for (int ctr = 0; ctr < s1.Length; ctr++) {
         if (Char.IsPunctuation(s1[ctr]) | Char.IsWhiteSpace(s1[ctr]))
            nWords++;              
      }
      Console.WriteLine($"""
      The sentence
         {s1}
       has {nWords} words.
       """);                                                                     
      // The example displays the following output:
      //       The sentence
      //          This string consists of a single short sentence.
      //       has 8 words.
      // </Snippet4>
   }
}
