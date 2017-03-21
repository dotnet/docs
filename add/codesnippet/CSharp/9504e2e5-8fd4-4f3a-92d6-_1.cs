            long?[] longs = { null, 10007L, 37L, 399846234235L };

            double? average = longs.AsQueryable().Average();

            Console.WriteLine("The average is {0}.", average);

            // This code produces the following output:
            //
            // The average is 133282081426.333. 
