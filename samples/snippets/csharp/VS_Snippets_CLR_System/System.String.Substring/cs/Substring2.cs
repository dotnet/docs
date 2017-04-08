// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      String s = "aaaaabbbcccccccdd";
      Char charRange = 'b';
      int startIndex = s.IndexOf(charRange);
      int endIndex = s.LastIndexOf(charRange);
      int length = endIndex - startIndex + 1;
      Console.WriteLine("{0}.Substring({1}, {2}) = {3}",
                        s, startIndex, length, 
                        s.Substring(startIndex, length));
   }
}
// The example displays the following output:
//       aaaaabbbcccccccdd.Substring(5, 3) = bbb
// </Snippet2>
