Public Class Form4


  '*************************************************************************
  Sub test()

    '<Snippet77>
    ' Visual Basic
    For Each selectedItem As ListViewItem In ListView1.SelectedItems
        MsgBox(selectedItem.Text)
    Next
    '</Snippet77>


    '<Snippet76>
    ' Visual Basic
    Dim theItem As ListViewItem
    If ListView1.SelectedItems.Count > 0 Then
        theItem = ListView1.SelectedItems(0)
    Else
        theItem = Nothing
    End If
    '</Snippet76>


    '<Snippet75>
    ' Visual Basic
    Dim nodX As TreeNode = New TreeNode("New Node")
    TreeView1.SelectedNode.Nodes.Add(nodX)
    '</Snippet75>
  End Sub


  '*************************************************************************
  '<Snippet74>
  ' Visual Basic
  Private Sub TreeView1_AfterSelect() Handles TreeView1.AfterSelect
      TreeView1.SelectedNode.Expand()
  End Sub
  '</Snippet74>


  '*************************************************************************
  '<Snippet78>
  ' Visual Basic
  ' Make sure that HideSelection is set to False.
  Private Sub Button1_Click() Handles Button1.Click
      Dim endChars() As Char = New Char() {".", "!", "?"}
      Dim intEnd As Integer
      intEnd = RichTextBox1.Find(endChars, RichTextBox1.SelectionStart)
      RichTextBox1.SelectionLength = intEnd - RichTextBox1.SelectionStart
  End Sub
  '</Snippet78>
End Class