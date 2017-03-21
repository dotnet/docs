            // Create an array of strings to sort.
            string[] fruits = { "apricot", "orange", "banana", "mango", "apple", "grape", "strawberry" };
            // First sort the strings by their length.
            IOrderedEnumerable<string> sortedFruits2 =
                fruits.OrderBy(fruit => fruit.Length);
            // Secondarily sort the strings alphabetically, using the default comparer.
            IOrderedEnumerable<string> sortedFruits3 =
                sortedFruits2.CreateOrderedEnumerable<string>(
                    fruit => fruit,
                    Comparer<string>.Default, false);

            // Output the resulting sequence of strings.
            foreach (string fruit in sortedFruits3)
                Console.WriteLine(fruit);

            // This code produces the following output:
            //
            // apple
            // grape
            // mango
            // banana
            // orange
            // apricot
            // strawberry
