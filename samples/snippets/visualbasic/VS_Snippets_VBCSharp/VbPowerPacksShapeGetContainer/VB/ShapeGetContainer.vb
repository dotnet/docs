Public Class ShapeGetContainer
    ' <Snippet1>
    Private Sub OvalShape1_Click() Handles OvalShape1.Click
        ' Declare a Control.
        Dim ctl As Control
        ' Find the container for the OvalShape.
        ctl = OvalShape1.GetContainerControl.ActiveControl.Parent
        ' Change the color of the container.
        ctl.BackColor = Color.Blue
    End Sub
    ' </Snippet1>
End Class
