    Private Sub SetPixel_Example(ByVal e As PaintEventArgs)

        ' Create a Bitmap object from a file.
        Dim myBitmap As New Bitmap("Grapes.jpg")

        ' Draw myBitmap to the screen.
        e.Graphics.DrawImage(myBitmap, 0, 0, myBitmap.Width, _
        myBitmap.Height)

        ' Set each pixel in myBitmap to black.
        Dim Xcount As Integer
        For Xcount = 0 To myBitmap.Width - 1
            Dim Ycount As Integer
            For Ycount = 0 To myBitmap.Height - 1
                myBitmap.SetPixel(Xcount, Ycount, Color.Black)
            Next Ycount
        Next Xcount

        ' Draw myBitmap to the screen again.
        e.Graphics.DrawImage(myBitmap, myBitmap.Width, 0, myBitmap.Width, _
            myBitmap.Height)
    End Sub