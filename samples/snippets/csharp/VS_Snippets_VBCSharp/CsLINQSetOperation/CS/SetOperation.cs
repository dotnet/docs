using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Union();
        }

        private static void Distinct()
        {
            // <Snippet1>
            string[] planets = ["Mercury", "Venus", "Venus", "Earth", "Mars", "Earth"];

            IEnumerable<string> query = from planet in planets.Distinct()
                                        select planet;

            foreach (var str in query)
            {
                Console.WriteLine(str);
            }

            /* This code produces the following output:
             *
             * Mercury
             * Venus
             * Earth
             * Mars
             */
            // </Snippet1>
        }

        private static void Except()
        {
            // <Snippet2>
            string[] planets1 = ["Mercury", "Venus", "Earth", "Jupiter"];
            string[] planets2 = ["Mercury", "Earth", "Mars", "Jupiter"];

            IEnumerable<string> query = from planet in planets1.Except(planets2)
                                        select planet;

            foreach (var str in query)
            {
                Console.WriteLine(str);
            }

            /* This code produces the following output:
             *
             * Venus
             */
            // </Snippet2>
        }

        private static void Intersect()
        {
            // <Snippet3>
            string[] planets1 = ["Mercury", "Venus", "Earth", "Jupiter"];
            string[] planets2 = ["Mercury", "Earth", "Mars", "Jupiter"];

            IEnumerable<string> query = from planet in planets1.Intersect(planets2)
                                        select planet;

            foreach (var str in query)
            {
                Console.WriteLine(str);
            }

            /* This code produces the following output:
             *
             * Mercury
             * Earth
             * Jupiter
             */
            // </Snippet3>
        }

        private static void Union()
        {
            // <Snippet4>
            string[] planets1 = ["Mercury", "Venus", "Earth", "Jupiter"];
            string[] planets2 = ["Mercury", "Earth", "Mars", "Jupiter"];

            IEnumerable<string> query = from planet in planets1.Union(planets2)
                                        select planet;

            foreach (var str in query)
            {
                Console.WriteLine(str);
            }

            /* This code produces the following output:
             *
             * Mercury
             * Venus
             * Earth
             * Jupiter
             * Mars
             */
            // </Snippet4>
        }
    }
}
