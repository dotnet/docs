            List<long> longs = new List<long> { 4294967296L, 466855135L, 81125L };

            long max = longs.AsQueryable().Max();

            Console.WriteLine("The largest number is {0}.", max);

            /*
                This code produces the following output:

                The largest number is 4294967296.
            */
