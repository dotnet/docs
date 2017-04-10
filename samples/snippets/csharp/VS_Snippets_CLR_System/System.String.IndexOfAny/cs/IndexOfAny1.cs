// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      char[] chars = { 'a', 'e', 'i', 'o', 'u', 'y', 
                       'A', 'E', 'I', 'O', 'U', 'Y' };
      String s = "The long and winding road...";
      Console.WriteLine("The first vowel in \n   {0}\nis found at position {1}", 
                        s, s.IndexOfAny(chars) + 1);                         
   }
}
// The example displays the following output:
//       The first vowel in
//          The long and winding road...
//       is found at position 3
// </Snippet1>

