// <Snippet7>
using System;

public class Example
{
   public static void Main()
   {
      string[] separators = {",", ".", "!", "?", ";", ":", " "};
      string value = "The handsome, energetic, young dog was playing with his smaller, more lethargic litter mate.";
      string[] words = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
      foreach (var word in words)
         Console.WriteLine(word);
   }
}
// The example displays the following output:
//       The
//       handsome
//       energetic
//       young
//       dog
//       was
//       playing
//       with
//       his
//       smaller
//       more
//       lethargic
//       litter
//       mate
// </Snippet7>
