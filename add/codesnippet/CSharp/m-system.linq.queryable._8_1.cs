            int[] grades = { 59, 82, 70, 56, 92, 98, 85 };

            // Sort the grades in descending order and take the first three.
            IEnumerable<int> topThreeGrades =
                grades.AsQueryable().OrderByDescending(grade => grade).Take(3);

            Console.WriteLine("The top three grades are:");
            foreach (int grade in topThreeGrades)
                Console.WriteLine(grade);

            /*
                This code produces the following output:

                The top three grades are:
                98
                92
                85
            */
