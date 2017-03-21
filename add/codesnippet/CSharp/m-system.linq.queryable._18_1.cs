
            // Create a list of objects.
            List<object> words =
                new List<object> { "green", "blue", "violet" };

            // Cast the objects in the list to type 'string'
            // and project the first letter of each string.
            IEnumerable<string> query =
                words.AsQueryable()
                .Cast<string>()
                .Select(str => str.Substring(0, 1));

            foreach (string s in query)
                Console.WriteLine(s);

            /*  This code produces the following output:
            
                g
                b
                v
            */
