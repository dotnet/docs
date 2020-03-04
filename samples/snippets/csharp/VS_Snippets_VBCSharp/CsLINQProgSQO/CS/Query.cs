using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox
{
    class SQO
    {
        static void Main(string[] args)
        {
            Example1();
        }
        
        public static void Example1()
        {
            // <Snippet1>
            string sentence = "the quick brown fox jumps over the lazy dog";
            // Split the string into individual words to create a collection.
            string[] words = sentence.Split(' ');

            // Using query expression syntax.
            var query = from word in words
                        group word.ToUpper() by word.Length into gr
                        orderby gr.Key
                        select new { Length = gr.Key, Words = gr };

            // Using method-based query syntax.
            var query2 = words.
                GroupBy(w => w.Length, w => w.ToUpper()).
                Select(g => new { Length = g.Key, Words = g }).
                OrderBy(o => o.Length);

            foreach (var obj in query)
            {
                Console.WriteLine("Words of length {0}:", obj.Length);
                foreach (string word in obj.Words)
                    Console.WriteLine(word);
            }

            // This code example produces the following output:
            //
            // Words of length 3:
            // THE
            // FOX
            // THE
            // DOG
            // Words of length 4:
            // OVER
            // LAZY
            // Words of length 5:
            // QUICK
            // BROWN
            // JUMPS 
 
            // </Snippet1>
        }
    }
}
