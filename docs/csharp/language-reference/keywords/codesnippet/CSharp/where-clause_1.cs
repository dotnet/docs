    class WhereSample
    {
        static void Main()
        {   
            // Simple data source. Arrays support IEnumerable<T>.
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // Simple query with one predicate in where clause.
            var queryLowNums =
                from num in numbers
                where num < 5
                select num;

            // Execute the query.
            foreach (var s in queryLowNums)
            {
                Console.Write(s.ToString() + " ");
            }
        }
    }
    //Output: 4 1 3 2 0