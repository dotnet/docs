        Dim numbers() As Integer = {9, 34, 65, 92, 87, 435, 3, 54, _
                            83, 23, 87, 67, 12, 19}

        Dim last As Integer = numbers.AsQueryable().Last()

        MsgBox(last)

        ' This code produces the following output:
        ' 19
