            string[] fruits = { "apple", "banana", "mango", 
                                  "orange", "passionfruit", "grape" };

            long count = fruits.AsQueryable().LongCount();

            Console.WriteLine("There are {0} fruits in the collection.", count);

            /*
                This code produces the following output:

                There are 6 fruits in the collection.
            */
