// <Snippet13>
using System;
using System.Collections;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string words = "letter alphabetical missing lack release " + 
                     "penchant slack acryllic laundry cease";
      string pattern = @"\w+  # Matches all the characters in a word.";                            
      MatchEvaluator evaluator = new MatchEvaluator(WordScrambler);
      Console.WriteLine("Original words:");
      Console.WriteLine(words);
      Console.WriteLine();
      try {
         Console.WriteLine("Scrambled words:");
         Console.WriteLine(Regex.Replace(words, pattern, evaluator, 
                                         RegexOptions.IgnorePatternWhitespace,
                                         TimeSpan.FromSeconds(.25)));      
      }
      catch (RegexMatchTimeoutException) {
         Console.WriteLine("Word Scramble operation timed out.");
         Console.WriteLine("Returned words:");
      }
   }

   public static string WordScrambler(Match match)
   {
      int arraySize = match.Value.Length;
      // Define two arrays equal to the number of letters in the match.
      double[] keys = new double[arraySize];
      char[] letters = new char[arraySize];
      
      // Instantiate random number generator'
      Random rnd = new Random();
      
      for (int ctr = 0; ctr < match.Value.Length; ctr++)
      {
         // Populate the array of keys with random numbers.
         keys[ctr] = rnd.NextDouble();
         // Assign letter to array of letters.
         letters[ctr] = match.Value[ctr];
      }         
      Array.Sort(keys, letters, 0, arraySize, Comparer.Default);      
      return new String(letters);
   }
}
// The example displays output similar to the following:
//    Original words:
//    letter alphabetical missing lack release penchant slack acryllic laundry cease
//    
//    Scrambled words:
//    etlert liahepalbcat imsgsni alkc ereelsa epcnnaht lscak cayirllc alnyurd ecsae
// </Snippet13>
