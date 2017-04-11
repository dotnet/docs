// <Snippet1>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b((?<word>\w+)\s*)+(?<end>[.?!])";
      string input = "This is a sentence. This is a second sentence.";
      
      Regex rgx = new Regex(pattern);
      int[] groupNumbers = rgx.GetGroupNumbers();
      Match m = rgx.Match(input);
      if (m.Success) {
         Console.WriteLine("Match: {0}", m.Value);
         foreach (var groupNumber in groupNumbers) {
            string name = rgx.GroupNameFromNumber(groupNumber);
            int number;
            Console.WriteLine("   Group {0}{1}: '{2}'", 
                              groupNumber, 
                              ! string.IsNullOrEmpty(name) & 
                              ! Int32.TryParse(name, out number) ?
                                 " (" + name + ")" : String.Empty, 
                              m.Groups[groupNumber].Value);
         }
      } 
   }
}
// The example displays the following output:
//       Match: This is a sentence.
//          Group 0: 'This is a sentence.'
//          Group 1: 'sentence'
//          Group 2 (word): 'sentence'
//          Group 3 (end): '.'
// </Snippet1>