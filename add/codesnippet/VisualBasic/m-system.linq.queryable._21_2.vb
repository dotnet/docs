        Dim pageNumbers() As Integer = {}

        ' Setting the default value to 1 after the query.
        Dim pageNumber1 As Integer = pageNumbers.AsQueryable().SingleOrDefault()
        If pageNumber1 = 0 Then
            pageNumber1 = 1
        End If
        MsgBox(String.Format("The value of the pageNumber1 variable is {0}", pageNumber1))

        ' Setting the default value to 1 by using DefaultIfEmpty() in the query.
        Dim pageNumber2 As Integer = pageNumbers.AsQueryable().DefaultIfEmpty(1).Single()
        MsgBox(String.Format("The value of the pageNumber2 variable is {0}", pageNumber2))

        ' This code produces the following output:

        ' The value of the pageNumber1 variable is 1
        ' The value of the pageNumber2 variable is 1
