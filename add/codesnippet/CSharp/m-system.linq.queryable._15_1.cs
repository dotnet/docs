            string[] names = { "Hartono, Tommy", "Adams, Terry", 
                               "Andersen, Henriette Thaulow", 
                               "Hedlund, Magnus", "Ito, Shu" };

            Random random = new Random(DateTime.Now.Millisecond);

            string name =
                names.AsQueryable().ElementAt(random.Next(0, names.Length));

            Console.WriteLine("The name chosen at random is '{0}'.", name);

            /*
                This code produces the following sample output.
                Yours may be different due to the use of Random.

                The name chosen at random is 'Ito, Shu'.
            */
