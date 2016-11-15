        Dim studentQuery3 = From currentStudent In students
                            Where currentStudent.Last = "Garcia"
                            Select currentStudent.First

        ' If you see too many results, comment out the previous
        ' For Each loops.
        For Each studentRecord In studentQuery3
            Console.WriteLine(studentRecord)
        Next