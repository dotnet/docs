Imports Microsoft.VisualBasic.PowerPacks
Public Class SimpleShapeDraw
    ' <Snippet1>
    Private Sub Form1_Load() Handles MyBase.Load
        Dim pic As New System.Drawing.Bitmap(Me.PictureBox1.Image, 
          PictureBox1.Width, PictureBox1.Height)
        Dim rect As New System.Drawing.Rectangle
        ' Assign the client rectangle.
        rect = OvalShape1.ClientRectangle
        ' Draw the oval on the bitmap.
        OvalShape1.DrawToBitmap(pic, rect)
        PictureBox2.Image = pic
    End Sub
    ' </Snippet1>
End Class
