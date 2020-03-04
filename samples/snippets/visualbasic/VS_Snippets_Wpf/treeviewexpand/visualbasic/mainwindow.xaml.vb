''' <summary> 
''' Interaction logic for MainWindow.xaml 
''' </summary> 
Partial Public Class MainWindow
    Inherits Window
    Public Sub New()
        InitializeComponent()
    End Sub


    '<Snippet2> 
    Private Sub expandSelected_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If treeView1.SelectedItem Is Nothing Then
            Exit Sub
        End If

        Dim tvi As TreeViewItem =
            GetTreeViewItem(treeView1, treeView1.SelectedItem)

        If tvi IsNot Nothing Then
            tvi.ExpandSubtree()
        End If
    End Sub

    ' Traverse the TreeView to find the TreeViewItem 
    ' that corresponds to the selected item. 
    Private Function GetTreeViewItem(ByVal parent As ItemsControl,
                                     ByVal item As Object) As TreeViewItem

        ' Check whether the selected item is a direct child of 
        ' the parent ItemsControl. 
        Dim tvi As TreeViewItem =
            TryCast(parent.ItemContainerGenerator.ContainerFromItem(item), TreeViewItem)

        If tvi Is Nothing Then
            ' The selected item is not a child of parent, so check 
            ' the child items of parent. 
            For Each child As Object In parent.Items
                Dim childItem As TreeViewItem =
                    TryCast(parent.ItemContainerGenerator.ContainerFromItem(child), TreeViewItem)

                If childItem IsNot Nothing Then
                    ' Check the next level for the appropriate item. 
                    tvi = GetTreeViewItem(childItem, item)
                End If
            Next
        End If
        Return tvi
    End Function
    '</Snippet2> 

End Class