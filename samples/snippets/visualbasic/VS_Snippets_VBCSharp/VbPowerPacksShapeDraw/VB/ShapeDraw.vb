Public Class ShapeDraw

    Private Sub ShapeDraw_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' <Snippet1>
        Dim pic As New System.Drawing.Bitmap(Me.PictureBox1.Image,
         PictureBox1.Width, PictureBox1.Height)
        Dim rect As New System.Drawing.Rectangle(LineShape1.X1,
            LineShape1.Y1, LineShape1.X2 - LineShape1.X1,
            LineShape1.Y2 - LineShape1.Y1)
        LineShape1.DrawToBitmap(pic, rect)
        PictureBox2.Image = pic
        ' </Snippet1>
    End Sub
End Class
