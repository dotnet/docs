            // Create an empty array.
            string[] fruits = { };

            // Get the last item in the array, or else the default
            // value for type string (null).
            string last = fruits.AsQueryable().LastOrDefault();

            Console.WriteLine(
                String.IsNullOrEmpty(last) ? "[STRING IS NULL OR EMPTY]" : last);

            /*
                This code produces the following output:

                [STRING IS NULL OR EMPTY]
            */
