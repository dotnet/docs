            int[] numbers = { 9, 34, 65, 92, 87, 435, 3, 54, 
                                83, 23, 87, 67, 12, 19 };

            int last = numbers.AsQueryable().Last();

            Console.WriteLine(last);

            /*
                This code produces the following output:

                19
            */
