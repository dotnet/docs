// <Snippet5>
using System;
using System.Collections.Generic;
using System.Linq;

public class Func3Example
{
   public static void Main()
   {
      Func<String, int, bool> predicate = (str, index) => str.Length == index;

      String[] words = { "orange", "apple", "Article", "elephant", "star", "and" };
      IEnumerable<String> aWords = words.Where(predicate).Select(str => str);

      foreach (String word in aWords)
         Console.WriteLine(word);
   }
}
// </Snippet5>
