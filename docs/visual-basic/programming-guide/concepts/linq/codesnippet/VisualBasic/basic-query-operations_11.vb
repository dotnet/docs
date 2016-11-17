        Dim studentsByYear = From student In students
                             Select student
                             Group By year = student.Year
                             Into Classes = Group

        For Each yearGroup In studentsByYear
            Console.WriteLine(vbCrLf & "Year: " & yearGroup.year)
            For Each student In yearGroup.Classes
                Console.WriteLine("   " & student.Last & ", " & student.First)
            Next
        Next