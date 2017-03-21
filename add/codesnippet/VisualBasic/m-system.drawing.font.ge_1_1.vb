    Public Sub GetHeight_Example(ByVal e As PaintEventArgs)

        ' Create a Font object.
        Dim myFont As New Font("Arial", 16)

        'Draw text to the screen with myFont.
        e.Graphics.DrawString("This is the first line", myFont, _
        Brushes.Black, New PointF(0, 0))

        'Get the height of myFont.
        Dim height As Single = myFont.GetHeight(e.Graphics)

        'Draw text immediately below the first line of text.
        e.Graphics.DrawString("This is the second line", myFont, _
        Brushes.Black, New PointF(0, height))
    End Sub