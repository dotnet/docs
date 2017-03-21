            double[] doubles = { 1.5E+104, 9E+103, -2E+103 };

            double min = doubles.AsQueryable().Min();

            Console.WriteLine("The smallest number is {0}.", min);

            /*
                This code produces the following output:

                The smallest number is -2E+103.
            */
