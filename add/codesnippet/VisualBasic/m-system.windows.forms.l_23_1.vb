   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      richTextBox1.AllowDrop = True

   End Sub

   Private Sub listBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles listBox1.MouseDown
      ' Determines which item was selected.
      Dim lb As ListBox = CType(sender, ListBox)
      Dim pt As New Point(e.X, e.Y)
      'Retrieve the item at the specified location within the ListBox.
      Dim index As Integer = lb.IndexFromPoint(pt)

      ' Starts a drag-and-drop operation.
      If index >= 0 Then
         ' Retrieve the selected item text to drag into the RichTextBox.
         lb.DoDragDrop(lb.Items(index).ToString(), DragDropEffects.Copy)
      End If
   End Sub 'listBox1_MouseDown


   Private Sub richTextBox1_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles richTextBox1.DragEnter
      ' If the data is text, copy the data to the RichTextBox control.
      If e.Data.GetDataPresent("Text") Then
         e.Effect = DragDropEffects.Copy
      End If
   End Sub 'richTextBox1_DragEnter

   Private Sub richTextBox1_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles richTextBox1.DragDrop
      ' Paste the text into the RichTextBox where at selection location.
      richTextBox1.SelectedText = e.Data.GetData("System.String", True).ToString()
   End Sub 'richTextBox1_DragDrop
