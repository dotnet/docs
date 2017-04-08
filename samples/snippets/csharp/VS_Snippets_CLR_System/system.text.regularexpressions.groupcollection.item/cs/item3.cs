// <Snippet2>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"(\d+)*(\w)\2";
      string input = "AA";
      Match match = Regex.Match(input, pattern);
      
      // Get the first named group.
      Group group1 = match.Groups[1];
      Console.WriteLine("Group 1 value: {0}", group1.Success ? group1.Value : "Empty");
      
      // Get the second named group.
      Group group2 = match.Groups[2];
      Console.WriteLine("Group 2 value: {0}", group2.Success ? group2.Value : "Empty");
      
      // Get a non-existent group.
      Group group3 = match.Groups[3];
      Console.WriteLine("Group 3 value: {0}", group3.Success ? group3.Value : "Empty");
   }
}
// The example displays the following output:
//       Group 1 value: Empty
//       Group 2 value: A
//       Group 3 value: Empty
// </Snippet2>   
