            var queryGroupMax =
                from student in students
                group student by student.GradeLevel into studentGroup
                select new
                {
                    Level = studentGroup.Key,
                    HighestScore =
                        (from student2 in studentGroup
                         select student2.Scores.Average())
                         .Max()
                };