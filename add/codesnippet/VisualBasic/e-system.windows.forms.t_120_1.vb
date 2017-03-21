   ' This method defines the DragOver event behavior. 
   Protected Overrides Sub OnDragOver(dea As DragEventArgs)
      MyBase.OnDragOver(dea)
      
      ' Get the ToolStripButton control 
      ' at the given mouse position.
      Dim p As New Point(dea.X, dea.Y)
      Dim item As ToolStripButton = CType(Me.GetItemAt(Me.PointToClient(p)), ToolStripButton)
      
      
      ' If the ToolStripButton control is the empty cell,
      ' indicate that the move operation is valid.
        If item Is Me.emptyCellButton Then
            ' Set the drag operation to indicate a valid move.
            dea.Effect = DragDropEffects.Move
        End If
    End Sub