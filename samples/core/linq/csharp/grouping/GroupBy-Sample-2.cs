using System.Linq;
using System;

namespace Grouping
{
    public class GroupBy2
    {
        //This sample uses group by to partition a list of words by their first letter.
        //Outputs the following to the console:
        //   Words that start with the letter 'b':
        //   blueberry
        //   banana
        //   Words that start with the letter 'c':
        //   chimpanzee
        //   cheese
        //   Words that start with the letter 'a':
        //   abacus
        //   apple
        public static void QuerySyntaxExample() 
        { 
            string[] words = { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" }; 
        
            var wordGroups = 
                from w in words 
                group w by w[0] into g 
                select new { FirstLetter = g.Key, Words = g }; 
        
            foreach (var g in wordGroups) 
            { 
                Console.WriteLine("Words that start with the letter '{0}':", g.FirstLetter); 
                foreach (var w in g.Words) 
                { 
                    Console.WriteLine(w); 
                }
            }
        }
        //This sample uses group by to partition a list of words by their first letter.
        //Outputs the following to the console:
        //   Words that start with the letter 'b':
        //   blueberry
        //   banana
        //   Words that start with the letter 'c':
        //   chimpanzee
        //   cheese
        //   Words that start with the letter 'a':
        //   abacus
        //   apple
        public static void MethodSyntaxExample() 
        {
            string[] words = { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" }; 

            var wordGroups = words.GroupBy(w => w[0], 
                 (Key, g) => new { FirstLetter = Key, Words = g });

            foreach (var g in wordGroups) 
            { 
                Console.WriteLine("Words that start with the letter '{0}':", g.FirstLetter); 
                foreach (var w in g.Words) 
                { 
                    Console.WriteLine(w); 
                }
            }
        }
    }
}
