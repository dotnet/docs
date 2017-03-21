Private Sub CopyTreeNodes()
   ' Get the collection of TreeNodes.
   Dim myNodeCollection As TreeNodeCollection = myTreeView.Nodes
   Dim myCount As Integer = myNodeCollection.Count

   myLabel.Text += "Number of nodes in the collection :" + myCount.ToString()

   myLabel.Text += ControlChars.NewLine + ControlChars.NewLine + _
     "Elements of the Array after Copying from the collection :" + ControlChars.NewLine

   ' Create an Object array.
   Dim myArray(myCount -1) As Object

   ' Copy the collection into an array.
   myNodeCollection.CopyTo(myArray, 0)
   Dim i As Integer
   For i = 0 To myArray.Length - 1
      myLabel.Text += CType(myArray(i), TreeNode).Text + ControlChars.NewLine
   Next i
End Sub