            // studentQuery5 is an IEnumerable<string>
            // This query returns those students whose
            // first test score was higher than their
            // average score.
            var studentQuery5 =
                from student in students
                let totalScore = student.Scores[0] + student.Scores[1] +
                    student.Scores[2] + student.Scores[3]
                where totalScore / 4 < student.Scores[0]
                select student.Last + " " + student.First;

            foreach (string s in studentQuery5)
            {
                Console.WriteLine(s);
            }

            // Output:
            // Omelchenko Svetlana
            // O'Donnell Claire
            // Mortensen Sven
            // Garcia Cesar
            // Fakhouri Fadi
            // Feng Hanying
            // Garcia Hugo
            // Adams Terry
            // Zabokritski Eugene
            // Tucker Michael