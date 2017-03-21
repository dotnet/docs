            int[] amounts = { 5000, 2500, 9000, 8000, 
                                6500, 4000, 1500, 5500 };

            // Skip over amounts in the array until the first amount
            // that is less than or equal to the product of its
            // index in the array and 1000. Take the remaining items.
            IEnumerable<int> query =
                amounts.AsQueryable()
                .SkipWhile((amount, index) => amount > index * 1000);

            foreach (int amount in query)
                Console.WriteLine(amount);

            /*
                This code produces the following output:

                4000
                1500
                5500
            */
