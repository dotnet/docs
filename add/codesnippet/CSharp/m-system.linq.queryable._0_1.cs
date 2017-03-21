            int[] numbers = { 9, 34, 65, 92, 87, 435, 3, 54, 
                                83, 23, 87, 435, 67, 12, 19 };

            int first = numbers.AsQueryable().First();

            Console.WriteLine(first);

            /*
                This code produces the following output:

                9
            */
