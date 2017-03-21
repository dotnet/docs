        Dim grades As New List(Of Integer)(New Integer() {78, 92, 100, 37, 81})

        Dim average As Double = grades.AsQueryable().Average()

        MsgBox(String.Format("The average grade is {0}.", average))

        ' This code produces the following output:
        '
        ' The average grade is 77.6. 
