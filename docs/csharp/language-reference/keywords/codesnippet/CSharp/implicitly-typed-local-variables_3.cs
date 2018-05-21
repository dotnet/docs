           // Same as previous example except we use the entire last name as a key.
           // Query variable is an IEnumerable<IGrouping<string, Student>>
            var studentQuery3 =
                from student in students
                group student by student.Last;