// <Snippet2>
using System;
using Utilities.RegularExpressions;

public class CompiledRegexUsage
{
   public static void Main()
   {
      string text = "The the quick brown fox  fox jumped over the lazy dog dog.";
      DuplicatedString duplicateRegex = new DuplicatedString(); 
      if (duplicateRegex.Matches(text).Count > 0)
         Console.WriteLine("There are {0} duplicate words in \n   '{1}'", 
            duplicateRegex.Matches(text).Count, text);
      else
         Console.WriteLine("There are no duplicate words in \n   '{0}'", 
                           text);
   }
}
// The example displays the following output to the console:
//    There are 3 duplicate words in
//       'The the quick brown fox  fox jumped over the lazy dog dog.'
// </Snippet2>
