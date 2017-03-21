    Public Sub New(ByVal allowedIssuerName As String)
        If allowedIssuerName Is Nothing Then
            Throw New ArgumentNullException("allowedIssuerName")
        End If

        Me.allowedIssuerName = allowedIssuerName

    End Sub 'New
