    Public Function GetUsername(ByVal username As String,
                                ByVal delimiter As Char,
                                ByVal position As Integer) As String

        Return username.Split(delimiter)(position)
    End Function