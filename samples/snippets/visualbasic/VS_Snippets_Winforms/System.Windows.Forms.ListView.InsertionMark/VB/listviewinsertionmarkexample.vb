'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class ListViewInsertionMarkExample
    Inherits Form

    Private myListView As ListView
    
    '<Snippet2>
    Public Sub New()
        ' Initialize myListView.
        myListView = New ListView()
        myListView.Dock = DockStyle.Fill
        myListView.View = View.LargeIcon
        myListView.MultiSelect = False
        myListView.ListViewItemSorter = New ListViewIndexComparer()
        
        ' Initialize the insertion mark.
        myListView.InsertionMark.Color = Color.Green
        
        ' Add items to myListView.
        myListView.Items.Add("zero")
        myListView.Items.Add("one")
        myListView.Items.Add("two")
        myListView.Items.Add("three")
        myListView.Items.Add("four")
        myListView.Items.Add("five")
        
        ' Initialize the drag-and-drop operation when running
        ' under Windows XP or a later operating system.
        If OSFeature.Feature.IsPresent(OSFeature.Themes)
            myListView.AllowDrop = True
            AddHandler myListView.ItemDrag, AddressOf myListView_ItemDrag
            AddHandler myListView.DragEnter, AddressOf myListView_DragEnter
            AddHandler myListView.DragOver, AddressOf myListView_DragOver
            AddHandler myListView.DragLeave, AddressOf myListView_DragLeave
            AddHandler myListView.DragDrop, AddressOf myListView_DragDrop
        End If 

        ' Initialize the form.
        Me.Text = "ListView Insertion Mark Example"
        Me.Controls.Add(myListView)
    End Sub 'New
    '</Snippet2>

    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New ListViewInsertionMarkExample())
    End Sub 'Main
    
    ' Starts the drag-and-drop operation when an item is dragged.
    Private Sub myListView_ItemDrag(sender As Object, e As ItemDragEventArgs)
        myListView.DoDragDrop(e.Item, DragDropEffects.Move)
    End Sub 'myListView_ItemDrag
    
    ' Sets the target drop effect.
    Private Sub myListView_DragEnter(sender As Object, e As DragEventArgs)
        e.Effect = e.AllowedEffect
    End Sub 'myListView_DragEnter
    
    '<Snippet3>
    ' Moves the insertion mark as the item is dragged.
    Private Sub myListView_DragOver(sender As Object, e As DragEventArgs)
        ' Retrieve the client coordinates of the mouse pointer.
        Dim targetPoint As Point = myListView.PointToClient(New Point(e.X, e.Y))
        
        ' Retrieve the index of the item closest to the mouse pointer.
        Dim targetIndex As Integer = _
            myListView.InsertionMark.NearestIndex(targetPoint)
        
        ' Confirm that the mouse pointer is not over the dragged item.
        If targetIndex > -1 Then
            ' Determine whether the mouse pointer is to the left or
            ' the right of the midpoint of the closest item and set
            ' the InsertionMark.AppearsAfterItem property accordingly.
            Dim itemBounds As Rectangle = myListView.GetItemRect(targetIndex)
            If targetPoint.X > itemBounds.Left + (itemBounds.Width / 2) Then
                myListView.InsertionMark.AppearsAfterItem = True
            Else
                myListView.InsertionMark.AppearsAfterItem = False
            End If
        End If
        
        ' Set the location of the insertion mark. If the mouse is
        ' over the dragged item, the targetIndex value is -1 and
        ' the insertion mark disappears.
        myListView.InsertionMark.Index = targetIndex
    End Sub 'myListView_DragOver
    '</Snippet3>

    ' Removes the insertion mark when the mouse leaves the control.
    Private Sub myListView_DragLeave(sender As Object, e As EventArgs)
        myListView.InsertionMark.Index = -1
    End Sub 'myListView_DragLeave
    
    ' Moves the item to the location of the insertion mark.
    Private Sub myListView_DragDrop(sender As Object, e As DragEventArgs)
        ' Retrieve the index of the insertion mark;
        Dim targetIndex As Integer = myListView.InsertionMark.Index
        
        ' If the insertion mark is not visible, exit the method.
        If targetIndex = -1 Then
            Return
        End If 

        ' If the insertion mark is to the right of the item with
        ' the corresponding index, increment the target index.
        If myListView.InsertionMark.AppearsAfterItem Then
            targetIndex += 1
        End If 

        ' Retrieve the dragged item.
        Dim draggedItem As ListViewItem = _
            CType(e.Data.GetData(GetType(ListViewItem)), ListViewItem)
        
        ' Insert a copy of the dragged item at the target index.
        ' A copy must be inserted before the original item is removed
        ' to preserve item index values.
        myListView.Items.Insert(targetIndex, _
            CType(draggedItem.Clone(), ListViewItem))
        
        ' Remove the original copy of the dragged item.
        myListView.Items.Remove(draggedItem)

    End Sub 'myListView_DragDrop
    
    ' Sorts ListViewItem objects by index.    
    Private Class ListViewIndexComparer
        Implements System.Collections.IComparer
        
        Public Function Compare(x As Object, y As Object) As Integer _
            Implements System.Collections.IComparer.Compare
            Return CType(x, ListViewItem).Index - CType(y, ListViewItem).Index
        End Function 'Compare

    End Class 'ListViewIndexComparer

End Class 'ListViewInsertionMarkExample 
'</Snippet1>