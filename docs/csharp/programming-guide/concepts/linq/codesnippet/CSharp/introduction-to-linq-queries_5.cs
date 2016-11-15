            List<int> numQuery2 =
                (from num in numbers
                 where (num % 2) == 0
                 select num).ToList();

            // or like this:
            // numQuery3 is still an int[]

            var numQuery3 =
                (from num in numbers
                 where (num % 2) == 0
                 select num).ToArray();