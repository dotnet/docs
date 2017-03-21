        Dim fruits() As String = {"apple", "banana", "mango", "orange", _
                              "passionfruit", "grape"}

        ' Project an anonymous type that contains the
        ' index of the string in the source array, and
        ' a string that contains the same number of characters
        ' as the string's index in the source array.
        Dim query = _
            fruits.AsQueryable() _
            .Select(Function(fruit, index) New With {index, .str = fruit.Substring(0, index)})

        Dim output As New System.Text.StringBuilder
        For Each obj In query
            output.AppendLine(obj.ToString())
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:

        ' { index = 0, str =  }
        ' { index = 1, str = b }
        ' { index = 2, str = ma }
        ' { index = 3, str = ora }
        ' { index = 4, str = pass }
        ' { index = 5, str = grape }
