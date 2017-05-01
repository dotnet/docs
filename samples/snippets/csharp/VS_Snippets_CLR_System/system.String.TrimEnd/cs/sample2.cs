// <Snippet2>
using System;

public class TrimEnd
{
   public static void Main()
   {
      string sentence = "The dog had a bone, a ball, and other toys.";
      char[] charsToTrim = {',', '.', ' '};
      string[] words = sentence.Split();
      foreach (string word in words)
         Console.WriteLine(word.TrimEnd(charsToTrim));
   }
}
// The example displays the following output:
//       The
//       dog
//       had
//       a
//       bone
//       a
//       ball
//       and
//       other
//       toys
// </Snippet2>
