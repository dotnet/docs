        Dim numbers() As Integer = {9, 34, 65, 92, 87, 435, 3, 54, _
                          83, 23, 87, 435, 67, 12, 19}

        ' Get the first number in the array that is greater than 80.
        Dim first As Integer = numbers.AsQueryable().First(Function(number) number > 80)

        MsgBox(first)

        ' This code produces the following output:
        '
        ' 92
