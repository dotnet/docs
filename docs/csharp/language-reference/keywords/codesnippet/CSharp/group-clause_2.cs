            // Group students by the first letter of their last name
            // Query variable is an IEnumerable<IGrouping<char, Student>>
            var studentQuery2 =
                from student in students
                group student by student.Last[0] into g
                orderby g.Key
                select g;