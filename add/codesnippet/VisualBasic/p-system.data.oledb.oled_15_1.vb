 Public Sub DisplayOleDbErrorCollection(exception As OleDbException)
     Dim i As Integer

     For i = 0 To exception.Errors.Count - 1
         MessageBox.Show("Index #" + i.ToString() + ControlChars.Cr _
            + "Message: " + exception.Errors(i).Message + ControlChars.Cr _
            + "Native: " + exception.Errors(i).NativeError.ToString() + ControlChars.Cr _
            + "Source: " + exception.Errors(i).Source + ControlChars.Cr _
            + "SQL: " + exception.Errors(i).SQLState + ControlChars.Cr)
     Next i
 End Sub