// <Snippet3>
using System;

public class Anonymous
{
   public static void Main()
   {
      Func<string, int, string[]> extractMeth = delegate(string s, int i)
         { char[] delimiters = new char[] {' '}; 
           return i > 0 ? s.Split(delimiters, i) : s.Split(delimiters);
         };
      
      string title = "The Scarlet Letter";
      // Use Func instance to call ExtractWords method and display result
      foreach (string word in extractMeth(title, 5))
         Console.WriteLine(word);
   }
}
// </Snippet3>
