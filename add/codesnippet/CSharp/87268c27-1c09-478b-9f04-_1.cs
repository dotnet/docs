            string[] fruits = { "apple", "banana", "mango", 
                                  "orange", "passionfruit", "grape" };

            // Get the only string in the array whose length is greater than 10.
            string fruit1 = fruits.AsQueryable().Single(fruit => fruit.Length > 10);

            Console.WriteLine("First Query: " + fruit1);

            try
            {
                // Try to get the only string in the array
                // whose length is greater than 15.
                string fruit2 = fruits.AsQueryable().Single(fruit => fruit.Length > 15);
                Console.WriteLine("Second Query: " + fruit2);
            }
            catch (System.InvalidOperationException)
            {
                Console.Write("Second Query: The collection does not contain ");
                Console.WriteLine("exactly one element whose length is greater than 15.");
            }

            /*
                This code produces the following output:

                First Query: passionfruit
                Second Query: The collection does not contain exactly one 
                element whose length is greater than 15.
             */
