    Private Sub SetHeaderText()
        Dim dgCol As DataGridColumnStyle
        Dim dataCol1 As DataColumn
        Dim dataTable1 As DataTable
        dgCol = dataGrid1.TableStyles(0).GridColumnStyles(0)
        dataTable1 = dataSet1.Tables(dataGrid1.DataMember)
        dataCol1 = dataTable1.Columns(dgCol.MappingName)
        dgCol.HeaderText = dataCol1.Caption
    End Sub 'SetHeaderText