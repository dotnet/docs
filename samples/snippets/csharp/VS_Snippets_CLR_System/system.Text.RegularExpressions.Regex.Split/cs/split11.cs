// <Snippet11>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "characters";
      Regex regex = new Regex("");
      string[] substrings = regex.Split(input);
      Console.Write("{");
      for(int ctr = 0; ctr < substrings.Length; ctr++)
      {
         Console.Write(substrings[ctr]);
         if (ctr < substrings.Length - 1)
            Console.Write(", ");
      }
      Console.WriteLine("}");
   }
}
// The example displays the following output:   
//    {, c, h, a, r, a, c, t, e, r, s, }
// </Snippet11>
