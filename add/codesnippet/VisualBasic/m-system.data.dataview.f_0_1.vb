Private Sub FindValueInDataView(table As DataTable)
    Dim view As DataView = New DataView(table)
    view.Sort = "CustomerID"

    ' Find the customer named "DUMON" in the primary key column
    Dim i As Integer = view.Find("DUMON")
    Console.WriteLine(view(i))
End Sub