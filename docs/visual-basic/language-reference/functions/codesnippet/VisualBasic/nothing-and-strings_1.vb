        Dim MyString As String = "This is my string"
        Dim stringLength As Integer
        ' Explicitly set the string to Nothing.
        MyString = Nothing
        ' stringLength = 0
        stringLength = Len(MyString)
        ' This line, however, causes an exception to be thrown.
        stringLength = MyString.Length