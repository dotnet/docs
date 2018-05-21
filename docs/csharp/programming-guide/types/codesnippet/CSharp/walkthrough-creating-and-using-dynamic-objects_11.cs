            // Initialize an enumerable set of integers.
            int[] items = Enumerable.Range(1, 7).ToArray();

            // Randomly shuffle the array of integers by using IronPython.
            for (int i = 0; i < 5; i++)
            {
                random.shuffle(items);
                foreach (int item in items)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("-------------------");
            }