            // Create an array of strings to sort.
            string[] fruits = { "apricot", "orange", "banana", "mango", "apple", "grape", "strawberry" };

            // Sort the strings first by their length and then alphabetically
            // by passing the identity selector function.
            IOrderedEnumerable<string> sortedFruits1 =
                fruits.OrderBy(fruit => fruit.Length).ThenBy(fruit => fruit);

            // Output the resulting sequence of strings.
            foreach (string fruit in sortedFruits1)
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
