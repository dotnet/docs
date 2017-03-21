            float?[] points = { null, 0, 92.83F, null, 100.0F, 37.46F, 81.1F };

            float? sum = points.AsQueryable().Sum();

            Console.WriteLine("Total points earned: {0}", sum);

            /*
                This code produces the following output:

                Total points earned: 311.39
            */
