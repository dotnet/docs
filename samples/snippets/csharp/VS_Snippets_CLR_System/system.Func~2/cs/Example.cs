// <Snippet5>
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

static class Func
{
   static void Main(string[] args)
   {
      // Declare a Func variable and assign a lambda expression to the  
      // variable. The method takes a string and converts it to uppercase.
      Func<string, string> selector = str => str.ToUpper();
   
      // Create an array of strings.
      string[] words = { "orange", "apple", "Article", "elephant" };
      // Query the array and select strings according to the selector method.
      IEnumerable<String> aWords = words.Select(selector);
   
      // Output the results to the console.
      foreach (String word in aWords)
         Console.WriteLine(word);
   }
}      
/*
This code example produces the following output:
            
   ORANGE
   APPLE
   ARTICLE
   ELEPHANT
*/
// </Snippet5>

