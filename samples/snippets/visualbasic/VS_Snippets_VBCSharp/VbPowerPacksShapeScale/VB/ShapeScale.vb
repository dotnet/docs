Public Class ShapeScale
    ' <Snippet1>
    Private Sub OvalShape1_Click() Handles OvalShape1.Click
        Dim state As Boolean
        If state = False Then
            OvalShape1.Scale(New SizeF(2, 3))
            state = True
        Else
            OvalShape1.Scale(New SizeF(0.5, 0.333))
            state = False
        End If
    End Sub
    ' </Snippet1>
End Class
