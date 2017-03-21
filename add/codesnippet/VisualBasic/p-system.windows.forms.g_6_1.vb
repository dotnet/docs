Private Sub GetGridColumn()
    Dim myDataGridColumnStyle As DataGridColumnStyle 
    ' Get the DataGridColumnStyle at the specified index.
    myDataGridColumnStyle = _
    DataGrid1.TableStyles(0).GridColumnStyles(0)
    Console.WriteLine(myDataGridColumnStyle.MappingName)
End Sub 