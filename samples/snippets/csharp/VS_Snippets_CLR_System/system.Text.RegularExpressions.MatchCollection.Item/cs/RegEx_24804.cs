// <Snippet1>
using System;
using System.Text.RegularExpressions;

public class Class1
{
   public static void Main()
   {   
      string sentence = "Half-way down a by-street of one of our New England towns, stands a rusty wooden " +
                         "house, with seven acutely peaked gables, facing towards various points of the compass, " + 
                         "and a huge, clustered chimney in the midst.";
      string pattern = @"\b[hH]\w*\b"; 
      MatchCollection matches = Regex.Matches(sentence, pattern);
      for (int ctr=0; ctr < matches.Count; ctr++)
      {
         Console.WriteLine(matches[ctr].Value);   
      }   
   }
}
// </Snippet1>
