   ' Create an instance of the 'BackgroundColorChanged' EventHandler.
   Private Sub CallBackgroundColorChanged()
      AddHandler myDataGrid.BackgroundColorChanged, AddressOf Grid_ColChange
   End Sub 'CallBackgroundColorChanged
   
   
   ' Set the 'BackgroundColor' property on click of button.
    Private Sub myButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        If op_Equality(myDataGrid.BackgroundColor, Color.Yellow) Then
            myDataGrid.BackgroundColor = Color.Red
        Else
            myDataGrid.BackgroundColor = Color.Yellow
        End If
    End Sub 'myButton_Click
   
   
   ' Raise the event when 'Background' color of DataGrid changes.
    Private Sub Grid_ColChange(ByVal sender As Object, ByVal e As EventArgs)
        ' String variable used to show message.
        Dim myString As String = "BackgroundColorChanged event raised, changed to "
        ' Get the background color of DataGrid.
        Dim myColor As Color = myDataGrid.BackgroundColor
        myString += myColor.ToString()
        ' Show information about background color setting.
        MessageBox.Show(myString, "Background color information")
    End Sub 'Grid_ColChange