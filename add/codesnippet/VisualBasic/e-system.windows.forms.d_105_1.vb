   ' Create an instance of the 'Scroll' EventHandler.
   Private Sub CallScroll()
      AddHandler myDataGrid.Scroll, AddressOf Grid_Scroll
   End Sub 'CallScroll
   
   
   ' Raise the event when DataGrid is scrolled.
    Private Sub Grid_Scroll(ByVal sender As Object, ByVal e As EventArgs)
        ' String variable used to show message.
        Dim myString As String = "Scroll event raised, DataGrid is scrolled"
        ' Show the message when scrolling is done.
        MessageBox.Show(myString, "Scroll information")
    End Sub 'Grid_Scroll