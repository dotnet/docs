        Private Sub HandleScroll(ByVal sender As [Object], ByVal e As ScrollEventArgs) _
          Handles vScrollBar1.Scroll, hScrollBar1.Scroll

            'Create a graphics object and draw a portion of the image in the PictureBox.
            Dim g As Graphics = pictureBox1.CreateGraphics()

            Dim xWidth As Integer = pictureBox1.Width
            Dim yHeight As Integer = pictureBox1.Height

            Dim x As Integer
            Dim y As Integer

            If (e.ScrollOrientation = ScrollOrientation.HorizontalScroll) Then

                x = e.NewValue
                y = vScrollBar1.Value

            Else 'e.ScrollOrientation == ScrollOrientation.VerticalScroll

                y = e.NewValue
                x = hScrollBar1.Value
            End If

            'First Rectangle: Where to draw the image.
            'Second Rectangle: The portion of the image to draw.

            g.DrawImage(pictureBox1.Image, _
              New Rectangle(0, 0, xWidth, yHeight), _
              New Rectangle(x, y, xWidth, yHeight), _
              GraphicsUnit.Pixel)

            pictureBox1.Update()
        End Sub