            ' Create an array that contains one item.
            Dim fruits1() As String = {"orange"}

            ' Get the single item in the array or else a default value.
            Dim result As String = fruits1.SingleOrDefault()

            ' Display the result.
            MsgBox("First array: " & result)