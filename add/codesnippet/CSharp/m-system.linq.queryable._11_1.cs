            List<float> numbers = new List<float> { 43.68F, 1.25F, 583.7F, 6.5F };

            float sum = numbers.AsQueryable().Sum();

            Console.WriteLine("The sum of the numbers is {0}.", sum);

            /*
                This code produces the following output:

                The sum of the numbers is 635.13.
            */
