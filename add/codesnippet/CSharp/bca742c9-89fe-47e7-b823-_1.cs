            int[] numbers = { 9, 34, 65, 92, 87, 435, 3, 54, 
                                83, 23, 87, 67, 12, 19 };

            // Get the last number in the array that is greater than 80.
            int last = numbers.AsQueryable().Last(num => num > 80);

            Console.WriteLine(last);

            /*
                This code produces the following output:

                87
            */
