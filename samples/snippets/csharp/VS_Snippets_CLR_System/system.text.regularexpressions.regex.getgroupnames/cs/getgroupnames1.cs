// <Snippet1>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b(?<FirstWord>\w+)\s?((\w+)\s)*(?<LastWord>\w+)?(?<Punctuation>\p{Po})";
      string input = "The cow jumped over the moon.";
      Regex rgx = new Regex(pattern);
      Match match = rgx.Match(input);
      if (match.Success)
         ShowMatches(rgx, match);
   }

   private static void ShowMatches(Regex r, Match m)
   {
      string[] names = r.GetGroupNames();
      Console.WriteLine("Named Groups:");
      foreach (var name in names) {
         Group grp = m.Groups[name];
         Console.WriteLine("   {0}: '{1}'", name, grp.Value);
      }
   }
}
// The example displays the following output:
//       Named Groups:
//          0: 'The cow jumped over the moon.'
//          1: 'the '
//          2: 'the'
//          FirstWord: 'The'
//          LastWord: 'moon'
//          Punctuation: '.'
// </Snippet1>
