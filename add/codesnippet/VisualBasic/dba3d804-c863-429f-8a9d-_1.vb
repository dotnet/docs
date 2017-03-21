            ' Create an array of strings.
            Dim fruits() As String = {"apple", "banana", "mango", "orange", "passionfruit", "grape"}

            ' This is the string to search the array for.
            Dim fruit As String = "mango"

            ' Determine if the array contains the specified string.
            Dim hasMango As Boolean = fruits.Contains(fruit)

            Dim text As String = IIf(hasMango, "does", "does not")

            ' Display the output.
            MsgBox("The array " & text & " contain " & fruit)

            ' This code produces the following output:
            '
            ' The array does contain mango
