            int[] id1 = { 44, 26, 92, 30, 71, 38 };
            int[] id2 = { 39, 59, 83, 47, 26, 4, 30 };

            // Get the numbers that occur in both arrays (id1 and id2).
            IEnumerable<int> both = id1.AsQueryable().Intersect(id2);

            foreach (int id in both)
                Console.WriteLine(id);

            /*
                This code produces the following output:

                26
                30
            */
