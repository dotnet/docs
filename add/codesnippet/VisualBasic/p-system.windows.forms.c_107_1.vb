    ' This method will change the square button to a circular button by 
    ' creating a new circle-shaped GraphicsPath object and setting it 
    ' to the RoundButton objects region.
    Private Sub roundButton_Paint(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.PaintEventArgs) Handles roundButton.Paint

        Dim buttonPath As New System.Drawing.Drawing2D.GraphicsPath

        ' Set a new rectangle to the same size as the button's 
        ' ClientRectangle property.
        Dim newRectangle As Rectangle = roundButton.ClientRectangle

        ' Decrease the size of the rectangle.
        newRectangle.Inflate(-10, -10)

        ' Draw the button's border.
        'e.Graphics.DrawEllipse(System.Drawing.Pens.Black, newRectangle)

        'Increase the size of the rectangle to include the border.
        newRectangle.Inflate(1, 1)

        ' Create a circle within the new rectangle.
        buttonPath.AddEllipse(newRectangle)
        e.Graphics.DrawPath(Pens.Black, buttonPath)
        ' Set the button's Region property to the newly created 
        ' circle region.
        roundButton.Region = New System.Drawing.Region(buttonPath)

    End Sub