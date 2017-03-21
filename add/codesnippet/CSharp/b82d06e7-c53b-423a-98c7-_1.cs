            string[] fruits = { "apple", "mango", "orange", "passionfruit", "grape" };

            // Determine whether any string in the array is longer than "banana".
            string longestName =
                fruits.AsQueryable().Aggregate(
                "banana",
                (longest, next) => next.Length > longest.Length ? next : longest,
                // Return the final result as an uppercase string.
                fruit => fruit.ToUpper()
                );

            Console.WriteLine(
                "The fruit with the longest name is {0}.",
                longestName);

            // This code produces the following output:
            //
            // The fruit with the longest name is PASSIONFRUIT. 
