 Public Sub DisplayOleDbErrors(exception As OleDbException)
     Dim i As Integer

     For i = 0 To exception.Errors.Count - 1
         MessageBox.Show("Index #" + i.ToString() + ControlChars.Cr _
            + "Error: " + exception.Errors(i).ToString() + ControlChars.Cr)
     Next i
 End Sub