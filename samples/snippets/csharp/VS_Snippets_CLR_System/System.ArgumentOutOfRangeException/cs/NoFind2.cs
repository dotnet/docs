// <Snippet18>
using System;

public class Example
{
   public static void Main()
   {
      String[] phrases = { "ocean blue", "concerned citizen", 
                           "runOnPhrase" };
      foreach (var phrase in phrases) {
         String word = GetSecondWord(phrase);
         if (! String.IsNullOrEmpty(word))
            Console.WriteLine("Second word is {0}", word);
      }   
   }
  
   static String GetSecondWord(String s)
   {
      int pos = s.IndexOf(" ");
      if (pos >= 0)
         return s.Substring(pos).Trim();
      else
         return String.Empty;   
   }
}
// The example displays the following output:
//       Second word is blue
//       Second word is citizen
// </Snippet18>

