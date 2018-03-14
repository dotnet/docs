// <Snippet1>
using System;

delegate string[] ExtractMethod(string stringToManipulate, int maximum);

public class DelegateExample
{
   public static void Main()
   {
      // Instantiate delegate to reference ExtractWords method
      ExtractMethod extractMeth = ExtractWords;
      string title = "The Scarlet Letter";
      // Use delegate instance to call ExtractWords method and display result
      foreach (string word in extractMeth(title, 5))
         Console.WriteLine(word);
   }

   private static string[] ExtractWords(string phrase, int limit)
   {
      char[] delimiters = new char[] {' '};
      if (limit > 0)
         return phrase.Split(delimiters, limit);
      else
         return phrase.Split(delimiters);
   }
}
// </Snippet1>
