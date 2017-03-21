            // Create two arrays. The second is empty.
            string[] fruits1 = { "orange" };
            string[] fruits2 = { };

            // Get the only item in the first array, or else
            // the default value for type string (null).
            string fruit1 = fruits1.AsQueryable().SingleOrDefault();
            Console.WriteLine("First Query: " + fruit1);

            // Get the only item in the second array, or else
            // the default value for type string (null). 
            string fruit2 = fruits2.AsQueryable().SingleOrDefault();
            Console.WriteLine("Second Query: " +
                (String.IsNullOrEmpty(fruit2) ? "No such string!" : fruit2));

            /*
                This code produces the following output:

                First Query: orange
                Second Query: No such string!
            */
