Private Sub SetData2()
   ' Creates a data object.
   Dim myDataObject As New DataObject()
   
   ' Stores a string, specifying the UnicodeText format.
   myDataObject.SetData(DataFormats.UnicodeText, "Hello World!")
   
   ' Retrieves the data by specifying the Text format.
   Dim myMessageText As String = "The data type is " & _
             myDataObject.GetData(DataFormats.Text).GetType().Name
   
   ' Displays the result.
   MessageBox.Show(myMessageText, "The Test Result")
End Sub 'SetData2