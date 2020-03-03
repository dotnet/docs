Public Class SimpleShapeBackGroundImage
    ' <Snippet1>
    Private Sub Form1_Load() Handles MyBase.Load
        ' Assign an image resource.
        OvalShape1.BackgroundImage = My.Resources.Image1
        ' Resize the image to fit the oval.
        OvalShape1.BackgroundImageLayout = ImageLayout.Stretch
    End Sub
    ' </Snippet1>
End Class
