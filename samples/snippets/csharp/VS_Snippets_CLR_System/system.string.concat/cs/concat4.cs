// <Snippet1>
using System;
using System.Collections;

public class Example
{
   public static void Main()
   {
      const int WORD_SIZE = 4;
      
      // Define some 4-letter words to be scrambled.
      string[] words = { "home", "food", "game", "rest" };
      // Define two arrays equal to the number of letters in each word.
      double[] keys = new double[WORD_SIZE];
      string[] letters = new string[WORD_SIZE];
      // Initialize the random number generator.
      Random rnd = new Random();
      
      // Scramble each word.
      foreach (string word in words)
      {
         for (int ctr = 0; ctr < word.Length; ctr++)
         {
            // Populate the array of keys with random numbers.
            keys[ctr] = rnd.NextDouble();
            // Assign a letter to the array of letters.
            letters[ctr] = word[ctr].ToString();
         }   
         // Sort the array. 
         Array.Sort(keys, letters, 0, WORD_SIZE, Comparer.Default);      
         // Display the scrambled word.
         string scrambledWord = String.Concat(letters[0], letters[1], 
                                              letters[2], letters[3]);
         Console.WriteLine("{0} --> {1}", word, scrambledWord);
      } 
   }
}
// The example displays output like the following:
//       home --> mheo
//       food --> oodf
//       game --> aemg
//       rest --> trse
// </Snippet1>