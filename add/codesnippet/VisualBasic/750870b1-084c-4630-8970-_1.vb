            ' Create an array of strings.
            Dim fruits() As String =
            {"apple", "banana", "mango", "orange", "passionfruit", "grape"}

            ' Project each item in the array to an anonymous type
            ' that stores the item's index in the array and
            ' a substring of each item whose length is equal
            ' to the index position in the original array.
            Dim query =
            fruits.Select(Function(fruit, index) _
                              New With {index, .Str = fruit.Substring(0, index)})

            Dim output As New System.Text.StringBuilder
            For Each obj In query
                output.AppendLine(obj.ToString())
            Next

            ' Display the output.
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' { index = 0, Str =  }
            ' { index = 1, Str = b }
            ' { index = 2, Str = ma }
            ' { index = 3, Str = ora }
            ' { index = 4, Str = pass }
            ' { index = 5, Str = grape }
