        Dim numbers() As Integer = {9, 34, 65, 92, 87, 435, 3, 54, _
                            83, 23, 87, 67, 12, 19}

        ' Get the last number in the array that is greater than 80.
        Dim last As Integer = numbers.AsQueryable().Last(Function(num) num > 80)

        MsgBox(last)

        ' This code produces the following output:
        ' 87
