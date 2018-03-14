// <Snippet13>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "characters";
      string[] substrings = Regex.Split(input, "");
      Console.Write("{");
      for(int ctr = 0; ctr < substrings.Length; ctr++)
      {
         Console.Write("'{0}'", substrings[ctr]);
         if (ctr < substrings.Length - 1)
            Console.Write(", ");
      }
      Console.WriteLine("}");
   }
}
// The example produces the following output:   
//    {'', 'c', 'h', 'a', 'r', 'a', 'c', 't', 'e', 'r', 's', ''}
// </Snippet13>
