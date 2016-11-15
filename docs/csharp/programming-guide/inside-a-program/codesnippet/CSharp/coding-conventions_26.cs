            // Use a compound from to access the inner sequence within each element.
            var scoreQuery = from student in students
                             from score in student.Scores
                             where score > 90
                             select new { Last = student.LastName, score };