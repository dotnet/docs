    Private Sub ResetButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim myTableStyle As DataGridTableStyle = myDataGrid.TableStyles(0)
        Dim myColumns As GridColumnStylesCollection = myTableStyle.GridColumnStyles

        ' Reset the property descriptor of column styles collection.
        myColumns.ResetPropertyDescriptors()
    End Sub 'ResetButton_Click
   