            int[] numbers = { 1, 2, 3, 4 };
            string[] words = { "one", "two", "three" };

            var numbersAndWords = numbers.AsQueryable().Zip(words, (first, second) => first + " " + second);

            foreach (var item in numbersAndWords)
                Console.WriteLine(item);

            // This code produces the following output:

            // 1 one
            // 2 two
            // 3 three
