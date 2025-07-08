using System;
using System.IO;
using System.Text.RegularExpressions;

public class CachingExample
{
   public static void Main()
   {
      string filename = @".\Caching1.txt";
      // <Snippet1>
      StreamReader sr = new StreamReader(filename);
      string input;
      string pattern = @"\b(\w+)\s\1\b";
      while (sr.Peek() >= 0)
      {
         input = sr.ReadLine();
         Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
         MatchCollection matches = rgx.Matches(input);
         if (matches.Count > 0)
         {
            Console.WriteLine($"{input} ({matches.Count} matches):");
            foreach (Match match in matches)
               Console.WriteLine("   " + match.Value);
         }
      }
      sr.Close();   
      // </Snippet1>
      Console.WriteLine();
      Main2();
   }

   public static void Main2()
   {
      string filename = @".\Caching1.txt";
      // <Snippet2>
      StreamReader sr = new StreamReader(filename);
      string input;
      string pattern = @"\b(\w+)\s\1\b";
      Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
      
      while (sr.Peek() >= 0)
      {
         input = sr.ReadLine();
         MatchCollection matches = rgx.Matches(input);
         if (matches.Count > 0)
         {
            Console.WriteLine($"{input} ({matches.Count} matches):");
            foreach (Match match in matches)
               Console.WriteLine("   " + match.Value);
         }
      }
      sr.Close();   
      // </Snippet2>
   }
}
