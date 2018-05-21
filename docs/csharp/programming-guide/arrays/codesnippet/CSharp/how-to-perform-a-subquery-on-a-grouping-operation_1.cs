        public void QueryMax()
        {
            var queryGroupMax =
                from student in students
                group student by student.Year into studentGroup
                select new
                {
                    Level = studentGroup.Key,
                    HighestScore =
                    (from student2 in studentGroup
                     select student2.ExamScores.Average()).Max()
                };

            int count = queryGroupMax.Count();
            Console.WriteLine("Number of groups = {0}", count);

            foreach (var item in queryGroupMax)
            {
                Console.WriteLine("  {0} Highest Score={1}", item.Level, item.HighestScore);
            }
        }