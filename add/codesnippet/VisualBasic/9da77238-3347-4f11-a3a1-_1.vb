            ' Create an empty array.
            Dim numbers() As Integer = {}

            ' Select the first element in the array, or a default value
            ' if there are not elements in the array.
            Dim first As Integer = numbers.FirstOrDefault()

            ' Display the output.
            MsgBox(first)

            ' This code produces the following output:
            '
            ' 0
