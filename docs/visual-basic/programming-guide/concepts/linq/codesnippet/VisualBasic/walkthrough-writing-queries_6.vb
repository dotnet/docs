        Dim studentQuery4 =
                From currentStudent In students
                Where currentStudent.Year = "Senior" And currentStudent.Rank <= 10
                Order By currentStudent.Rank Ascending
                Select currentStudent.First, currentStudent.Last, currentStudent.Rank

        ' If you see too many results, comment out the previous
        ' For Each loops.
        For Each studentRecord In studentQuery4
            Console.WriteLine(studentRecord.Last & ", " & studentRecord.First &
                              ":  " & studentRecord.Rank)
        Next