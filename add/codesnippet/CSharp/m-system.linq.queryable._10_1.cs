            string[] fruits = { "apple", "banana", "mango", 
                                "orange", "passionfruit", "grape" };

            // The string to search for in the array.
            string mango = "mango";

            bool hasMango = fruits.AsQueryable().Contains(mango);

            Console.WriteLine(
                "The array {0} contain '{1}'.",
                hasMango ? "does" : "does not",
                mango);

            // This code produces the following output:
            //
            // The array does contain 'mango'. 
