            ' Create an empty array.
            Dim fruits2() As String = {}

            result = String.Empty

            ' Get the single item in the array or else a default value.
            result = fruits2.SingleOrDefault()

            ' Display the result.
            Dim output As String =
            IIf(String.IsNullOrEmpty(result), "No single item found", result)
            MsgBox("Second array: " & output)

            ' This code produces the following output:
            '
            ' First array: orange
            ' Second array: No single item found
