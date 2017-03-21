            List<int> months = new List<int> { };

            // Setting the default value to 1 after the query.
            int firstMonth1 = months.AsQueryable().FirstOrDefault();
            if (firstMonth1 == 0)
            {
                firstMonth1 = 1;
            }
            Console.WriteLine("The value of the firstMonth1 variable is {0}", firstMonth1);

            // Setting the default value to 1 by using DefaultIfEmpty() in the query.
            int firstMonth2 = months.AsQueryable().DefaultIfEmpty(1).First();
            Console.WriteLine("The value of the firstMonth2 variable is {0}", firstMonth2);

            /*
             This code produces the following output:
            
             The value of the firstMonth1 variable is 1
             The value of the firstMonth2 variable is 1
            */
