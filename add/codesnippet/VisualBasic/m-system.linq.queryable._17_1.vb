        Dim numbers As New List(Of Integer)(New Integer() {1, 2})

        ' Determine if the list contains any elements.
        Dim hasElements As Boolean = numbers.AsQueryable().Any()

        MsgBox(String.Format("The list {0} empty.", _
            IIf(hasElements, "is not", "is")))

        ' This code produces the following output:
        '
        ' The list is not empty. 
