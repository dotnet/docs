            string[] names = { "Hartono, Tommy", "Adams, Terry", 
                                 "Andersen, Henriette Thaulow", 
                                 "Hedlund, Magnus", "Ito, Shu" };

            // Get the first string in the array that is longer
            // than 20 characters, or the default value for type
            // string (null) if none exists.
            string firstLongName =
                names.AsQueryable().FirstOrDefault(name => name.Length > 20);

            Console.WriteLine("The first long name is '{0}'.", firstLongName);

            // Get the first string in the array that is longer
            // than 30 characters, or the default value for type
            // string (null) if none exists.
            string firstVeryLongName =
                names.AsQueryable().FirstOrDefault(name => name.Length > 30);

            Console.WriteLine(
                "There is {0} name that is longer than 30 characters.",
                string.IsNullOrEmpty(firstVeryLongName) ? "NOT a" : "a");

            /*
                This code produces the following output:

                The first long name is 'Andersen, Henriette Thaulow'.
                There is NOT a name that is longer than 30 characters.
            */
