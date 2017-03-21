    Private Sub EditTable()
        Dim dgt As DataGridTableStyle = myDataGrid.TableStyles(0)
        Dim myCol As DataGridColumnStyle = dgt.GridColumnStyles(0)
        
        dgt.BeginEdit(myCol, 1)
        dgt.EndEdit(myCol, 1, True)
    End Sub 'EditTable