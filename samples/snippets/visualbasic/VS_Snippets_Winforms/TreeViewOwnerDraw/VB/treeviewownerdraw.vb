'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class TreeViewOwnerDraw
    Inherits Form

    Private WithEvents myTreeView As TreeView
    
    ' Create a Font object for the node tags.
    Private tagFont As New Font("Helvetica", 8, FontStyle.Bold)
    
    '<Snippet2>
    Public Sub New()

        ' Create and initialize the TreeView control.
        myTreeView = New TreeView()
        myTreeView.Dock = DockStyle.Fill
        myTreeView.BackColor = Color.Tan
        myTreeView.CheckBoxes = True
        
        ' Add nodes to the TreeView control.
        Dim node As TreeNode
        Dim x As Integer
        For x = 1 To 3

            ' Add a root node to the TreeView control.
            node = myTreeView.Nodes.Add(String.Format("Task {0}", x))
            Dim y As Integer
            For y = 1 To 3 

                ' Add a child node to the root node.
                node.Nodes.Add(String.Format("Subtask {0}", y))
            Next y
        Next x
        myTreeView.ExpandAll()
        
        ' Add tags containing alert messages to a few nodes 
        ' and set the node background color to highlight them.
        myTreeView.Nodes(1).Nodes(0).Tag = "urgent!"
        myTreeView.Nodes(1).Nodes(0).BackColor = Color.Yellow
        myTreeView.SelectedNode = myTreeView.Nodes(1).Nodes(0)
        myTreeView.Nodes(2).Nodes(1).Tag = "urgent!"
        myTreeView.Nodes(2).Nodes(1).BackColor = Color.Yellow
        
        ' Configure the TreeView control for owner-draw.
        myTreeView.DrawMode = TreeViewDrawMode.OwnerDrawText

        ' Add a handler for the MouseDown event so that a node can be 
        ' selected by clicking the tag text as well as the node text.
        AddHandler myTreeView.MouseDown, AddressOf myTreeView_MouseDown
        
        ' Initialize the form and add the TreeView control to it.
        Me.ClientSize = New Size(292, 273)
        Me.Controls.Add(myTreeView)
    End Sub 'New
    '</Snippet2>
    
    <STAThreadAttribute()> _
    Shared Sub Main()
        Application.Run(New TreeViewOwnerDraw())
    End Sub 'Main
    
    '<Snippet3>
    ' Draws a node.
    Private Sub myTreeView_DrawNode(ByVal sender As Object, _
        ByVal e As DrawTreeNodeEventArgs) Handles myTreeView.DrawNode

        ' Draw the background and node text for a selected node.
        If (e.State And TreeNodeStates.Selected) <> 0 Then

            ' Draw the background of the selected node. The NodeBounds
            ' method makes the highlight rectangle large enough to
            ' include the text of a node tag, if one is present.
            e.Graphics.FillRectangle(Brushes.Green, NodeBounds(e.Node))

            ' Retrieve the node font. If the node font has not been set,
            ' use the TreeView font.
            Dim nodeFont As Font = e.Node.NodeFont
            If nodeFont Is Nothing Then
                nodeFont = CType(sender, TreeView).Font
            End If

            ' Draw the node text.
            e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.White, _
                e.Bounds.Left - 2, e.Bounds.Top)

        ' Use the default background and node text.
        Else
            e.DrawDefault = True
        End If

        ' If a node tag is present, draw its string representation 
        ' to the right of the label text.
        If (e.Node.Tag IsNot Nothing) Then
            e.Graphics.DrawString(e.Node.Tag.ToString(), tagFont, _
                Brushes.Yellow, e.Bounds.Right + 2, e.Bounds.Top)
        End If

        ' If the node has focus, draw the focus rectangle large, making
        ' it large enough to include the text of the node tag, if present.
        If (e.State And TreeNodeStates.Focused) <> 0 Then
            Dim focusPen As New Pen(Color.Black)
            Try
                focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot
                Dim focusBounds As Rectangle = NodeBounds(e.Node)
                focusBounds.Size = New Size(focusBounds.Width - 1, _
                    focusBounds.Height - 1)
                e.Graphics.DrawRectangle(focusPen, focusBounds)
            Finally
                focusPen.Dispose()
            End Try
        End If

    End Sub 'myTreeView_DrawNode
    '</Snippet3>

    ' Selects a node that is clicked on its label or tag text.
    Private Sub myTreeView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim clickedNode As TreeNode = myTreeView.GetNodeAt(e.X, e.Y)
        If NodeBounds(clickedNode).Contains(e.X, e.Y) Then
            myTreeView.SelectedNode = clickedNode
        End If
    End Sub 'myTreeView_MouseDown

    ' Returns the bounds of the specified node, including the region 
    ' occupied by the node label and any node tag displayed.
    Private Function NodeBounds(ByVal node As TreeNode) As Rectangle

        ' Set the return value to the normal node bounds.
        Dim bounds As Rectangle = node.Bounds
        If (node.Tag IsNot Nothing) Then

            ' Retrieve a Graphics object from the TreeView handle
            ' and use it to calculate the display width of the tag.
            Dim g As Graphics = myTreeView.CreateGraphics()
            Dim tagWidth As Integer = CInt(g.MeasureString( _
                node.Tag.ToString(), tagFont).Width) + 6

            ' Adjust the node bounds using the calculated value.
            bounds.Offset(tagWidth \ 2, 0)
            bounds = Rectangle.Inflate(bounds, tagWidth \ 2, 0)
            g.Dispose()
        End If
        Return bounds
    End Function 'NodeBounds

End Class 'TreeViewOwnerDraw 
'</Snippet1>