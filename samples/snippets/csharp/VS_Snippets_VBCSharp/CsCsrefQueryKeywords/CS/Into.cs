﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntoClause
{
    //<snippet18>
    class IntoSample1
    {
        static void Main()
        {

            // Create a data source.
            string[] words = { "apples", "blueberries", "oranges", "bananas", "apricots"};

            // Create the query.
            var wordGroups1 =
                from w in words
                group w by w[0] into fruitGroup
                where fruitGroup.Count() >= 2
                select new { FirstLetter = fruitGroup.Key, Words = fruitGroup.Count() };

            // Execute the query. Note that we only iterate over the groups,
            // not the items in each group
            foreach (var item in wordGroups1)
            {
                Console.WriteLine(" {0} has {1} elements.", item.FirstLetter, item.Words);
            }

            // Keep the console window open in debug mode
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    /* Output:
       a has 2 elements.
       b has 2 elements.
    */
    //</snippet18>

    //<snippet19>
    class IntoSample2
    {
        static void Main()
        {
            //Create a data source
            string[] words2 = { "apples", "blueberries", "oranges", "bananas" };

            //Create a query
            var wordGroups2 =
                from w in words2
                group w by w[0];

            // Nested foreach loop to iterate over groups
            // and the items in each group.
            foreach (var item in wordGroups2)
            {
                Console.WriteLine("Words that start with the letter '{0}':", item.Key);
                foreach (var w in item)
                {
                    Console.WriteLine(w);
                }
            }

            // Keep the console window open in debug mode
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    /* Output:
        Words that start with the letter 'a':
        apples
        Words that start with the letter 'b':
        blueberries
        bananas
        Words that start with the letter 'o':
        oranges
     */
    //</snippet19>
}
