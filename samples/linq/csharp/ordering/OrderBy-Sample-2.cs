using System;
using System.Linq;

namespace Ordering
{
    public class OrderBy2
    {
        //This sample uses orderby to sort a list of words by length.
        //Outputs to the console:
        // The sorted list of words (by length):
        //  apple
        //  cherry
        //  blueberry
        public static void QuerySyntaxExample()
        {
            string[] words = { "cherry", "apple", "blueberry" }; 
        
            var sortedWords = 
                from w in words 
                orderby w.Length 
                select w; 
        
            Console.WriteLine("The sorted list of words (by length):"); 
            foreach (var w in sortedWords) 
            { 
                Console.WriteLine(w); 
            }
        } 
        //This sample uses orderby to sort a list of words by length.
        //Outputs to the console:
        // The sorted list of words (by length):
        //  apple
        //  cherry
        //  blueberry
        public static void MethodSyntaxExample()
        {
            string[] words = { "cherry", "apple", "blueberry" }; 
  
            var sortedWords = words.OrderBy(w => w.Length); 
        
            Console.WriteLine("The sorted list of words:"); 
            
            foreach (var w in sortedWords) 
            { 
                Console.WriteLine(w); 
            } 

        }
    }
}
