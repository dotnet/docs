    Private Sub ShowLineAndAlignment(ByVal e As PaintEventArgs)

        ' Construct a new Rectangle.
        Dim displayRectangle _
            As New Rectangle(New Point(40, 40), New Size(80, 80))

        ' Construct two new StringFormat objects
        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        Dim format2 As New StringFormat(format1)

        ' Set the LineAlignment and Alignment properties for
        ' both StringFormat objects to different values.
        format1.LineAlignment = StringAlignment.Near
        format1.Alignment = StringAlignment.Center
        format2.LineAlignment = StringAlignment.Center
        format2.Alignment = StringAlignment.Far

        ' Draw the bounding rectangle and a string for each
        ' StringFormat object.
        e.Graphics.DrawRectangle(Pens.Black, displayRectangle)
        e.Graphics.DrawString("Showing Format1", Me.Font, Brushes.Red, _
            RectangleF.op_Implicit(displayRectangle), format1)
        e.Graphics.DrawString("Showing Format2", Me.Font, Brushes.Red, _
            RectangleF.op_Implicit(displayRectangle), format2)
    End Sub