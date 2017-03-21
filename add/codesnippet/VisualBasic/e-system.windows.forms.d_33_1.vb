    Private Sub CallParentRowsVisibleChanged()
        AddHandler myDataGrid.ParentRowsVisibleChanged, AddressOf _
                                                  DataGridParentRowsVisibleChanged_Clicked
    End Sub 'CallParentRowsVisibleChanged


    ' Set the 'ParentRowsVisible' property on click of a button.
    Private Sub ToggleVisible_Clicked(ByVal sender As Object, ByVal e As EventArgs)
        If myDataGrid.ParentRowsVisible = True Then
            myDataGrid.ParentRowsVisible = False
        Else
            myDataGrid.ParentRowsVisible = True
        End If
    End Sub 'ToggleVisible_Clicked

    ' raise the event when 'ParentRowsVisible' property is changed.
    Private Sub DataGridParentRowsVisibleChanged_Clicked(ByVal sender As Object, ByVal e As EventArgs)
        Dim myMessage As String = "ParentRowsVisibleChanged event raised, Parent row is : "
        Dim visible As Boolean = myDataGrid.ParentRowsVisible
        myMessage += IIF(visible, " ", "Not") + "Visible"
        MessageBox.Show(myMessage, "ParentRowsVisible information")
    End Sub 'DataGridParentRowsVisibleChanged_Clicked