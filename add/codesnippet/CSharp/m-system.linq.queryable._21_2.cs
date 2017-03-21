            int[] pageNumbers = { };

            // Setting the default value to 1 after the query.
            int pageNumber1 = pageNumbers.AsQueryable().SingleOrDefault();
            if (pageNumber1 == 0)
            {
                pageNumber1 = 1;
            }
            Console.WriteLine("The value of the pageNumber1 variable is {0}", pageNumber1);

            // Setting the default value to 1 by using DefaultIfEmpty() in the query.
            int pageNumber2 = pageNumbers.AsQueryable().DefaultIfEmpty(1).Single();
            Console.WriteLine("The value of the pageNumber2 variable is {0}", pageNumber2);

            /*
             This code produces the following output:
            
             The value of the pageNumber1 variable is 1
             The value of the pageNumber2 variable is 1
            */
