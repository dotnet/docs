 '<Snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Private treeView1 As TreeView

    Public Sub New()
        treeView1 = New TreeView()
        
        Me.SuspendLayout()
        
        ' Initialize treeView1.
        treeView1.AllowDrop = True
        treeView1.Dock = DockStyle.Fill
        
        ' Add nodes to treeView1.
        Dim node As TreeNode
        Dim x As Integer
        For x = 0 To 3
            ' Add a root node to treeView1.
            node = treeView1.Nodes.Add(String.Format("Node{0}", x * 4))
            Dim y As Integer
            For y = 1 To 4
                ' Add a child node to the previously added node.
                node = node.Nodes.Add(String.Format("Node{0}", x * 4 + y))
            Next y
        Next x

        ' Add event handlers for the required drag events.
        AddHandler treeView1.ItemDrag, AddressOf treeView1_ItemDrag
        AddHandler treeView1.DragEnter, AddressOf treeView1_DragEnter
        AddHandler treeView1.DragOver, AddressOf treeView1_DragOver
        AddHandler treeView1.DragDrop, AddressOf treeView1_DragDrop

        ' Initialize the form.
        Me.ClientSize = New Size(292, 273)
        Me.Controls.Add(treeView1)

        Me.ResumeLayout(False)
    End Sub 'New

    Shared Sub Main()
        Application.Run(New Form1)
    End Sub 'Main

    '<Snippet2>
    Private Sub treeView1_ItemDrag(ByVal sender As Object, ByVal e As ItemDragEventArgs)

        ' Move the dragged node when the left mouse button is used.
        If e.Button = MouseButtons.Left Then
            DoDragDrop(e.Item, DragDropEffects.Move)

        ' Copy the dragged node when the right mouse button is used.
        ElseIf e.Button = MouseButtons.Right Then
            DoDragDrop(e.Item, DragDropEffects.Copy)
        End If
    End Sub 'treeView1_ItemDrag
    '</Snippet2>

    ' Set the target drop effect to the effect 
    ' specified in the ItemDrag event handler.
    Private Sub treeView1_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs)
        e.Effect = e.AllowedEffect
    End Sub 'treeView1_DragEnter

    ' Select the node under the mouse pointer to indicate the 
    ' expected drop location.
    Private Sub treeView1_DragOver(ByVal sender As Object, ByVal e As DragEventArgs)
        ' Retrieve the client coordinates of the mouse position.
        Dim targetPoint As Point = treeView1.PointToClient(new Point(e.X, e.Y))

        ' Select the node at the mouse position.
        treeView1.SelectedNode = treeView1.GetNodeAt(targetPoint)
    End Sub 'treeView1_DragOver

    Private Sub treeView1_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs)

        ' Retrieve the client coordinates of the drop location.
        Dim targetPoint As Point = treeView1.PointToClient(New Point(e.X, e.Y))

        ' Retrieve the node at the drop location.
        Dim targetNode As TreeNode = treeView1.GetNodeAt(targetPoint)

        ' Retrieve the node that was dragged.
        Dim draggedNode As TreeNode = CType(e.Data.GetData(GetType(TreeNode)), TreeNode)

        ' Confirm that the node at the drop location is not 
        ' the dragged node or a descendant of the dragged node.
        If Not draggedNode.Equals(targetNode) AndAlso Not ContainsNode(draggedNode, targetNode) Then

            ' If it is a move operation, remove the node from its current 
            ' location and add it to the node at the drop location.
            If e.Effect = DragDropEffects.Move Then
                draggedNode.Remove()
                targetNode.Nodes.Add(draggedNode)

            ' If it is a copy operation, clone the dragged node 
            ' and add it to the node at the drop location.
            ElseIf e.Effect = DragDropEffects.Copy Then
                targetNode.Nodes.Add(CType(draggedNode.Clone(), TreeNode))
            End If

            ' Expand the node at the location 
            ' to show the dropped node.
            targetNode.Expand()
        End If
    End Sub 'treeView1_DragDrop

    ' Determine whether one node is a parent 
    ' or ancestor of a second node.
    Private Function ContainsNode(ByVal node1 As TreeNode, ByVal node2 As TreeNode) As Boolean

        ' Check the parent node of the second node.
        If node2.Parent Is Nothing Then
            Return False
        End If
        If node2.Parent.Equals(node1) Then
            Return True
        End If

        ' If the parent node is not null or equal to the first node, 
        ' call the ContainsNode method recursively using the parent of 
        ' the second node.
        Return ContainsNode(node1, node2.Parent)
    End Function 'ContainsNode

End Class 'Form1 
'</Snippet1>