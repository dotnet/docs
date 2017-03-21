        Dim fruits() As String = {"apple", "banana", "mango", "orange", "passionfruit", "grape"}

        ' Determine the average string length in the array.
        Dim average As Double = fruits.AsQueryable().Average(Function(s) s.Length)

        MsgBox(String.Format("The average string length is {0}.", average))

        ' This code produces the following output:
        '
        ' The average string length is 6.5. 
