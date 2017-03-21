    Public Sub FromArgb3(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics

        ' Opaque colors (alpha value defaults to 255 -- max value).
        Dim red As Color = Color.FromArgb(255, 0, 0)
        Dim green As Color = Color.FromArgb(0, 255, 0)
        Dim blue As Color = Color.FromArgb(0, 0, 255)

        ' Solid brush initialized to red.
        Dim myBrush As New SolidBrush(red)
        Dim alpha As Integer

        ' x coordinate of first red rectangle.
        Dim x As Integer = 50

        ' y coordinate of first red rectangle.
        Dim y As Integer = 50

        ' Fill rectangles with red, varying the alpha value from 25 to 250.
        For alpha = 25 To 250 Step 25
            myBrush.Color = Color.FromArgb(alpha, red)
            g.FillRectangle(myBrush, x, y, 50, 100)
            g.FillRectangle(myBrush, x, y + 250, 50, 50)
            x += 50
        Next alpha

        ' x coordinate of first green rectangle.
        x = 50

        ' y coordinate of first green rectangle.
        y += 50

        ' Fill rectangles with green, varying alpha value from 25 to 250.
        For alpha = 25 To 250 Step 25
            myBrush.Color = Color.FromArgb(alpha, green)
            g.FillRectangle(myBrush, x, y, 50, 150)
            x += 50
        Next alpha

        ' x coordinate of first blue rectangle.
        x = 50

        ' y coordinate of first blue rectangle.
        y += 100

        ' Fill rectangles with blue, varying alpha value from 25 to 250.
        For alpha = 25 To 250 Step 25
            myBrush.Color = Color.FromArgb(alpha, blue)
            g.FillRectangle(myBrush, x, y, 50, 150)
            x += 50
        Next alpha
    End Sub