        Dim firstArray(4), secondArray(3) As Integer
        Dim thisString As String = "Test"
        Dim arrayCheck As Boolean
        arrayCheck = IsArray(firstArray)
        arrayCheck = IsArray(secondArray)
        arrayCheck = IsArray(thisString)
        ' The first two calls to IsArray return True; the third returns False.