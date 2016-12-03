            var query = from student in students
                        group student by student.LastName[0];