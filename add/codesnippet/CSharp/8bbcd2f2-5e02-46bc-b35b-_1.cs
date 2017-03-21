            string[] names = { "Hartono, Tommy", "Adams, Terry",
                               "Andersen, Henriette Thaulow",
                               "Hedlund, Magnus", "Ito, Shu" };

            int index = 20;

            string name = names.AsQueryable().ElementAtOrDefault(index);

            Console.WriteLine(
                "The name chosen at index {0} is '{1}'.",
                index,
                String.IsNullOrEmpty(name) ? "[NONE AT THIS INDEX]" : name);

            /*
                This code produces the following output:

                The name chosen at index 20 is '[NONE AT THIS INDEX]'.
            */
