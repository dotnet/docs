            string[] fruits = { "grape", "passionfruit", "banana", "apple", 
                                  "orange", "raspberry", "mango", "blueberry" };

            // Sort the strings first by their length and then 
            // alphabetically by passing the identity selector function.
            IEnumerable<string> query =
                fruits.AsQueryable()
                .OrderBy(fruit => fruit.Length).ThenBy(fruit => fruit);

            foreach (string fruit in query)
                Console.WriteLine(fruit);

            /*
                This code produces the following output:

                apple
                grape
                mango
                banana
                orange
                blueberry
                raspberry
                passionfruit
            */
