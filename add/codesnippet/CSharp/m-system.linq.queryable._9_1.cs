            // Create an empty array.
            int[] numbers = { };
            // Get the first item in the array, or else the 
            // default value for type int (0).
            int first = numbers.AsQueryable().FirstOrDefault();

            Console.WriteLine(first);

            /*
                This code produces the following output:

                0
            */
