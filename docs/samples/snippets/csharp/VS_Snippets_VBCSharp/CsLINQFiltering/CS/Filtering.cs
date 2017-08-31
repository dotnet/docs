using System;
using System.Collections.Generic;
using System.Linq;

namespace Filtering
{
    class Program
    {
        static void Main(string[] args)
        {
            Where();
        }

        static void Where()
        {
            // <Snippet1>

            string[] words = { "the", "quick", "brown", "fox", "jumps" };

            IEnumerable<string> query = from word in words
                                        where word.Length == 3
                                        select word;

            foreach (string str in query)
                Console.WriteLine(str);

            /* This code produces the following output:
              
                the
                fox
            */

            // </Snippet1>
        }
    }
}
