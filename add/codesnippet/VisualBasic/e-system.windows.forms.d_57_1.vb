   ' Create an instance of the 'Navigate' NavigateEventHandler.
   Private Sub CallNavigate()
      AddHandler myDataGrid.Navigate, AddressOf Grid_Navigate
   End Sub 'CallNavigate
   
   
   ' Raise the event when navigating to another table.
    Private Sub Grid_Navigate(ByVal sender As Object, ByVal e As NavigateEventArgs)
        ' String variable used to show message.
        Dim myString As String = "Navigate event raised, moved to another table"
        ' Show the message when navigating to another table.
        MessageBox.Show(myString, "Table navigation information")
    End Sub 'Grid_Navigate