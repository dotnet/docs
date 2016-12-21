            // Query #7.

            // Using a query expression with method syntax
            int numCount1 =
                (from num in numbers1
                 where num < 3 || num > 7
                 select num).Count();

            // Better: Create a new variable to store
            // the method call result
            IEnumerable<int> numbersQuery =
                from num in numbers1
                where num < 3 || num > 7
                select num;

            int numCount2 = numbersQuery.Count();