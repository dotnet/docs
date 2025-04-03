// <Snippet23>
using System;

public class Example
{
   public static void Main()
   {
      String phrase = "a cold, dark night";
      Console.WriteLine($"Before: {phrase}");
      phrase = phrase.Replace(",", "");
      Console.WriteLine($"After: {phrase}");
   }
}
// The example displays the following output:
//       Before: a cold, dark night
//       After: a cold dark night
// </Snippet23>