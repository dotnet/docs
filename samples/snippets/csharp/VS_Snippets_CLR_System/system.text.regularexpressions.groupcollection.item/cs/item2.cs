// <Snippet1>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"(?<numbers>\d+)*(?<letter>\w)\k<letter>";
      string input = "AA";
      Match match = Regex.Match(input, pattern);
      
      // Get the first named group.
      Group group1 = match.Groups["numbers"];
      Console.WriteLine("Group 'numbers' value: {0}", group1.Success ? group1.Value : "Empty");
      
      // Get the second named group.
      Group group2 = match.Groups["letter"];
      Console.WriteLine("Group 'letter' value: {0}", group2.Success ? group2.Value : "Empty");
      
      // Get a non-existent group.
      Group group3 = match.Groups["none"];
      Console.WriteLine("Group 'none' value: {0}", group3.Success ? group3.Value : "Empty");
   }
}
// The example displays the following output:
//       Group 'numbers' value: Empty
//       Group 'letter' value: A
//       Group 'none' value: Empty
// </Snippet1>   
