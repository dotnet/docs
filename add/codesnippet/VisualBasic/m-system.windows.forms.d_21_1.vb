    ' Force the cell to repaint itself when the mouse pointer enters it.
    Protected Overrides Sub OnMouseEnter(ByVal rowIndex As Integer)
        Me.DataGridView.InvalidateCell(Me)
    End Sub

    ' Force the cell to repaint itself when the mouse pointer leaves it.
    Protected Overrides Sub OnMouseLeave(ByVal rowIndex As Integer)
        Me.DataGridView.InvalidateCell(Me)
    End Sub