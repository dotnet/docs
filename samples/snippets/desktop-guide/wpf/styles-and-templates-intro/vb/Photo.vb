' <PhotoClass>
Public Class Photo
    Sub New(ByVal path As String)
        Source = path
    End Sub

    Public ReadOnly Property Source As String

    Public Overrides Function ToString() As String
        Return Source
    End Function
End Class
' </PhotoClass>
