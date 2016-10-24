            var studentQuery8 =
                from student in students
                let x = student.Scores[0] + student.Scores[1] +
                    student.Scores[2] + student.Scores[3]
                where x > averageScore
                select new { id = student.ID, score = x };

            foreach (var item in studentQuery8)
            {
                Console.WriteLine("Student ID: {0}, Score: {1}", item.id, item.score);
            }

            // Output:
            // Student ID: 113, Score: 338
            // Student ID: 114, Score: 353
            // Student ID: 116, Score: 369
            // Student ID: 117, Score: 352
            // Student ID: 118, Score: 343
            // Student ID: 120, Score: 341
            // Student ID: 122, Score: 368