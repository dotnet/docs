Private Sub Button1_Click(sender As Object, e As EventArgs)
   myTreeView.ItemHeight = 5
   myTreeView.SelectedNode.NodeFont = New Font("Arial", 5)

   ' Get the font size from combobox.
   Dim selectedString As String = myComboBox.SelectedItem.ToString()
   Dim myNodeFontSize As Integer = Int32.Parse(selectedString)

   ' Set the font of root node.
   myTreeView.SelectedNode.NodeFont = New Font("Arial", myNodeFontSize)
   Dim i As Integer
   For  i = 0 To (myTreeView.Nodes(0).Nodes.Count) - 1
      ' Set the font of child nodes.
      myTreeView.Nodes(0).Nodes(i).NodeFont = New Font("Arial", _
        myNodeFontSize)
   Next i

   ' Get the bounds of the tree node.
   Dim myRectangle As Rectangle = myTreeView.SelectedNode.Bounds
   Dim myNodeHeight As Integer = myRectangle.Height
   If myNodeHeight < myNodeFontSize Then
      myNodeHeight = myNodeFontSize
   End If
   myTreeView.ItemHeight = myNodeHeight + 4
End Sub 