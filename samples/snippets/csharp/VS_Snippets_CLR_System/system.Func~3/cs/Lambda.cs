// Code compiled and run on DDUESRV4
//
// <Snippet4>
using System;

public class LambdaExpression
{
   public static void Main()
   {
      char[] separators = new char[] {' '};
      Func<string, int, string[]> extract = (s, i) => 
           i > 0 ? s.Split(separators, i) : s.Split(separators) ;
         
      string title = "The Scarlet Letter";
      // Use Func instance to call ExtractWords method and display result
      foreach (string word in extract(title, 5))
         Console.WriteLine(word);
   }
}
// </Snippet4>
