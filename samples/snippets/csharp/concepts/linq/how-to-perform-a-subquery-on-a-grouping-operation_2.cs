        public void QueryMaxUsingMethodSyntax()
        {
            var queryGroupMax = students
                .GroupBy(student => student.Year)
                .Select(studentGroup => new
                {
                    Level = studentGroup.Key,
                    HighestScore = studentGroup.Select(student2 => student2.ExamScores.Average()).Max()
                });

            int count = queryGroupMax.Count();
            Console.WriteLine($"Number of groups = {count}");

            foreach (var item in queryGroupMax)
            {
                Console.WriteLine($"  {item.Level} Highest Score={item.HighestScore}");
            }
        }