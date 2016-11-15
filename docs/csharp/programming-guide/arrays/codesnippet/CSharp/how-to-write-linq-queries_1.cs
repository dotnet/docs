            // Query #1.
            List<int> numbers = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // The query variable can also be implicitly typed by using var
            IEnumerable<int> filteringQuery =
                from num in numbers
                where num < 3 || num > 7
                select num;

            // Query #2.
            IEnumerable<int> orderingQuery =
                from num in numbers
                where num < 3 || num > 7
                orderby num ascending
                select num;

            // Query #3.
            string[] groupingQuery = { "carrots", "cabbage", "broccoli", "beans", "barley" };
            IEnumerable<IGrouping<char, string>> queryFoodGroups =
                from item in groupingQuery
                group item by item[0];