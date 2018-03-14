// <Snippet1>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "ablaze beagle choral dozen elementary fanatic " +
                     "glaze hunger inept jazz kitchen lemon minus " +
                     "night optical pizza quiz restoration stamina " +
                     "train unrest vertical whiz xray yellow zealous";
      string pattern = @"\b\w*z+\w*\b";
      Match m = Regex.Match(input, pattern);
      while (m.Success) {
         Console.WriteLine("'{0}' found at position {1}", m.Value, m.Index);
         m = m.NextMatch();
      }   
   }
}
// The example displays the following output:
//    'ablaze' found at position 0
//    'dozen' found at position 21
//    'glaze' found at position 46
//    'jazz' found at position 65
//    'pizza' found at position 104
//    'quiz' found at position 110
//    'whiz' found at position 157
//    'zealous' found at position 174
// </Snippet1>
