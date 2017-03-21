            string[] fruits = { "apple", "banana", "mango", "orange", "passionfruit", "grape" };

            // Determine the average string length in the array.
            double average = fruits.AsQueryable().Average(s => s.Length);

            Console.WriteLine("The average string length is {0}.", average);

            // This code produces the following output:
            //
            // The average string length is 6.5. 
