    class CompoundFrom2
    {
        static void Main()
        {
            char[] upperCase = { 'A', 'B', 'C' };
            char[] lowerCase = { 'x', 'y', 'z' };

            // The type of joinQuery1 is IEnumerable<'a>, where 'a
            // indicates an anonymous type. This anonymous type has two
            // members, upper and lower, both of type char.
            var joinQuery1 =
                from upper in upperCase
                from lower in lowerCase
                select new { upper, lower };

            // The type of joinQuery2 is IEnumerable<'a>, where 'a
            // indicates an anonymous type. This anonymous type has two
            // members, upper and lower, both of type char.
            var joinQuery2 =
                from lower in lowerCase
                where lower != 'x'
                from upper in upperCase
                select new { lower, upper };


            // Execute the queries.
            Console.WriteLine("Cross join:");
            // Rest the mouse pointer on joinQuery1 to verify its type.
            foreach (var pair in joinQuery1)
            {
                Console.WriteLine("{0} is matched to {1}", pair.upper, pair.lower);
            }

            Console.WriteLine("Filtered non-equijoin:");
            // Rest the mouse pointer over joinQuery2 to verify its type.
            foreach (var pair in joinQuery2)
            {
                Console.WriteLine("{0} is matched to {1}", pair.lower, pair.upper);
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    /* Output:
            Cross join:
            A is matched to x
            A is matched to y
            A is matched to z
            B is matched to x
            B is matched to y
            B is matched to z
            C is matched to x
            C is matched to y
            C is matched to z
            Filtered non-equijoin:
            y is matched to A
            y is matched to B
            y is matched to C
            z is matched to A
            z is matched to B
            z is matched to C
            */