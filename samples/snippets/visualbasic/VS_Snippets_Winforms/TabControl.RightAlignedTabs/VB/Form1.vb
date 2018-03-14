Public Class Form1

    '<SNIPPET1>
    Private Sub TabControl1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem
        Dim g As Graphics = e.Graphics
        Dim _TextBrush As Brush

        ' Get the item from the collection.
        Dim _TabPage As TabPage = TabControl1.TabPages(e.Index)

        ' Get the real bounds for the tab rectangle.
        Dim _TabBounds As Rectangle = TabControl1.GetTabRect(e.Index)

        If (e.State = DrawItemState.Selected) Then
            ' Draw a different background color, and don't paint a focus rectangle.
            _TextBrush = New SolidBrush(Color.Red)
            g.FillRectangle(Brushes.Gray, e.Bounds)
        Else
            _TextBrush = New System.Drawing.SolidBrush(e.ForeColor)
            e.DrawBackground()
        End If

        ' Use our own font.
        Dim _TabFont As New Font("Arial", 10.0, FontStyle.Bold, GraphicsUnit.Pixel)

        ' Draw string. Center the text.
        Dim _StringFlags As New StringFormat()
        _StringFlags.Alignment = StringAlignment.Center
        _StringFlags.LineAlignment = StringAlignment.Center
        g.DrawString(_TabPage.Text, _TabFont, _TextBrush, _TabBounds, New StringFormat(_StringFlags))
    End Sub
    '</SNIPPET1>
End Class
