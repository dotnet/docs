    Private Sub Button3_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button3.Click

        Dim buttonGraphics As Graphics = Button3.CreateGraphics()
        Dim myPen As Pen = New Pen(Color.ForestGreen, 4.0F)
        myPen.DashStyle = Drawing2D.DashStyle.DashDotDot

        Dim theRectangle As Rectangle = Button3.ClientRectangle
        theRectangle.Inflate(-2, -2)
        buttonGraphics.DrawRectangle(myPen, theRectangle)
        buttonGraphics.Dispose()
        myPen.Dispose()
    End Sub