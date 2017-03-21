Private Sub AddColumn()
    ' Get the DataColumnCollection from a table in a DataSet.
    Dim columns As DataColumnCollection = _
        DataSet1.Tables("Prices").Columns
    Dim column As DataColumn = columns.Add("Total")

    With column
       .DataType = System.Type.GetType("System.Decimal")
       .ReadOnly = True
       .Expression = "UnitPrice * Quantity"
       .Unique = False
    End With
End Sub