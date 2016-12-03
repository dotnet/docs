    Private _sr As IO.StreamReader

    Public Sub New(ByVal filePath As String)
        _sr = New IO.StreamReader(filePath)
    End Sub