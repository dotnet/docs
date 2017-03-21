        ' Create two arrays.
        Dim fruits1() As String = {"orange"}
        Dim fruits2() As String = {"orange", "apple"}

        ' Get the only item in the first array.
        Dim result As String = fruits1.AsQueryable().Single()

        ' Display the result.
        MsgBox("First query: " & result)

        Try
            ' Try to get the only item in the second array.
            Dim fruit2 As String = fruits2.AsQueryable().Single()
            MsgBox("Second query: " + fruit2)
        Catch
            MsgBox("Second query: The collection does not contain exactly one element.")
        End Try

        ' This code produces the following output:

        ' First query: orange
        ' Second query: The collection does not contain exactly one element.
