Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
   ' Sets the AllowDrop property so that data can be dragged onto the control.
   RichTextBox1.AllowDrop = True

   ' Add code here to populate the ListBox1 with paths to text files.

End Sub

Private Sub RichTextBox1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles RichTextBox1.DragEnter
   ' If the data is text, copy the data to the RichTextBox control.
   If (e.Data.GetDataPresent("Text")) Then
      e.Effect = DragDropEffects.Copy
   End If
End Sub


Private Overloads Sub RichTextBox1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles RichTextBox1.DragDrop
   ' Loads the file into the control. 
   RichTextBox1.LoadFile(e.Data.GetData("Text"), System.Windows.Forms.RichTextBoxStreamType.RichText)
End Sub

Private Sub ListBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseDown
   Dim Lb As ListBox
   Dim Pt As New Point(e.X, e.Y)
   Dim Index As Integer

   ' Determines which item was selected.
   Lb = sender
   Index = Lb.IndexFromPoint(Pt)

   ' Starts a drag-and-drop operation with that item.
   If Index >= 0 Then
      Lb.DoDragDrop(Lb.Items(Index), DragDropEffects.Link)
   End If
End Sub