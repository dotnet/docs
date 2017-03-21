        ' Create an empty array.
        Dim numbers() As Integer = {}
        ' Get the first item in the array, or else the 
        ' default value for type int, which is 0.
        Dim first As Integer = numbers.AsQueryable().FirstOrDefault()

        MsgBox(first)

        ' This code produces the following output:

        ' 0
