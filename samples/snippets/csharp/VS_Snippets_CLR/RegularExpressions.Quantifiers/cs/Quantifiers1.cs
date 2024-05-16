using System;
using System.Text.RegularExpressions;

[assembly: CLSCompliant(true)]
public class Class1
{
   public static void Main()
   {
      Console.WriteLine("* quantifier:");
      ShowStar();
      Console.WriteLine();
      Console.WriteLine("+ quantifier:");
      ShowPlus();
      Console.WriteLine();
      Console.WriteLine("? quantifier:");
      ShowQuestion();
      Console.WriteLine();
      Console.WriteLine("{n} quantifier:");
      ShowN();
      Console.WriteLine();
      Console.WriteLine("{n,} quantifier:");
      ShowNComma();
      Console.WriteLine();
      Console.WriteLine("{n,m} quantifier:");
      ShowNM();
      Console.WriteLine();
      Console.WriteLine("*? quantifier:");
      ShowLazyStar();
      Console.WriteLine();
      Console.WriteLine("+? quantifier:");
      ShowLazyPlus();
      Console.WriteLine();
      Console.WriteLine("?? quantifier:");
      ShowLazyQuestion();
      Console.WriteLine();
      Console.WriteLine("{n}? quantifier:");
      ShowLazyN();
      Console.WriteLine();
      Console.WriteLine("{n,}? quantifier: NO EXAMPLE");
      ShowLazyNComma();
      Console.WriteLine();
      Console.WriteLine("{n,m}? quantifier:");
      ShowLazyNM();
   }

   private static void ShowStar()
   {
      // <Snippet1>
      string pattern = @"\b91*9*\b";
      string input = "99 95 919 929 9119 9219 999 9919 91119";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index);

      // The example displays the following output:
      //       '99' found at position 0.
      //       '919' found at position 6.
      //       '9119' found at position 14.
      //       '999' found at position 24.
      //       '91119' found at position 33.
      // </Snippet1>
   }

   private static void ShowPlus()
   {
      // <Snippet2>
      string pattern = @"\ban+\w*?\b";

      string input = "Autumn is a great time for an annual announcement to all antique collectors.";
      foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
         Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index);

      // The example displays the following output:
      //       'an' found at position 27.
      //       'annual' found at position 30.
      //       'announcement' found at position 37.
      //       'antique' found at position 57.
      // </Snippet2>
   }

   private static void ShowQuestion()
   {
      // <Snippet3>
      string pattern = @"\ban?\b";
      string input = "An amiable animal with a large snout and an animated nose.";
      foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
         Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index);

      // The example displays the following output:
      //        'An' found at position 0.
      //        'a' found at position 23.
      //        'an' found at position 42.
      //  </Snippet3>
   }

   private static void ShowN()
   {
      //  <Snippet4>
      string pattern = @"\b\d+\,\d{3}\b";
      string input = "Sales totaled 103,524 million in January, " +
                            "106,971 million in February, but only " +
                            "943 million in March.";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index);

      //  The example displays the following output:
      //        '103,524' found at position 14.
      //        '106,971' found at position 45.
      //  </Snippet4>
   }

   private static void ShowNComma()
   {
      //  <Snippet5>
      string pattern = @"\b\d{2,}\b\D+";
      string input = "7 days, 10 weeks, 300 years";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index);

      //  The example displays the following output:
      //        '10 weeks, ' found at position 8.
      //        '300 years' found at position 18.
      //  </Snippet5>
   }

   private static void ShowNM()
   {
      //  <Snippet6>
      string pattern = @"(00\s){2,4}";
      string input = "0x00 FF 00 00 18 17 FF 00 00 00 21 00 00 00 00 00";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index);

      //  The example displays the following output:
      //        '00 00 ' found at position 8.
      //        '00 00 00 ' found at position 23.
      //        '00 00 00 00 ' found at position 35.
      //  </Snippet6>
   }

   private static void ShowLazyStar()
   {
      //  <Snippet7>
       string pattern = @"\b\w*?oo\w*?\b";
       string input = "woof root root rob oof woo woe";
       foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
          Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index);

       //  The example displays the following output:
      //        'woof' found at position 0.
      //        'root' found at position 5.
      //        'root' found at position 10.
      //        'oof' found at position 19.
      //        'woo' found at position 23.
      //  </Snippet7>
   }

   private static void ShowLazyPlus()
   {
      //  <Snippet8>
      string pattern = @"\b\w+?\b";
      string input = "Aa Bb Cc Dd Ee Ff";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index);

      //  The example displays the following output:
      //        'Aa' found at position 0.
      //        'Bb' found at position 3.
      //        'Cc' found at position 6.
      //        'Dd' found at position 9.
      //        'Ee' found at position 12.
      //        'Ff' found at position 15.
      //  </Snippet8>
   }

   private static void ShowLazyQuestion()
   {
      //  <Snippet9>
      string pattern = @"^\s*(System.)??Console.Write(Line)??\(??";
      string input = "System.Console.WriteLine(\"Hello!\")\n" +
                            "Console.Write(\"Hello!\")\n" +
                            "Console.WriteLine(\"Hello!\")\n" +
                            "Console.ReadLine()\n" +
                            "   Console.WriteLine";
      foreach (Match match in Regex.Matches(input, pattern,
                                            RegexOptions.IgnorePatternWhitespace |
                                            RegexOptions.IgnoreCase |
                                            RegexOptions.Multiline))
         Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index);

      //  The example displays the following output:
      //        'System.Console.Write' found at position 0.
      //        'Console.Write' found at position 36.
      //        'Console.Write' found at position 61.
      //        '   Console.Write' found at position 110.
      //  </Snippet9>
   }

   private static void ShowLazyN()
   {
      //  <Snippet10>
      string pattern = @"\b(\w{3,}?\.){2}?\w{3,}?\b";
      string input = "www.microsoft.com msdn.microsoft.com mywebsite mycompany.com";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index);

      //  The example displays the following output:
      //        'www.microsoft.com' found at position 0.
      //        'msdn.microsoft.com' found at position 18.
      //  </Snippet10>
   }

   private static void ShowLazyNComma()
   {
   }

   private static void ShowLazyNM()
   {
      //  <Snippet12>
      string pattern = @"\b[A-Z](\w*?\s*?){1,10}[.!?]";
      string input = "Hi. I am writing a short note. Its purpose is " +
                            "to test a regular expression that attempts to find " +
                            "sentences with ten or fewer words. Most sentences " +
                            "in this note are short.";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index);

      //  The example displays the following output:
      //        'Hi.' found at position 0.
      //        'I am writing a short note.' found at position 4.
      //        'Most sentences in this note are short.' found at position 132.
      //  </Snippet12>
   }
}
