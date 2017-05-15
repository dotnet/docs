using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "This is a string.";
      string pattern = @"\b\w+\b";
      Regex regex = new Regex(pattern);
      
      // <Snippet5>
      Match match = regex.Match(input);
      while (match.Success) {
            // Handle match here...

            match = match.NextMatch();
      }  
      // </Snippet5>         
   }

   public static void Main2()
   {
      string input = "This is a string.";
      string pattern = @"\b\w+\b";
      Regex regex = new Regex(pattern);
      int startAt = 0;
      
      // <Snippet6>
      Match match = regex.Match(input, startAt);
      while (match.Success) {
            // Handle match here...

            match = match.NextMatch();
      }  
      // </Snippet6>         
   }

   public static void Main3()
   {
      string input = "This is a string.";
      string pattern = @"\b\w+\b";
      
      // <Snippet7>
      Match match = Regex.Match(input, pattern);
      while (match.Success) {
            // Handle match here...

            match = match.NextMatch();
      }  
      // </Snippet7>  
   }   
             
   public static void Main8()
   {
      string input = "This is a string.";
      string pattern = @"\b\w+\b";
      RegexOptions options = RegexOptions.None;
      
      // <Snippet8>
      Match match = Regex.Match(input, pattern, options);
      while (match.Success) {
            // Handle match here...

            match = match.NextMatch();
      }  
      // </Snippet8>         
   }

   public static void Main10()
   {
      string input = "This is a string.";
      string pattern = @"\b\w+\b";
      RegexOptions options = RegexOptions.None;
      
      // <Snippet10>
      try {
         Match match = Regex.Match(input, pattern, options,
                                   TimeSpan.FromSeconds(1));
         while (match.Success) {
               // Handle match here...
   
               match = match.NextMatch();
         }  
      }
      catch (RegexMatchTimeoutException) {
         // Do nothing: assume that exception represents no match.
      }
      // </Snippet10>         
   }
}

