    Private Sub ImageExampleForm_Paint _
        (ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.PaintEventArgs) _
        Handles MyBase.Paint


        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create Point for upper-left corner of image.
        Dim ulCorner As New Point(100, 100)

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, ulCorner)
    End Sub