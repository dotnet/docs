                ' Create a list of Integers.
                Dim numbers As New List(Of Integer)(New Integer() {1, 2})

                ' Determine if the list contains any items.
                Dim hasElements As Boolean = numbers.Any()

                ' Display the output.
                Dim text As String = IIf(hasElements, "not ", "")
                MsgBox("The list is " & text & "empty.")

                ' This code produces the following output:
                '
                ' The list is not empty.
