Private Sub SetCursor()
   ' Display an OpenFileDialog so the user can select a Cursor.
   Dim openFileDialog1 As New OpenFileDialog()
   openFileDialog1.Filter = "Cursor Files|*.cur"
   openFileDialog1.Title = "Select a Cursor File"
   openFileDialog1.ShowDialog()
         
   ' If a .cur file was selected, open it.
   If openFileDialog1.FileName <> "" Then
      ' Assign the cursor in the stream to the form's Cursor property.
      Me.Cursor = New Cursor(openFileDialog1.OpenFile())
   End If
End Sub     