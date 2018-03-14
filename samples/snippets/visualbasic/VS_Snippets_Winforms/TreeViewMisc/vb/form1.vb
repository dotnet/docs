Imports System
Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

    Private treeView1 As New TreeView()

    Public Sub New()
        treeView1.Dock = DockStyle.Fill
        Controls.Add(treeView1)
        InitializeTreeView()
    End Sub

    '<snippet10>
    ' Populates a TreeView control with example nodes. 
    Private Sub InitializeTreeView()
        treeView1.BeginUpdate()
        treeView1.Nodes.Add("Parent")
        treeView1.Nodes(0).Nodes.Add("Child 1")
        treeView1.Nodes(0).Nodes.Add("Child 2")
        treeView1.Nodes(0).Nodes(1).Nodes.Add("Grandchild")
        treeView1.Nodes(0).Nodes(1).Nodes(0).Nodes.Add("Great Grandchild")
        treeView1.EndUpdate()
    End Sub
    '</snippet10>

End Class
