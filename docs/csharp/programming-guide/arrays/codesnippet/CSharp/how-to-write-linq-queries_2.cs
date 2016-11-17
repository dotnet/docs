            List<int> numbers1 = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            List<int> numbers2 = new List<int>() { 15, 14, 11, 13, 19, 18, 16, 17, 12, 10 };
            // Query #4.
            double average = numbers1.Average();

            // Query #5.
            IEnumerable<int> concatenationQuery = numbers1.Concat(numbers2);