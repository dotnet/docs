        Dim studentQuery = From currentStudent In students
                           Where currentStudent.Rank <= 10
                           Select currentStudent