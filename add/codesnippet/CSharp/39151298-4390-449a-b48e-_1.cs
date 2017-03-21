            List<int> range =
                new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Project the square of each int value.
            IEnumerable<int> squares =
                range.AsQueryable().Select(x => x * x);

            foreach (int num in squares)
                Console.WriteLine(num);

            /*
                This code produces the following output:

                1
                4
                9
                16
                25
                36
                49
                64
                81
                100
            */
