            // studentQuery2 is an IEnumerable<IGrouping<char, Student>>
            var studentQuery2 =
                from student in students
                group student by student.Last[0];