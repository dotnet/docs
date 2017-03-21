Private Sub FindValueInDataView(table As DataTable)
    Dim view As DataView = New DataView(table)
    view.Sort = "Customers"

    ' Find the customer named "John Smith".
    Dim vals(1) As Object
    vals(0)= "John"
    vals(1) = "Smith"
    Dim i As Integer = view.Find(vals)
    Console.WriteLine(view(i))
End Sub