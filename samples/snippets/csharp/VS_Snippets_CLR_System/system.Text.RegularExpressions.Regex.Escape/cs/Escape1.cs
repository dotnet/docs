using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      Unescaped();
      Console.WriteLine("-------");
      Escaped();
   }

   public static void Unescaped()
   {
      // <Snippet1>
      string pattern = "[(.*?)]"; 
      string input = "The animal [what kind?] was visible [by whom?] from the window.";
      
      MatchCollection matches = Regex.Matches(input, pattern);
      int commentNumber = 0;
      Console.WriteLine("{0} produces the following matches:", pattern);
      foreach (Match match in matches)
         Console.WriteLine("   {0}: {1}", ++commentNumber, match.Value);  

      // This example displays the following output:
      //       [(.*?)] produces the following matches:
      //          1: ?
      //          2: ?
      //          3: .
      // </Snippet1>
   }

   private static void Escaped()
   {
      // <Snippet2>
      string pattern = Regex.Escape("[") + "(.*?)]"; 
      string input = "The animal [what kind?] was visible [by whom?] from the window.";
      
      MatchCollection matches = Regex.Matches(input, pattern);
      int commentNumber = 0;
      Console.WriteLine("{0} produces the following matches:", pattern);
      foreach (Match match in matches)
         Console.WriteLine("   {0}: {1}", ++commentNumber, match.Value);  

      // This example displays the following output:
      //       \[(.*?)] produces the following matches:
      //          1: [what kind?]
      //          2: [by whom?]
      // </Snippet2>
   }
}
