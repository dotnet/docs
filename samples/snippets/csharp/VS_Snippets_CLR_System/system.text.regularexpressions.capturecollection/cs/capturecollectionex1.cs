// <Snippet1>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern;  
      string input = "The young, hairy, and tall dog slowly walked across the yard.";
      Match match;

      // Match a word with a pattern that has no capturing groups.
      pattern = @"\b\w+\W{1,2}";
      match = Regex.Match(input, pattern);
      Console.WriteLine("Pattern: " + pattern);
      Console.WriteLine("Match: " + match.Value);
      Console.WriteLine("  Match.Captures: {0}", match.Captures.Count);
      for (int ctr = 0; ctr < match.Captures.Count; ctr++)
         Console.WriteLine("    {0}: '{1}'", ctr, match.Captures[ctr].Value);
      Console.WriteLine("  Match.Groups: {0}", match.Groups.Count);
      for (int groupCtr = 0; groupCtr < match.Groups.Count; groupCtr++)
      {
         Console.WriteLine("    Group {0}: '{1}'", 
                           groupCtr, match.Groups[groupCtr].Value);
         Console.WriteLine("    Group({0}).Captures: {1}", 
                           groupCtr, match.Groups[groupCtr].Captures.Count);
         for (int captureCtr = 0; captureCtr < match.Groups[groupCtr].Captures.Count; captureCtr++)
            Console.WriteLine("      Capture {0}: '{1}'", 
                              captureCtr, 
                              match.Groups[groupCtr].Captures[captureCtr].Value);
      }
      Console.WriteLine("-----\n");

      // Match a sentence with a pattern that has a quantifier that 
      // applies to the entire group.
      pattern = @"(\b\w+\W{1,2})+";
      match = Regex.Match(input, pattern);
      Console.WriteLine("Pattern: " + pattern);
      Console.WriteLine("Match: " + match.Value);
      Console.WriteLine("  Match.Captures: {0}", match.Captures.Count);
      for (int ctr = 0; ctr < match.Captures.Count; ctr++)
         Console.WriteLine("    {0}: '{1}'", ctr, match.Captures[ctr].Value);
      
      Console.WriteLine("  Match.Groups: {0}", match.Groups.Count);
      for (int groupCtr = 0; groupCtr < match.Groups.Count; groupCtr++)
      {
         Console.WriteLine("    Group {0}: '{1}'", groupCtr, match.Groups[groupCtr].Value);
         Console.WriteLine("    Group({0}).Captures: {1}", 
                           groupCtr, match.Groups[groupCtr].Captures.Count);
         for (int captureCtr = 0; captureCtr < match.Groups[groupCtr].Captures.Count; captureCtr++)
            Console.WriteLine("      Capture {0}: '{1}'", captureCtr, match.Groups[groupCtr].Captures[captureCtr].Value);
      }
   }
}
// The example displays the following output:
//    Pattern: \b\w+\W{1,2}
//    Match: The
//      Match.Captures: 1
//        0: 'The '
//      Match.Groups: 1
//        Group 0: 'The '
//        Group(0).Captures: 1
//          Capture 0: 'The '
//    -----
//    
//    Pattern: (\b\w+\W{1,2})+
//    Match: The young, hairy, and tall dog slowly walked across the yard.
//      Match.Captures: 1
//        0: 'The young, hairy, and tall dog slowly walked across the yard.'
//      Match.Groups: 2
//        Group 0: 'The young, hairy, and tall dog slowly walked across the yard.'
//        Group(0).Captures: 1
//          Capture 0: 'The young, hairy, and tall dog slowly walked across the yard.'
//        Group 1: 'yard.'
//        Group(1).Captures: 11
//          Capture 0: 'The '
//          Capture 1: 'young, '
//          Capture 2: 'hairy, '
//          Capture 3: 'and '
//          Capture 4: 'tall '
//          Capture 5: 'dog '
//          Capture 6: 'slowly '
//          Capture 7: 'walked '
//          Capture 8: 'across '
//          Capture 9: 'the '
//          Capture 10: 'yard.'
// </Snippet1>
