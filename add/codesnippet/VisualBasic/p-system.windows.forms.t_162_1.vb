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