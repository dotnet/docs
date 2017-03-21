Private Sub ContainsThisDataCol()
    ' Use the Contains method to determine whether a specific
    ' DataGridColumnStyle with the same MappingName exists.
    Console.WriteLine(DataGrid1.TableStyles(0). _
    GridColumnStyles.Contains("FirstName"))
End Sub    