    Public Overrides Sub Validate(ByVal certificate As X509Certificate2)
        ' Check that there is a certificate.
        If certificate Is Nothing Then
            Throw New ArgumentNullException("certificate")
        End If

        ' Check that the certificate issuer matches the configured issuer
        If allowedIssuerName <> certificate.IssuerName.Name Then
            Throw New SecurityTokenValidationException("Certificate was not issued by a trusted issuer")
        End If

    End Sub 'Validate
End Class 'MyX509CertificateValidator