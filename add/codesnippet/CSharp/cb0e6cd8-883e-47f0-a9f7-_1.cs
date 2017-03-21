            string[] fruits = { "apple", "passionfruit", "banana", "mango", 
                                  "orange", "blueberry", "grape", "strawberry" };

            // Take strings from the array until a string whose length
            // is less than its index in the array is found.
            IEnumerable<string> query =
                fruits.AsQueryable()
                .TakeWhile((fruit, index) => fruit.Length >= index);

            foreach (string fruit in query)
                Console.WriteLine(fruit);

            /*
                This code produces the following output:

                apple
                passionfruit
                banana
                mango
                orange
                blueberry
            */
