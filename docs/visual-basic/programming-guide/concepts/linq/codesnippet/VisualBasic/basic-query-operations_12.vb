        Dim studentsByYear2 = From student In students
                              Select student
                              Order By student.Year, student.Last
                              Group By year = student.Year
                              Into Classes = Group