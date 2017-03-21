            double[] numbers1 = { 2.0, 2.1, 2.2, 2.3, 2.4, 2.5 };
            double[] numbers2 = { 2.2 };

            // Get the numbers from the first array that
            // are NOT in the second array.
            IEnumerable<double> onlyInFirstSet =
                numbers1.AsQueryable().Except(numbers2);

            foreach (double number in onlyInFirstSet)
                Console.WriteLine(number);

            /*
                This code produces the following output:

                2
                2.1
                2.3
                2.4
                2.5
            */
