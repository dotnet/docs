            int[] numbers = { 9, 34, 65, 92, 87, 435, 3, 54, 
                              83, 23, 87, 435, 67, 12, 19 };

            // Get the first number in the array that is greater than 80.
            int first = numbers.AsQueryable().First(number => number > 80);

            Console.WriteLine(first);

            /*
                This code produces the following output:

                92
            */
