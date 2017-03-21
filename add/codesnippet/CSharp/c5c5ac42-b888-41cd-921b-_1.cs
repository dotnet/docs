            double[] numbers = { 49.6, 52.3, 51.0, 49.4, 50.2, 48.3 };

            // Get the last number in the array that rounds to 50.0,
            // or else the default value for type double (0.0).
            double last50 =
                numbers.AsQueryable().LastOrDefault(n => Math.Round(n) == 50.0);

            Console.WriteLine("The last number that rounds to 50 is {0}.", last50);

            // Get the last number in the array that rounds to 40.0,
            // or else the default value for type double (0.0).
            double last40 =
                numbers.AsQueryable().LastOrDefault(n => Math.Round(n) == 40.0);

            Console.WriteLine(
                "The last number that rounds to 40 is {0}.",
                last40 == 0.0 ? "[DOES NOT EXIST]" : last40.ToString());

            /*
                This code produces the following output:

                The last number that rounds to 50 is 50.2.
                The last number that rounds to 40 is [DOES NOT EXIST].
            */
