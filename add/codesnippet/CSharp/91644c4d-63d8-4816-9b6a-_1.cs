            string[] fruits = { "apple", "banana", "mango", 
                                  "orange", "passionfruit", "grape" };

            // Get the single string in the array whose length is greater
            // than 10, or else the default value for type string (null).
            string fruit1 =
                fruits.AsQueryable().SingleOrDefault(fruit => fruit.Length > 10);
            Console.WriteLine("First Query: " + fruit1);

            // Get the single string in the array whose length is greater
            // than 15, or else the default value for type string (null).
            string fruit2 =
               fruits.AsQueryable().SingleOrDefault(fruit => fruit.Length > 15);
            Console.WriteLine("Second Query: " +
                (String.IsNullOrEmpty(fruit2) ? "No such string!" : fruit2));

            /*
                This code produces the following output:

                First Query: passionfruit
                Second Query: No such string!
            */
