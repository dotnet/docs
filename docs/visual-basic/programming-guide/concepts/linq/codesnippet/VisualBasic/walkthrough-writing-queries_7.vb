        ' Find all students who are seniors.
        Dim q1 = From currentStudent In students
                 Where currentStudent.Year = "Senior"
                 Select currentStudent

        ' Write a For Each loop to execute the query.
        For Each q In q1
            Console.WriteLine(q.First & " " & q.Last)
        Next

        ' Find all students with a first name beginning with "C".
        Dim q2 = From currentStudent In students
                 Where currentStudent.First.StartsWith("C")
                 Select currentStudent

        ' Find all top ranked seniors (rank < 40).
        Dim q3 = From currentStudent In students
                 Where currentStudent.Rank < 40 And currentStudent.Year = "Senior"
                 Select currentStudent

        ' Find all seniors with a lower rank than a student who 
        ' is not a senior.
        Dim q4 = From student1 In students, student2 In students
                 Where student1.Year = "Senior" And student2.Year <> "Senior" And
                       student1.Rank > student2.Rank
                 Select student1
                 Distinct

        ' Retrieve the full names of all students, sorted by last name.
        Dim q5 = From currentStudent In students
                 Order By currentStudent.Last
                 Select Name = currentStudent.First & " " & currentStudent.Last

        ' Determine how many students are ranked in the top 20.
        Dim q6 = Aggregate currentStudent In students
                 Where currentStudent.Rank <= 20
                 Into Count()

        ' Count the number of different last names in the group of students.
        Dim q7 = Aggregate currentStudent In students
                 Select currentStudent.Last
                 Distinct
                 Into Count()

        ' Create a list box to show the last names of students.
        Dim lb As New System.Windows.Forms.ListBox
        Dim q8 = From currentStudent In students
                 Order By currentStudent.Last
                 Select currentStudent.Last Distinct

        For Each nextName As String In q8
            lb.Items.Add(nextName)
        Next

        ' Find every process that has a lowercase "h", "l", or "d" in its name.
        Dim letters() As String = {"h", "l", "d"}
        Dim q9 = From proc In System.Diagnostics.Process.GetProcesses,
                 letter In letters
                 Where proc.ProcessName.Contains(letter)
                 Select proc

        For Each proc In q9
            Console.WriteLine(proc.ProcessName & ", " & proc.WorkingSet64)
        Next