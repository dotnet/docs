Public Class SimpleShapeLocation
    ' <Snippet1>
    Private Sub OvalShape1_Click() Handles OvalShape1.Click
        ' Move the shape incrementally until it reaches the bottom 
        ' of the form.
        If OvalShape1.Bottom < Me.ClientSize.Height - 50 Then
            ' Move down 50 pixels.
            OvalShape1.Location = New Point(OvalShape1.Left, 
              OvalShape1.Top + 50)
        Else
            ' Move back to the top.
            OvalShape1.Location = New Point(OvalShape1.Left, 0)
        End If
    End Sub
    ' </Snippet1>
End Class
