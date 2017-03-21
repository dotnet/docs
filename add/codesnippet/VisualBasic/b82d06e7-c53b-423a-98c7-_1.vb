        Dim fruits() As String = {"apple", "mango", "orange", "passionfruit", "grape"}

        ' Determine whether any string in the array is longer than "banana".
        Dim longestName As String = _
            fruits.AsQueryable().Aggregate( _
            "banana", _
            Function(ByVal longest, ByVal fruit) IIf(fruit.Length > longest.Length, fruit, longest), _
            Function(ByVal fruit) fruit.ToUpper() _
        )

        MsgBox(String.Format( _
            "The fruit with the longest name is {0}.", longestName) _
        )

        ' This code produces the following output:
        '
        ' The fruit with the longest name is PASSIONFRUIT. 
