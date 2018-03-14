Public Class SimpleShapeSize
    ' <Snippet1>
    Private Sub OvalShape1_Click() Handles OvalShape1.Click
        ' Declare a Size 20 pixels wider and taller than the current Size.
        Dim sz As New System.Drawing.Size(OvalShape1.Width + 20, 
          OvalShape1.Height + 20)
        ' Change the Size.
        OvalShape1.Size = sz
    End Sub
    ' </Snippet1>
End Class
