    class WhereSample3
    {       
        static void Main()
        {
            // Data source
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // Create the query with a method call in the where clause.
            // Note: This won't work in LINQ to SQL unless you have a
            // stored procedure that is mapped to a method by this name.
            var queryEvenNums =
                from num in numbers
                where IsEven(num)
                select num;

             // Execute the query.
            foreach (var s in queryEvenNums)
            {
                Console.Write(s.ToString() + " ");
            }
        }

        // Method may be instance method or static method.
        static bool IsEven(int i)
        {
            return i % 2 == 0;
        }    
    }
    //Output: 4 8 6 2 0