using System;
using System.Collections.Generic;
using System.Linq;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            ThenByDescending();
        }

        static void OrderBy()
        {
            // <Snippet1>
    
            string[] words = { "the", "quick", "brown", "fox", "jumps" };

            IEnumerable<string> query = from word in words
                                        orderby word.Length
                                        select word;

            foreach (string str in query)
                Console.WriteLine(str);

            /* This code produces the following output:
              
                the
                fox
                quick
                brown
                jumps
            */

            // </Snippet1>
        }

        static void OrderByDescending()
        {
            // <Snippet2>
    
            string[] words = { "the", "quick", "brown", "fox", "jumps" };

            IEnumerable<string> query = from word in words
                                        orderby word.Substring(0, 1) descending
                                        select word;

            foreach (string str in query)
                Console.WriteLine(str);

            /* This code produces the following output:
              
                the
                quick
                jumps
                fox
                brown
            */

            // </Snippet2>
        }

        static void ThenBy()
        {
            // <Snippet3>

            string[] words = { "the", "quick", "brown", "fox", "jumps" };

            IEnumerable<string> query = from word in words
                                        orderby word.Length, word.Substring(0, 1)
                                        select word;

            foreach (string str in query)
                Console.WriteLine(str);

            /* This code produces the following output:
              
                fox
                the
                brown
                jumps
                quick
            */

            // </Snippet3>
        }

        static void ThenByDescending()
        {
            // <Snippet4>

            string[] words = { "the", "quick", "brown", "fox", "jumps" };

            IEnumerable<string> query = from word in words
                                        orderby word.Length, word.Substring(0, 1) descending
                                        select word;

            foreach (string str in query)
                Console.WriteLine(str);

            /* This code produces the following output:
              
                the
                fox
                quick
                jumps
                brown
            */

            // </Snippet4>
        }
    }
}
