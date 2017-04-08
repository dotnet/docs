// <Snippet9>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "Instantiating a New Type\n" +
                     "Generally, there are two ways that an\n" + 
                     "instance of a class or structure can\n" +
                     "be instantiated. ";
      string pattern = "^.*$";
      string replacement = "\n$&";
      Regex rgx = new Regex(pattern, RegexOptions.Multiline);
      string result = String.Empty; 
      
      Match match = rgx.Match(input);
      // Double space all but the first line.
      if (match.Success) 
         result = rgx.Replace(input, replacement, -1, match.Index + match.Length + 1);

      Console.WriteLine(result);                     
   }
}
// The example displays the following output:
//       Instantiating a New Type
//       
//       Generally, there are two ways that an
//       
//       instance of a class or structure can
//       
//       be instntiated.
// </Snippet9>
