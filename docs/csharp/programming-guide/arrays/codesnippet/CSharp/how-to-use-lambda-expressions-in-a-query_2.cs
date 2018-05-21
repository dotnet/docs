        private static void TotalsByGradeLevel()
        {
            // This query retrieves the total scores for First Year students, Second Years, and so on.
            // The outer Sum method uses a lambda in order to specify which numbers to add together.
            var categories =
            from student in students
            group student by student.Year into studentGroup
            select new { GradeLevel = studentGroup.Key, TotalScore = studentGroup.Sum(s => s.ExamScores.Sum()) };

            // Execute the query.   
            foreach (var cat in categories)
            {
                Console.WriteLine("Key = {0} Sum = {1}", cat.GradeLevel, cat.TotalScore);
            }
        }
        /*
             Outputs: 
             Key = SecondYear Sum = 1014
             Key = ThirdYear Sum = 964
             Key = FirstYear Sum = 1058
             Key = FourthYear Sum = 974
        */