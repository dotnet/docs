   Private Sub CallShowParentDetailsButtonClick()
      AddHandler myDataGrid.ShowParentDetailsButtonClick, AddressOf _
                                              DataGridShowParentDetailsButtonClick_Clicked
   End Sub 'CallShowParentDetailsButtonClick
   
   
   ' raise the event when ParentDetailsButton is clicked.
    Private Sub DataGridShowParentDetailsButtonClick_Clicked(ByVal sender As Object, ByVal e As EventArgs)
        Dim myMessage As String = "ShowParentDetailsButtonClick event raised"

        ' Show the message when event is raised.
        MessageBox.Show(myMessage, "ShowParentDetailsButtonClick information")
    End Sub 'DataGridShowParentDetailsButtonClick_Clicked