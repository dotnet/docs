// <Snippet11>
using System;
using System.Collections.Generic;

public class Example
{
   public static void Main()
   {
      String value = "This is the first sentence in a string. " +
                     "More sentences will follow. For example, " +
                     "this is the third sentence. This is the " +
                     "fourth. And this is the fifth and final " +
                     "sentence.";
      var sentences = new List<String>();
      int position = 0;
      int start = 0;
      // Extract sentences from the string.
      do {
         position = value.IndexOf('.', start);
         if (position >= 0) {
            sentences.Add(value.Substring(start, position - start + 1).Trim());
            start = position + 1;
         }
      } while (position > 0);

      // Display the sentences.
      foreach (var sentence in sentences)
         Console.WriteLine(sentence);
   }
}
// The example displays the following output:
//       This is the first sentence in a string.
//       More sentences will follow.
//       For example, this is the third sentence.
//       This is the fourth.
//       And this is the fifth and final sentence.
// </Snippet11>
