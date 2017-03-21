        Dim daysOfMonth As New List(Of Integer)(New Integer() {})

        ' Setting the default value to 1 after the query.
        Dim lastDay1 As Integer = daysOfMonth.AsQueryable().LastOrDefault()
        If lastDay1 = 0 Then
            lastDay1 = 1
        End If
        MsgBox(String.Format("The value of the lastDay1 variable is {0}", lastDay1))

        ' Setting the default value to 1 by using DefaultIfEmpty() in the query.
        Dim lastDay2 As Integer = daysOfMonth.AsQueryable().DefaultIfEmpty(1).Last()
        MsgBox(String.Format("The value of the lastDay2 variable is {0}", lastDay2))

        ' This code produces the following output:
        '
        ' The value of the lastDay1 variable is 1
        ' The value of the lastDay2 variable is 1
