// <Snippet1>
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"(?<city>[A-Za-z\s]+), (?<state>[A-Za-z]{2}) (?<zip>\d{5}(-\d{4})?)";
      string[] cityLines = {"New York, NY 10003", "Brooklyn, NY 11238", "Detroit, MI 48204", 
                            "San Francisco, CA 94109", "Seattle, WA 98109" };
      Regex rgx = new Regex(pattern);
      List<string> names = new List<string>();
      int ctr = 1;
      bool exitFlag = false;
      // Get group names.
      do {
         string name = rgx.GroupNameFromNumber(ctr);
         if (! String.IsNullOrEmpty(name))
         {
            ctr++;
            names.Add(name);
         }
         else
         {
            exitFlag = true;
         }
      } while (! exitFlag);

      foreach (string cityLine in cityLines)
      {
         Match match = rgx.Match(cityLine);
         if (match.Success)
            Console.WriteLine("Zip code {0} is in {1}, {2}.", 
                               match.Groups[names[3]], 
                               match.Groups[names[1]], 
                               match.Groups[names[2]]);
      } 
   }
}
// The example displays the following output:
//       Zip code 10003 is in New York, NY.
//       Zip code 11238 is in Brooklyn, NY.
//       Zip code 48204 is in Detroit, MI.
//       Zip code 94109 is in San Francisco, CA.
//       Zip code 98109 is in Seattle, WA.
// </Snippet1>
