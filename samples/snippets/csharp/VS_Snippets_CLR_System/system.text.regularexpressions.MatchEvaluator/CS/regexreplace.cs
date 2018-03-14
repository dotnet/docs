// <Snippet1>
using System;
using System.Text.RegularExpressions;

class MyClass
{
   static void Main(string[] args)
   {
      string sInput, sRegex;

      // The string to search.
      sInput = "aabbccddeeffcccgghhcccciijjcccckkcc";

      // A very simple regular expression.
      sRegex = "cc";

      Regex r = new Regex(sRegex);
		
      MyClass c = new MyClass();

      // Assign the replace method to the MatchEvaluator delegate.
      MatchEvaluator myEvaluator = new MatchEvaluator(c.ReplaceCC);
		
      // Write out the original string.
      Console.WriteLine(sInput);

      // Replace matched characters using the delegate method.
      sInput = r.Replace(sInput, myEvaluator);
      
      // Write out the modified string.
      Console.WriteLine(sInput);
   }

   public string ReplaceCC(Match m)
   // Replace each Regex cc match with the number of the occurrence.
   {
      i++;
      return i.ToString() + i.ToString();		
   }
   public static int i=0;
}
// The example displays the following output:
//       aabbccddeeffcccgghhcccciijjcccckkcc
//       aabb11ddeeff22cgghh3344iijj5566kk77
// </Snippet1>
