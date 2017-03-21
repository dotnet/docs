   Private Sub CallParentRowsLabelStyleChanged()
      AddHandler myDataGrid.ParentRowsLabelStyleChanged, AddressOf _
                                           DataGridParentRowsLabelStyleChanged_Clicked
   End Sub 'CallParentRowsLabelStyleChanged
   
   
   ' Set the 'ParentRowsLabelStyle' property on click of a button.
    Private Sub ToggleStyle_Clicked(ByVal sender As Object, ByVal e As EventArgs)
        If myDataGrid.ParentRowsLabelStyle.ToString() = "Both" Then
            myDataGrid.ParentRowsLabelStyle = DataGridParentRowsLabelStyle.TableName
        Else
            myDataGrid.ParentRowsLabelStyle = DataGridParentRowsLabelStyle.Both
        End If
    End Sub 'ToggleStyle_Clicked

    ' raise the event when 'ParentRowsLabelStyle' property is changed.
    Private Sub DataGridParentRowsLabelStyleChanged_Clicked(ByVal sender As Object, ByVal e As EventArgs)
        Dim myMessage As String = "ParentRowsLabelStyleChanged event raised, LabelStyle is : "
        ' Get the state of 'ParentRowsLabelStyle' property.
        Dim myLabelStyle As String = myDataGrid.ParentRowsLabelStyle.ToString()
        myMessage += myLabelStyle

        MessageBox.Show(myMessage, "ParentRowsLabelStyle information")
    End Sub 'DataGridParentRowsLabelStyleChanged_Clicked
