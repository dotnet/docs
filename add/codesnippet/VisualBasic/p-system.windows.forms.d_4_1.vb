    Private Sub SetNullText()
        Dim myGridColumn As DataGridColumnStyle
        myGridColumn = dataGrid1.TableStyles(0).GridColumnStyles(0)
        myGridColumn.NullText = "Null Text"
    End Sub 'SetNullText