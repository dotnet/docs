Public Class LineScale
    ' <Snippet1>
    Private Sub LineScale_Load() Handles MyBase.Load
        LineShape1.X1 = 0
        LineShape1.Y1 = 0
        LineShape1.X2 = 40
        LineShape1.Y2 = 40
    End Sub
    Private Sub Button1_Click() Handles Button1.Click
        ScaleMe(2, 2.5)
    End Sub
    Private Sub ScaleMe(ByVal x As Single, ByVal y As Single)
        Dim newsize As New SizeF(x, y)
        LineShape1.Scale(newsize)
    End Sub
    ' </Snippet1>
    
End Class
