using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Projection
{
    class Projection
    {
        static void Main(string[] args)
        {
            SelectMany();
        }

        static void Select()
        {
            // <Snippet1>

            List<string> words = new List<string>() { "an", "apple", "a", "day" };

            var query = from word in words
                        select word.Substring(0, 1);

            foreach (string s in query)
                Console.WriteLine(s);

            /* This code produces the following output:
              
                a
                a
                a
                d
            */

            // </Snippet1>
        }

        static void SelectMany()
        {
            // <Snippet2>
    
            List<string> phrases = new List<string>() { "an apple a day", "the quick brown fox" };

            var query = from phrase in phrases
                        from word in phrase.Split(' ')
                        select word;

            foreach (string s in query)
                Console.WriteLine(s);

            /* This code produces the following output:
              
                an
                apple
                a
                day
                the
                quick
                brown
                fox
            */

            // </Snippet2>
        }

        // <Snippet3>
        class Bouquet
        {
            public List<string> Flowers { get; set; }
        }

        static void SelectVsSelectMany()
        {
            List<Bouquet> bouquets = new List<Bouquet>() {
                new Bouquet { Flowers = new List<string> { "sunflower", "daisy", "daffodil", "larkspur" }},
                new Bouquet{ Flowers = new List<string> { "tulip", "rose", "orchid" }},
                new Bouquet{ Flowers = new List<string> { "gladiolis", "lily", "snapdragon", "aster", "protea" }},
                new Bouquet{ Flowers = new List<string> { "larkspur", "lilac", "iris", "dahlia" }}
            };

            // *********** Select ***********            
            IEnumerable<List<string>> query1 = bouquets.Select(bq => bq.Flowers);

            // ********* SelectMany *********
            IEnumerable<string> query2 = bouquets.SelectMany(bq => bq.Flowers);

            Console.WriteLine("Results by using Select():");
            // Note the extra foreach loop here.
            foreach (IEnumerable<String> collection in query1)
                foreach (string item in collection)
                    Console.WriteLine(item);

            Console.WriteLine("\nResults by using SelectMany():");
            foreach (string item in query2)
                Console.WriteLine(item);

            /* This code produces the following output:
              
               Results by using Select():
                sunflower
                daisy
                daffodil
                larkspur
                tulip
                rose
                orchid
                gladiolis
                lily
                snapdragon
                aster
                protea
                larkspur
                lilac
                iris
                dahlia

               Results by using SelectMany():
                sunflower
                daisy
                daffodil
                larkspur
                tulip
                rose
                orchid
                gladiolis
                lily
                snapdragon
                aster
                protea
                larkspur
                lilac
                iris
                dahlia
            */

        }
        // </Snippet3>
    }
}
