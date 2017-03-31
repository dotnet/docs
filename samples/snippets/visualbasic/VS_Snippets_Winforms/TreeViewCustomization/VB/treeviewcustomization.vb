'<Snippet1>
Imports System
Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    Public Sub New()
        ' Initialize myTreeView.
        Dim myTreeView As New CustomizedTreeView
        myTreeView.Dock = DockStyle.Fill

        ' Add nodes to myTreeView.
        Dim node As TreeNode
        Dim x As Integer
        For x = 0 To 3
            ' Add a root node.
            node = myTreeView.Nodes.Add(String.Format("Node{0}", x * 4))
            Dim y As Integer
            For y = 1 To 4
                ' Add a node as a child of the previously added node.
                node = node.Nodes.Add(String.Format("Node{0}", x * 4 + y))
            Next y
        Next x

        ' Add myTreeView to the form.
        Me.Controls.Add(myTreeView)
    End Sub 'New

    <STAThreadAttribute()> _
    Shared Sub Main()
        Application.Run(New Form1)
    End Sub 'Main
End Class 'Form1

'<Snippet2>
Public Class CustomizedTreeView
    Inherits TreeView

    Public Sub New()
        ' Customize the TreeView control by setting various properties.
        BackColor = System.Drawing.Color.CadetBlue
        FullRowSelect = True
        HotTracking = True
        Indent = 34
        ShowPlusMinus = False

        ' The ShowLines property must be false for the FullRowSelect 
        ' property to work.
        ShowLines = False
    End Sub 'New


    Protected Overrides Sub OnAfterSelect(ByVal e As TreeViewEventArgs)
        ' Confirm that the user initiated the selection.
        ' This prevents the first node from expanding when it is
        ' automatically selected during the initialization of 
        ' the TreeView control.
        If e.Action <> TreeViewAction.Unknown Then
            If e.Node.IsExpanded Then
                e.Node.Collapse()
            Else
                e.Node.Expand()
            End If
        End If

        ' Remove the selection. This allows the same node to be
        ' clicked twice in succession to toggle the expansion state.
        SelectedNode = Nothing
    End Sub 'OnAfterSelect

End Class 'CustomizedTreeView 
'</Snippet2>
'</Snippet1>