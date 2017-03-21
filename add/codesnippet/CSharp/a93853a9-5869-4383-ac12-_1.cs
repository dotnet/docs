            int[] grades = { 59, 82, 70, 56, 92, 98, 85 };

            // Get all grades less than 80 by first
            // sorting the grades in descending order and then
            // taking all the grades after the first grade
            // that is less than 80.
            IEnumerable<int> lowerGrades =
                grades.AsQueryable()
                .OrderByDescending(grade => grade)
                .SkipWhile(grade => grade >= 80);

            Console.WriteLine("All grades below 80:");
            foreach (int grade in lowerGrades)
                Console.WriteLine(grade);

            /*
                This code produces the following output:

                All grades below 80:
                70
                59
                56
            */
