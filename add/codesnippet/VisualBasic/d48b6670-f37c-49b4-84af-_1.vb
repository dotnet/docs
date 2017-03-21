            ' Create an array of integers.
            Dim numbers() As Integer =
            {9, 34, 65, 92, 87, 435, 3, 54, 83, 23, 87, 435, 67, 12, 19}

            ' Select the first element in the array whose value is greater than 80.
            Dim first As Integer = numbers.First(Function(number) number > 80)

            ' Display the output.
            MsgBox(first)

            ' This code produces the following output:
            '
            ' 92
