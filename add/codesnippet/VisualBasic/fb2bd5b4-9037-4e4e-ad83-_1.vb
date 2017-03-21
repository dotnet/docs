            ' Create an empty array.
            Dim fruits() As String = {}

            ' Get the last item in the array, or a
            ' default value if there are no items.
            Dim last As String = fruits.LastOrDefault()

            ' Display the result.
            MsgBox(IIf(String.IsNullOrEmpty(last),
                   "<string is Nothing or empty>",
                   last))

            ' This code produces the following output:
            '
            ' <string is Nothing or empty>
