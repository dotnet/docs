        Dim fruits() As String = {"apple", "banana", "mango", _
                                "orange", "passionfruit", "grape"}

        ' The string to search for in the array.
        Dim mango As String = "mango"

        Dim hasMango As Boolean = fruits.AsQueryable().Contains(mango)

        MsgBox(String.Format("The array {0} contain '{1}'.", _
                IIf(hasMango, "does", "does not"), mango))

        ' This code produces the following output:
        '
        ' The array does contain 'mango'. 
