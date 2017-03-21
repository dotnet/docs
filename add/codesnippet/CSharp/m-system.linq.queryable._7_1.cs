            int[] grades = { 59, 82, 70, 56, 92, 98, 85 };

            // Sort the grades in descending order and
            // get all except the first three.
            IEnumerable<int> lowerGrades =
                grades.AsQueryable().OrderByDescending(g => g).Skip(3);

            Console.WriteLine("All grades except the top three are:");
            foreach (int grade in lowerGrades)
                Console.WriteLine(grade);

            /*
                This code produces the following output:

                All grades except the top three are:
                82
                70
                59
                56
            */
