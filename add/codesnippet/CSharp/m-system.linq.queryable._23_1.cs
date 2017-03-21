            List<int> grades = new List<int> { 78, 92, 100, 37, 81 };

            double average = grades.AsQueryable().Average();

            Console.WriteLine("The average grade is {0}.", average);

            // This code produces the following output:
            //
            // The average grade is 77.6. 
