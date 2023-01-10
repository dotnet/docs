'<snippet0>
'<snippet1>
Imports System.Collections.Generic
Imports System.IdentityModel.Tokens
Imports System.Security.Cryptography.X509Certificates
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Security
Imports System.ServiceModel.Security.Tokens
Imports System.Security.Permissions
'</snippet1>

Public NotInheritable Class IssuedTokenServiceCredentialsConfiguration
    '<snippet2>
    ' This method configures the IssuedTokenAuthentication property of a ServiceHost.
    Public Shared Sub ConfigureIssuedTokenServiceCredentials( _
        ByVal sh As ServiceHost, _
        ByVal allowCardspaceTokens As Boolean, _
        ByVal knownissuers As IList(Of X509Certificate2), _
        ByVal certMode As X509CertificateValidationMode, _
        ByVal revocationMode As X509RevocationMode, _
        ByVal ser As SamlSerializer _
        )
        ' Allow CardSpace tokens.
        sh.Credentials.IssuedTokenAuthentication.AllowUntrustedRsaIssuers = _
        allowCardspaceTokens

        ' Set up known issuer certificates.
        Dim cert As X509Certificate2
        For Each cert In knownissuers
            sh.Credentials.IssuedTokenAuthentication.KnownCertificates.Add(cert)
        Next cert
        ' Set issuer certificate validation and revocation checking modes.
        sh.Credentials.IssuedTokenAuthentication.CertificateValidationMode = _
            X509CertificateValidationMode.PeerOrChainTrust
        sh.Credentials.IssuedTokenAuthentication.RevocationMode = _
        X509RevocationMode.Online

        ' Set the SamlSerializer, if one is specified.
        If Not (ser Is Nothing) Then
            sh.Credentials.IssuedTokenAuthentication.SamlSerializer = ser
        End If
    End Sub
    '</snippet2>

    ' It is a good practice to create a private constructor for a class that only 
    ' defines static methods.
    Private Sub New()

    End Sub

End Class
'</snippet0>
