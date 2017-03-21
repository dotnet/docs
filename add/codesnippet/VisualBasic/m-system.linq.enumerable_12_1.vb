            ' Create an ArrayList and add items to it.
            Dim fruits As New System.Collections.ArrayList(4)
            fruits.Add("Mango")
            fruits.Add("Orange")
            fruits.Add("Apple")
            fruits.Add(3.0)
            fruits.Add("Banana")

            ' Apply OfType(Of String)() to the ArrayList
            ' to filter out non-string items.
            Dim query1 As IEnumerable(Of String) = fruits.OfType(Of String)()

            ' Print the results.
            Dim output As New System.Text.StringBuilder("Elements of type 'string' are:" _
                                                    & vbCrLf)
            For Each fruit As String In query1
                output.AppendLine(fruit)
            Next

            ' The following query shows that the standard query operators such as 
            ' Where() can be applied to the ArrayList type after calling OfType().
            Dim query2 As IEnumerable(Of String) =
            fruits.OfType(Of String)().Where(Function(fruit) _
                                                 fruit.ToLower().Contains("n"))

            output.AppendLine(vbCrLf & "The following strings contain 'n':")
            For Each fruit As String In query2
                output.AppendLine(fruit)
            Next

            ' Display the output.
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' Elements of type 'string' are:
            ' Mango
            ' Orange
            ' Apple
            ' Banana
            '
            ' The following strings contain 'n':
            ' Mango
            ' Orange
            ' Banana
