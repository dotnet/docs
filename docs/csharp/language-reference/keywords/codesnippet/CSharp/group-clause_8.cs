    class GroupClauseExample2
    {
        static void Main()
        {
            // Create the data source.
            string[] words2 = { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese", "elephant", "umbrella", "anteater" };

            // Create the query.
            var wordGroups2 =
                from w in words2
                group w by w[0] into grps
                where (grps.Key == 'a' || grps.Key == 'e' || grps.Key == 'i'
                       || grps.Key == 'o' || grps.Key == 'u')
                select grps;

            // Execute the query.
            foreach (var wordGroup in wordGroups2)
            {
                Console.WriteLine("Groups that start with a vowel: {0}", wordGroup.Key);
                foreach (var word in wordGroup)
                {
                    Console.WriteLine("   {0}", word);
                }
            }

            // Keep the console window open in debug mode
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    /* Output:
        Groups that start with a vowel: a
            abacus
            apple
            anteater
        Groups that start with a vowel: e
            elephant
        Groups that start with a vowel: u
            umbrella
    */    