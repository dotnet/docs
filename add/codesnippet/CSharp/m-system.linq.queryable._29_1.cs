            // Create two arrays.
            string[] fruits1 = { "orange" };
            string[] fruits2 = { "orange", "apple" };
            
            // Get the only item in the first array.
            string fruit1 = fruits1.AsQueryable().Single();

            Console.WriteLine("First query: " + fruit1);

            try
            {
                // Try to get the only item in the second array.
                string fruit2 = fruits2.AsQueryable().Single();
                Console.WriteLine("Second query: " + fruit2);
            }
            catch (System.InvalidOperationException)
            {
                Console.WriteLine(
                    "Second query: The collection does not contain exactly one element."
                    );
            }

            /*
                This code produces the following output:

                First query: orange
                Second query: The collection does not contain exactly one element
            */
