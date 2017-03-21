            ' Create an ArrayList and add items to it.
            Dim fruits As New System.Collections.ArrayList()
            fruits.Add("mango")
            fruits.Add("apple")
            fruits.Add("lemon")

            ' Call Cast(Of String) to cast the ArrayList elements to strings.
            Dim query As IEnumerable(Of String) =
            fruits.Cast(Of String)().OrderBy(Function(fruit) fruit).Select(Function(fruit) fruit)

            '' The following code, without the cast, doesn't compile.
            'Dim query As IEnumerable(Of String) = _
            '    fruits.OrderBy(Function(fruit) fruit).Select(Function(fruit) fruit)

            Dim output As New System.Text.StringBuilder
            For Each fruit As String In query
                output.AppendLine(fruit)
            Next

            ' Display the output.
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' apple
            ' lemon
            ' mango