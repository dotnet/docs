    class GroupExample1
    {
        static void Main()
        {
            // Create a data source.
            string[] words = { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" };

            // Create the query.
            var wordGroups =
                from w in words
                group w by w[0];

            // Execute the query.
            foreach (var wordGroup in wordGroups)
            {
                Console.WriteLine("Words that start with the letter '{0}':", wordGroup.Key);
                foreach (var word in wordGroup)
                {
                    Console.WriteLine(word);
                }
            }

            // Keep the console window open in debug mode
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }        
    }
    /* Output:
          Words that start with the letter 'b':
            blueberry
            banana
          Words that start with the letter 'c':
            chimpanzee
            cheese
          Words that start with the letter 'a':
            abacus
            apple
         */