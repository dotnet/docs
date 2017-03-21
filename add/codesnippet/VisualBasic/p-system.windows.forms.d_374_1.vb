   ' Instantiate the EventHandler.
   Public Sub AttachRowHeaderVisibleChanged()
      AddHandler myDataGridTableStyle.RowHeadersVisibleChanged, AddressOf MyDelegateRowHeadersVisibleChanged
   End Sub 'AttachRowHeaderVisibleChanged
   
   
   ' raise the event when RowHeadersVisible property is changed.
    Private Sub MyDelegateRowHeadersVisibleChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim myString As String = "'RowHeadersVisibleChanged' event raised, Row Headers are"
        If myDataGridTableStyle.RowHeadersVisible Then
            myString += " visible"
        Else
            myString += " not visible"
        End If
        MessageBox.Show(myString, "RowHeader information")
    End Sub 'MyDelegateRowHeadersVisibleChanged
   
   
   ' raise the event when a button is clicked.
   Private Sub myButton_Click(sender As Object, e As System.EventArgs)
      If myDataGridTableStyle.RowHeadersVisible Then
         myDataGridTableStyle.RowHeadersVisible = False
      Else
         myDataGridTableStyle.RowHeadersVisible = True
      End If
   End Sub 'myButton_Click 