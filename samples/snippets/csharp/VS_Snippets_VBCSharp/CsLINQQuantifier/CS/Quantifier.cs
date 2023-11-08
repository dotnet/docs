using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            All.Example();
            Any.Example();
            Contains.Example();
        }

        static class All
        {
            // <SnippetAll>
            class Market
            {
                public string Name { get; set; }
                public string[] Items { get; set; }
            }

            public static void Example()
            {
                List<Market> markets =
                [
                    new Market { Name = "Emily's", Items = ["kiwi", "cheery", "banana"] },
                    new Market { Name = "Kim's", Items = ["melon", "mango", "olive"] },
                    new Market { Name = "Adam's", Items = ["kiwi", "apple", "orange"] },
                ];

                // Determine which market have all fruit names length equal to 5
                IEnumerable<string> names = from market in markets
                                            where market.Items.All(item => item.Length == 5)
                                            select market.Name;

                foreach (string name in names)
                {
                    Console.WriteLine($"{name} market");
                }

                // This code produces the following output:
                //
                // Kim's market
            }
            // </SnippetAll>
        }

        static class Any
        {
            // <SnippetAny>
            class Market
            {
                public string Name { get; set; }
                public string[] Items { get; set; }
            }

            public static void Example()
            {
                List<Market> markets =
                [
                    new Market { Name = "Emily's", Items = ["kiwi", "cheery", "banana"] },
                    new Market { Name = "Kim's", Items = ["melon", "mango", "olive"] },
                    new Market { Name = "Adam's", Items = ["kiwi", "apple", "orange"] },
                ];

                // Determine which market have any fruit names start with 'o'
                IEnumerable<string> names = from market in markets
                                            where market.Items.Any(item => item.StartsWith("o"))
                                            select market.Name;

                foreach (string name in names)
                {
                    Console.WriteLine($"{name} market");
                }

                // This code produces the following output:
                //
                // Kim's market
                // Adam's market
            }
            // </SnippetAny>
        }

        static class Contains
        {
            // <SnippetContains>
            class Market
            {
                public string Name { get; set; }
                public string[] Items { get; set; }
            }

            public static void Example()
            {
                List<Market> markets =
                [
                    new Market { Name = "Emily's", Items = ["kiwi", "cheery", "banana"] },
                    new Market { Name = "Kim's", Items = ["melon", "mango", "olive"] },
                    new Market { Name = "Adam's", Items = ["kiwi", "apple", "orange"] },
                ];

                // Determine which market contains fruit names equal 'kiwi'
                IEnumerable<string> names = from market in markets
                                            where market.Items.Contains("kiwi")
                                            select market.Name;

                foreach (string name in names)
                {
                    Console.WriteLine($"{name} market");
                }

                // This code produces the following output:
                //
                // Emily's market
                // Adam's market
            }
            // </SnippetContains>
        }
    }
}
