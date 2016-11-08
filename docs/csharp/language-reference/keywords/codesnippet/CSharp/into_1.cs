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