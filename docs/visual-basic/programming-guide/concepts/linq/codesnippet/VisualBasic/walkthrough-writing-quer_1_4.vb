        Dim studentQuery2 =
                From currentStudent In students
                Let name = currentStudent.Last & ", " & currentStudent.First
                Where currentStudent.Year = "Senior" And currentStudent.Rank <= 10
                Order By name Ascending
                Select currentStudent

        ' If you see too many results, comment out the previous
        ' For Each loop.
        For Each studentRecord In studentQuery2
            Console.WriteLine(studentRecord.Last & ", " & studentRecord.First)
        Next