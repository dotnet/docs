        Dim numbers() As Integer = {9, 34, 65, 92, 87, 435, 3, 54, _
                            83, 23, 87, 435, 67, 12, 19}

        Dim first As Integer = numbers.AsQueryable().First()

        MsgBox(first)

        ' This code produces the following output:
        '
        ' 9
