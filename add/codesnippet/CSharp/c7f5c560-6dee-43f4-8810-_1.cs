            int[] ints = { 4, 8, 8, 3, 9, 0, 7, 8, 2 };

            // Count the even numbers in the array, using a seed value of 0.
            int numEven =
                ints.AsQueryable().Aggregate(
                0,
                (total, next) => next % 2 == 0 ? total + 1 : total
                );

            Console.WriteLine("The number of even integers is: {0}", numEven);

            // This code produces the following output:
            //
            // The number of even integers is: 6 
