    Private Sub SetAllowNull()
        Dim myGridColumn As DataGridBoolColumn = CType(dataGrid1.TableStyles(0).GridColumnStyles(0), DataGridBoolColumn)
        myGridColumn.AllowNull = False
    End Sub 'SetAllowNull