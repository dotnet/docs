   ' Create an instance of the 'CaptionVisibleChanged' EventHandler.
   Private Sub CallCaptionVisibleChanged()
      AddHandler myDataGrid.CaptionVisibleChanged, AddressOf Grid_CaptionVisibleChanged
   End Sub 'CallCaptionVisibleChanged
   
   
   ' Set the 'CaptionVisible' property on click of a button.
    Private Sub myButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        If myDataGrid.CaptionVisible = True Then
            myDataGrid.CaptionVisible = False
        Else
            myDataGrid.CaptionVisible = True
        End If
    End Sub 'myButton_Click
    
   ' Raise the event when 'CaptionVisible' property is changed.
    Private Sub Grid_CaptionVisibleChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' String variable used to show message.
        Dim myString As String = "CaptionVisibleChanged event raised, caption is"
        ' Get the state of 'CaptionVisible' property.
        Dim myBool As Boolean = myDataGrid.CaptionVisible
        ' Create appropriate alert message.
        myString += IIf(myBool, " ", " not ") + "visible"
        ' Show information about caption of DataGrid. 
        MessageBox.Show(myString, "Caption information")
    End Sub 'Grid_CaptionVisibleChanged
   