   ' Create an instance of the 'BackButtonClick' EventHandler.
   Private Sub CallBackButtonClick()
      AddHandler myDataGrid.BackButtonClick, AddressOf Grid_BackClick
   End Sub 'CallBackButtonClick
   
   
   ' Raise the event when 'BackButton' on child table is clicked.
    Private Sub Grid_BackClick(ByVal sender As Object, ByVal e As EventArgs)
        ' String variable used to show message.
        Dim myString As String = "BackButtonClick event raised, showing parent table"
        ' Show information about Back button.
        MessageBox.Show(myString, "Back button information")
    End Sub 'Grid_BackClick
   