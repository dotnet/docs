// <Snippet3>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      ConsoleKeyInfo keyEntered;
      char beginComment, endComment;
      Console.Write("Enter begin comment symbol: ");
      keyEntered = Console.ReadKey();
      beginComment = keyEntered.KeyChar;
      Console.WriteLine();
      
      Console.Write("Enter end comment symbol: ");
      keyEntered = Console.ReadKey();
      endComment = keyEntered.KeyChar;
      Console.WriteLine();
      
      string input = "Text [comment comment comment] more text [comment]";
      string pattern;
      pattern = Regex.Escape(beginComment.ToString()) + @"(.*?)";
      string endPattern = Regex.Escape(endComment.ToString());
      if (endComment == ']' || endComment == '}') endPattern = @"\" + endPattern;
      pattern += endPattern;
      MatchCollection matches = Regex.Matches(input, pattern);
      Console.WriteLine(pattern);
      int commentNumber = 0;
      foreach (Match match in matches)
         Console.WriteLine("{0}: {1}", ++commentNumber, match.Groups[1].Value);
         
   }
}
// The example shows possible output from the example:
//       Enter begin comment symbol: [
//       Enter end comment symbol: ]
//       \[(.*?)\]
//       1: comment comment comment
//       2: comment
// </Snippet3>
