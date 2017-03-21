    Private Sub ShowStringTrimming(ByVal e As PaintEventArgs)

        Dim format1 As New StringFormat
        Dim quote As String = "Not everything that can be counted counts," & _
            " and not everything that counts can be counted."
        format1.Trimming = StringTrimming.EllipsisWord
        e.Graphics.DrawString(quote, Me.Font, Brushes.Black, _
            New RectangleF(10.0F, 10.0F, 90.0F, 50.0F), format1)
    End Sub