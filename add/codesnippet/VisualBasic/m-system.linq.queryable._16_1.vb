        Dim fruits() As String = {"apple", "banana", "mango", _
                            "orange", "passionfruit", "grape"}

        Dim numberOfFruits As Integer = fruits.AsQueryable().Count()

        MsgBox(String.Format( _
            "There are {0} items in the array.", _
            numberOfFruits))

        ' This code produces the following output:
        '
        ' There are 6 items in the array. 
