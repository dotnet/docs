    Private Sub Clear_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles clearButton.Click
        ' TablesAlreadyAdded set to false so that table styles can be added again.
        TablesAlreadyAdded = False
        myLabel.Text = "All Table Styles Cleared."
        ' Clear all the column styles and also table style for the grid.
        Dim myTableStyle As DataGridTableStyle
        For Each myTableStyle In myDataGrid.TableStyles
            Dim myColumns As GridColumnStylesCollection = myTableStyle.GridColumnStyles
            myColumns.Clear()
        Next myTableStyle
        myDataGrid.TableStyles.Clear()
    End Sub 'Clear_Clicked
