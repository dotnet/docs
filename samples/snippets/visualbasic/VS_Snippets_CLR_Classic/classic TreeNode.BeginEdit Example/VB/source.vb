Imports System
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected treeView1 As TreeView
    Protected mySelectedNode As TreeNode
    
    
' <Snippet1>
' Get the tree node under the mouse pointer and
' save it in the mySelectedNode variable. 
Private Sub treeView1_MouseDown(sender As Object, _
  e As System.Windows.Forms.MouseEventArgs)
        
   mySelectedNode = treeView1.GetNodeAt(e.X, e.Y)
End Sub    
    
Private Sub menuItem1_Click(sender As Object, e As System.EventArgs)
   If Not (mySelectedNode Is Nothing) And _
     Not (mySelectedNode.Parent Is Nothing) Then
      treeView1.SelectedNode = mySelectedNode
      treeView1.LabelEdit = True
      If Not mySelectedNode.IsEditing Then
         mySelectedNode.BeginEdit()
      End If
   Else
      MessageBox.Show("No tree node selected or selected node is a root node." & _
        Microsoft.VisualBasic.ControlChars.Cr & _
        "Editing of root nodes is not allowed.", "Invalid selection")
   End If
End Sub    
    
Private Sub treeView1_AfterLabelEdit(sender As Object, _
  e As System.Windows.Forms.NodeLabelEditEventArgs)
   If Not (e.Label Is Nothing) Then
      If e.Label.Length > 0 Then
         If e.Label.IndexOfAny(New Char() {"@"c, "."c, ","c, "!"c}) = -1 Then
            ' Stop editing without canceling the label change.
            e.Node.EndEdit(False)
         Else
            ' Cancel the label edit action, inform the user, and
            ' place the node in edit mode again. 
            e.CancelEdit = True
            MessageBox.Show("Invalid tree node label." & _
              Microsoft.VisualBasic.ControlChars.Cr & _
              "The invalid characters are: '@','.', ',', '!'", _
              "Node Label Edit")
            e.Node.BeginEdit()
         End If
      Else
         ' Cancel the label edit action, inform the user, and
         ' place the node in edit mode again. 
         e.CancelEdit = True
         MessageBox.Show("Invalid tree node label." & _
           Microsoft.VisualBasic.ControlChars.Cr & _
           "The label cannot be blank", "Node Label Edit")
           e.Node.BeginEdit()
      End If
   End If
End Sub 
' </Snippet1>

End Class 'Form1 
