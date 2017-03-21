    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList

    ' Create an ImageList Object, populate it, and display
    ' the images it contains.
    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        ' Construct the ImageList.
        ImageList1 = New ImageList

        ' Set the ImageSize property to a larger size 
        ' (the default is 16 x 16).
        ImageList1.ImageSize = New Size(112, 112)

        ' Add two images to the list.
        ImageList1.Images.Add(Image.FromFile _
            ("c:\windows\FeatherTexture.bmp"))
        ImageList1.Images.Add _
            (Image.FromFile("C:\windows\Gone Fishing.bmp"))

        Dim count As System.Int32

        ' Get a Graphics object from the form's handle.
        Dim theGraphics As Graphics = Graphics.FromHwnd(Me.Handle)

        ' Loop through the images in the list, drawing each image.
        For count = 0 To ImageList1.Images.Count - 1
            ImageList1.Draw(theGraphics, New Point(85, 85), count)

            ' Call Application.DoEvents to force a repaint of the form.
            Application.DoEvents()

            ' Call the Sleep method to allow the user to see the image.
            System.Threading.Thread.Sleep(1000)
        Next
    End Sub
