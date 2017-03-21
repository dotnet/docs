            Dim months As New List(Of Integer)(New Integer() {})

            ' Setting the default value to 1 after the query.
            Dim firstMonth1 As Integer = months.FirstOrDefault()
            If firstMonth1 = 0 Then
                firstMonth1 = 1
            End If
            MsgBox(String.Format("The value of the firstMonth1 variable is {0}", firstMonth1))

            ' Setting the default value to 1 by using DefaultIfEmpty() in the query.
            Dim firstMonth2 As Integer = months.DefaultIfEmpty(1).First()
            MsgBox(String.Format("The value of the firstMonth2 variable is {0}", firstMonth2))

            ' This code produces the following output:
            '
            ' The value of the firstMonth1 variable is 1
            ' The value of the firstMonth2 variable is 1
