        Sub AggregateEx3()
            Dim fruits() As String =
            {"apple", "mango", "orange", "passionfruit", "grape"}

            ' Determine whether any string in the array is longer than "banana".
            Dim longestName As String =
            fruits.Aggregate("banana",
                             Function(ByVal longest, ByVal fruit) _
                                 IIf(fruit.Length > longest.Length, fruit, longest),
                             Function(ByVal fruit) fruit.ToUpper())

            ' Display the output.
            MsgBox("The fruit with the longest name is " & longestName)
        End Sub

        ' This code produces the following output:
        '
        ' The fruit with the longest name is PASSIONFRUIT
