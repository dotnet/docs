Private Sub GetFormats1()
   ' Creates a data object using a string and the Text format.
   Dim myDataObject As New DataObject(DataFormats.Text, "My text string")
   
   ' Gets all the data formats and data conversion formats in the data object.
   Dim allFormats As [String]() = myDataObject.GetFormats()
   
   ' Creates the string that contains the formats.
   Dim theResult As String = "The format(s) associated with the data are: " & _
                vbCr
   Dim i As Integer
   For i = 0 To allFormats.Length - 1
      theResult += allFormats(i) + vbCr
   Next i 
   ' Displays the result in a message box.
   MessageBox.Show(theResult)
End Sub 'GetFormats1