        Dim output As New System.Text.StringBuilder

        ' A custom class.
        Class Clump(Of T)
            Inherits List(Of T)

            ' Constructor.
            Public Sub New(ByVal collection As IEnumerable(Of T))
                MyBase.New(collection)
            End Sub

            ' Custom implementation of Where().
            Function Where(ByVal predicate As Func(Of T, Boolean)) As IEnumerable(Of T)
                output.AppendLine("In Clump's implementation of Where().")
                Return Enumerable.Where(Me, predicate)
            End Function
        End Class

        Sub AsEnumerableEx1()
            ' Create a new Clump(Of T) object.
            Dim fruitClump As New Clump(Of String)(New String() _
                                               {"apple", "passionfruit", "banana",
                                                "mango", "orange", "blueberry",
                                                "grape", "strawberry"})

            ' First call to Where():
            ' Call Clump's Where() method with a predicate.
            Dim query1 As IEnumerable(Of String) =
            fruitClump.Where(Function(fruit) fruit.Contains("o"))
            output.AppendLine("query1 has been created." & vbCrLf)

            ' Second call to Where():
            ' First call AsEnumerable() to hide Clump's Where() method and thereby
            ' force System.Linq.Enumerable's Where() method to be called.
            Dim query2 As IEnumerable(Of String) =
            fruitClump.AsEnumerable().Where(Function(fruit) fruit.Contains("o"))
            output.AppendLine("query2 has been created.")

            ' Display the output.
            MsgBox(output.ToString())
        End Sub

        ' This code produces the following output:
        '
        ' In Clump's implementation of Where().
        ' query1 has been created.
        '
        ' query2 has been created.
