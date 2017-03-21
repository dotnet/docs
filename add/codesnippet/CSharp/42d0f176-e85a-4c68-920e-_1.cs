            string[] fruits = { "apple", "banana", "mango", "orange", 
                                  "passionfruit", "grape" };

            // Take strings from the array until a string
            // that is equal to "orange" is found.
            IEnumerable<string> query =
                fruits.AsQueryable()
                .TakeWhile(fruit => String.Compare("orange", fruit, true) != 0);

            foreach (string fruit in query)
                Console.WriteLine(fruit);

            /*
                This code produces the following output:

                apple
                banana
                mango
            */
