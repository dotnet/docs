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