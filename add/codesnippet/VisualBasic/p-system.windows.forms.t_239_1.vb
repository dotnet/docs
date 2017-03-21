Public Class DemoTableLayoutPanel
    Inherits TableLayoutPanel

    Protected Overrides Sub OnCellPaint( _
    ByVal e As System.Windows.Forms.TableLayoutCellPaintEventArgs)

        MyBase.OnCellPaint(e)

        Dim c As Control = Me.GetControlFromPosition(e.Column, e.Row)

        If c IsNot Nothing Then
            Dim g As Graphics = e.Graphics

            g.DrawRectangle( _
            Pens.Red, _
            e.CellBounds.Location.X + 1, _
            e.CellBounds.Location.Y + 1, _
            e.CellBounds.Width - 2, _
            e.CellBounds.Height - 2)

            g.FillRectangle( _
            Brushes.Blue, _
            e.CellBounds.Location.X + 1, _
            e.CellBounds.Location.Y + 1, _
            e.CellBounds.Width - 2, _
            e.CellBounds.Height - 2)
        End If

    End Sub

End Class