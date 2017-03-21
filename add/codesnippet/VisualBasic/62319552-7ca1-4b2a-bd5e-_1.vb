            ' Create an array of integers.
            Dim numbers() As Integer =
            {9, 34, 65, 92, 87, 435, 3, 54, 83, 23, 87, 67, 12, 19}

            ' Get the last element in the array whose value is
            ' greater than 80.
            Dim last As Integer = numbers.Last(Function(num) num > 80)

            ' Display the result.
            MsgBox(last)

            ' This code produces the following output:
            '
            ' 87
