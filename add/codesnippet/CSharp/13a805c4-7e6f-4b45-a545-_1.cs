            List<string> fruits =
                new List<string> { "apple", "passionfruit", "banana", "mango", 
                                   "orange", "blueberry", "grape", "strawberry" };

            // Get all strings whose length is less than 6.
            IEnumerable<string> query =
                fruits.AsQueryable().Where(fruit => fruit.Length < 6);

            foreach (string fruit in query)
                Console.WriteLine(fruit);

            /*
                This code produces the following output:

                apple
                mango
                grape
            */
