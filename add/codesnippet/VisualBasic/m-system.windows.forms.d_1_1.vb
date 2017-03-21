    Public Class MyDataGrid
        Inherits DataGrid

        ' Override the OnMouseDown event to select the whole row
        ' when the user clicks anywhere on a row.

        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        ' Get the HitTestInfo to return the row and pass
        ' that value to the IsSelected property of the DataGrid.
            Dim hit As DataGrid.HitTestInfo = Me.HitTest(e.X, e.Y)
            If hit.Row < 0 Then
                Return
            End If
            If IsSelected(hit.Row) Then
                UnSelect(hit.Row)
            Else
                [Select](hit.Row)
            End If
        End Sub
    End Class