    Shared Function IsFileURI(ByVal path As String) As Boolean
        If String.Compare(path, 0, "file:", 0, 5, True) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function