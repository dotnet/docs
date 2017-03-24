    Function IsValidFileNameOrPath(ByVal name As String) As Boolean
        ' Determines if the name is Nothing.
        If name Is Nothing Then
            Return False
        End If

        ' Determines if there are bad characters in the name.
        For Each badChar As Char In System.IO.Path.GetInvalidPathChars
            If InStr(name, badChar) > 0 Then
                Return False
            End If
        Next

        ' The name passes basic validation.
        Return True
    End Function