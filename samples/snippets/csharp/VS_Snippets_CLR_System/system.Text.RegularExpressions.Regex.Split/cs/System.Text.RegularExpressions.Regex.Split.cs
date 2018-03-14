using System;
using System.Text.RegularExpressions;

public class RegexSplit
{
   public static void Main()
   {
      RegexSplit rs = new RegexSplit();
      
      Console.WriteLine("Splitting 10 occurrences on a null string starting at 'a'");
      rs.Split14();
      
//       Console.WriteLine("Calling static Regex.Split(string, string, RegexOptions)");
//       rs.Split11();
//       Console.WriteLine("Calling static Regex.Split with capturing parentheses and RegexOptions:");
//       rs.Split12();
//       Console.WriteLine("Calling static Regex.Split with multiple capturing parentheses and RegexOptions:");
//       rs.Split13();
   }



   private void Split14()
   {
      string input = "characters";
      Regex regex = new Regex("");
      string[] substrings = regex.Split(input, input.Length, input.IndexOf("a"));
      Console.Write("{");
      for(int ctr = 0; ctr < substrings.Length; ctr++)
      {
         Console.Write(substrings[ctr]);
         if (ctr < substrings.Length - 1)
            Console.Write(", ");
      }
      Console.WriteLine("}");
      // The example produces the following output:   
      //    {, c, h, a, r, a, c, t, e, rs}
   }
}
