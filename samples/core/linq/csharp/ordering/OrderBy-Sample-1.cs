using System;
using System.Linq;

namespace Ordering
{
    public class OrderBy1
    {
        //This sample uses orderby to sort a list of words alphabetically.
        //Outputs to the console:
        // The sorted list of words:
        // apple
        // blueberry
        // cherry
        public static void QuerySyntaxExample()
        {
            string[] words = { "cherry", "apple", "blueberry" }; 
  
            var sortedWords = 
                from w in words 
                orderby w 
                select w; 
        
            Console.WriteLine("The sorted list of words:"); 
            
            foreach (var w in sortedWords) 
            { 
                Console.WriteLine(w); 
            } 

        }
        //This sample uses orderby to sort a list of words alphabetically.
        //Outputs to the console:
        // The sorted list of words:
        // apple
        // blueberry
        // cherry
        public static void MethodSyntaxExample()
        {
            string[] words = { "cherry", "apple", "blueberry" }; 
  
            var sortedWords = words.OrderBy(w => w); 
        
            Console.WriteLine("The sorted list of words:"); 
            
            foreach (var w in sortedWords) 
            { 
                Console.WriteLine(w); 
            } 

        }
    }
}
