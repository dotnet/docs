using System;
using System.Collections.Generic;

public class Example12
{
   public static void Main()
   {
      // <Snippet6>
      // First sentence of The Mystery of the Yellow Room, by Leroux.
      string opening = "Ce n'est pas sans une certaine émotion que "+
                       "je commence à raconter ici les aventures " +
                       "extraordinaires de Joseph Rouletabille."; 
      // Character counters.
      int nChars = 0;
      // Objects to store word count.
      List<int> chars = new List<int>();
      List<int> elements = new List<int>();
      
      foreach (var ch in opening) {
         // Skip the ' character.
         if (ch == '\u0027') continue;
              
         if (Char.IsWhiteSpace(ch) | (Char.IsPunctuation(ch))) {
            chars.Add(nChars);
            nChars = 0;
         }
         else {
            nChars++;
         }
      }

      System.Globalization.TextElementEnumerator te = 
         System.Globalization.StringInfo.GetTextElementEnumerator(opening);
      while (te.MoveNext()) {
         string s = te.GetTextElement();   
         // Skip the ' character.
         if (s == "\u0027") continue;
         if ( String.IsNullOrEmpty(s.Trim()) | (s.Length == 1 && Char.IsPunctuation(Convert.ToChar(s)))) {
            elements.Add(nChars);         
            nChars = 0;
         }
         else {
            nChars++;
         }
      }

      // Display character counts.
      Console.WriteLine("{0,6} {1,20} {2,20}",
                        "Word #", "Char Objects", "Characters"); 
      for (int ctr = 0; ctr < chars.Count; ctr++) 
         Console.WriteLine("{0,6} {1,20} {2,20}",
                           ctr, chars[ctr], elements[ctr]); 
      // The example displays the following output:
      //       Word #         Char Objects           Characters
      //            0                    2                    2
      //            1                    4                    4
      //            2                    3                    3
      //            3                    4                    4
      //            4                    3                    3
      //            5                    8                    8
      //            6                    8                    7
      //            7                    3                    3
      //            8                    2                    2
      //            9                    8                    8
      //           10                    2                    1
      //           11                    8                    8
      //           12                    3                    3
      //           13                    3                    3
      //           14                    9                    9
      //           15                   15                   15
      //           16                    2                    2
      //           17                    6                    6
      //           18                   12                   12
      // </Snippet6>   
   }
}
