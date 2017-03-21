            string[] fruits = { "apple", "banana", "mango", 
                                "orange", "passionfruit", "grape" };

            int numberOfFruits = fruits.AsQueryable().Count();

            Console.WriteLine(
                "There are {0} items in the array.",
                numberOfFruits);

            // This code produces the following output:
            //
            // There are 6 items in the array. 
