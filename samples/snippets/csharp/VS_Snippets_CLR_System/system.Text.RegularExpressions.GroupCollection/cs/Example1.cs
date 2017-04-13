// <Snippet1>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b(\w+?)([\u00AE\u2122])";
      string input = "Microsoft® Office Professional Edition combines several office " +
                     "productivity products, including Word, Excel®, Access®, Outlook®, " +
                     "PowerPoint®, and several others. Some guidelines for creating " +
                     "corporate documents using these productivity tools are available " +
                     "from the documents created using Silverlight™ on the corporate " +
                     "intranet site.";
      
      MatchCollection matches = Regex.Matches(input, pattern);
      foreach (Match match in matches)
      {
         GroupCollection groups = match.Groups;
         Console.WriteLine("{0}: {1}", groups[2], groups[1]);
      }                               
      Console.WriteLine();
      Console.WriteLine("Found {0} trademarks or registered trademarks.", matches.Count);
   }
}
// The example displays the following output:
//       r: Microsoft
//       r: Excel
//       r: Access
//       r: Outlook
//       r: PowerPoint
//       T: Silverlight
// </Snippet1>
