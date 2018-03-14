 '<Snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Private treeView1 As TreeView
    Private showCheckedNodesButton As Button

    Public Sub New()
        treeView1 = New TreeView
        showCheckedNodesButton = New Button

        Me.SuspendLayout()
        
        ' Initialize treeView1.
        treeView1.Location = New Point(0, 25)
        treeView1.Size = New Size(292, 248)
        treeView1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Bottom Or AnchorStyles.Right
        treeView1.CheckBoxes = True
        
        ' Add nodes to treeView1.
        Dim node As TreeNode
        Dim x As Integer
        For x = 0 To 3
            ' Add a root node.
            node = treeView1.Nodes.Add(String.Format("Node{0}", x * 4))
            Dim y As Integer
            For y = 1 To 4
                ' Add a node as a child of the previously added node.
                node = node.Nodes.Add(String.Format("Node{0}", x * 4 + y))
            Next y
        Next x

        ' Set the checked state of one of the nodes to
        ' demonstrate the showCheckedNodesButton button behavior.
        treeView1.Nodes(1).Nodes(0).Nodes(0).Checked = True

        ' Initialize showCheckedNodesButton.
        showCheckedNodesButton.Size = New Size(144, 24)
        showCheckedNodesButton.Text = "Show Checked Nodes"
        AddHandler showCheckedNodesButton.Click, AddressOf showCheckedNodesButton_Click

        ' Initialize the form.
        Me.ClientSize = New Size(292, 273)
        Me.Controls.AddRange(New Control() {showCheckedNodesButton, treeView1})

        Me.ResumeLayout(False)
    End Sub 'New
    
    <STAThreadAttribute()> _
    Shared Sub Main()
        Application.Run(New Form1())
    End Sub 'Main
    
    '<Snippet2>
    Private Sub showCheckedNodesButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Disable redrawing of treeView1 to prevent flickering 
        ' while changes are made.
        treeView1.BeginUpdate()

        ' Collapse all nodes of treeView1.
        treeView1.ExpandAll()

        ' Add the CheckForCheckedChildren event handler to the BeforeExpand event.
        AddHandler treeView1.BeforeCollapse, AddressOf CheckForCheckedChildren

        ' Expand all nodes of treeView1. Nodes without checked children are 
        ' prevented from expanding by the checkForCheckedChildren event handler.
        treeView1.CollapseAll()

        ' Remove the checkForCheckedChildren event handler from the BeforeExpand 
        ' event so manual node expansion will work correctly.
        RemoveHandler treeView1.BeforeCollapse, AddressOf CheckForCheckedChildren
        ' Enable redrawing of treeView1.
        treeView1.EndUpdate()
    End Sub 'showCheckedNodesButton_Click


    ' Prevent collapse of a node that has checked child nodes.
    Private Sub CheckForCheckedChildren(ByVal sender As Object, ByVal e As TreeViewCancelEventArgs)
        If HasCheckedChildNodes(e.Node) Then
            e.Cancel = True
        End If
    End Sub 'CheckForCheckedChildren

    ' Returns a value indicating whether the specified 
    ' TreeNode has checked child nodes.
    Private Function HasCheckedChildNodes(ByVal node As TreeNode) As Boolean
        If node.Nodes.Count = 0 Then
            Return False
        End If
        Dim childNode As TreeNode
        For Each childNode In node.Nodes
            If childNode.Checked Then
                Return True
            End If
            ' Recursively check the children of the current child node.
            If HasCheckedChildNodes(childNode) Then
                Return True
            End If
        Next childNode
        Return False
    End Function 'HasCheckedChildNodes
    '</Snippet2>

End Class 'Form1 
'</Snippet1>