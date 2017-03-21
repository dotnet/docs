            int[] numbers = { 0, 30, 20, 15, 90, 85, 40, 75 };

            // Get all the numbers that are less than or equal to
            // the product of their index in the array and 10.
            IEnumerable<int> query =
                numbers.AsQueryable()
                .Where((number, index) => number <= index * 10);

            foreach (int number in query)
                Console.WriteLine(number);

            /*
                This code produces the following output:

                0
                20
                15
                40
            */
