    Public Function Method(ByVal value As String) As String
        EnsureNotNull(value)

        ' Fires incorrectly    
        Return value.ToString()
    End Function

    Private Sub EnsureNotNull(ByVal value As String)
        If value Is Nothing Then
            Throw (New ArgumentNullException("value"))
        End If
    End Sub