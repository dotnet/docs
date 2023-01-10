'<snippet0>
Imports System.IdentityModel.Selectors
Imports System.IdentityModel.Tokens
Imports System.Security.Permissions
Imports System.Security.Cryptography.X509Certificates
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.ServiceModel.Security.Tokens

'<snippet1>
Friend Class MySecurityTokenProvider
    Inherits SecurityTokenProvider
    Private certificate As X509Certificate2

    Public Sub New(ByVal certificate As X509Certificate2)
        Me.certificate = certificate

    End Sub

    Protected Overrides Function GetTokenCore(ByVal timeout As TimeSpan) As SecurityToken
        Return New X509SecurityToken(certificate)

    End Function
End Class
'</snippet1>
'<snippet2>

Friend Class MyClientCredentialsSecurityTokenManager
    Inherits ClientCredentialsSecurityTokenManager
    Private credentials As ClientCredentials


    Public Sub New(ByVal credentials As ClientCredentials)
        MyBase.New(credentials)
        Me.credentials = credentials

    End Sub


    Public Overrides Function CreateSecurityTokenProvider(ByVal tokenRequirement As SecurityTokenRequirement) As SecurityTokenProvider
        ' Return your implementation of the SecurityTokenProvider based on the 
        ' tokenRequirement argument.
        Dim result As SecurityTokenProvider
        If tokenRequirement.TokenType = SecurityTokenTypes.X509Certificate Then
            Dim direction As MessageDirection = tokenRequirement.GetProperty(Of MessageDirection) _
               (ServiceModelSecurityTokenRequirement.MessageDirectionProperty)
            If direction = MessageDirection.Output Then
                result = New MySecurityTokenProvider(credentials.ClientCertificate.Certificate)
            Else
                result = MyBase.CreateSecurityTokenProvider(tokenRequirement)
            End If
        Else
            result = MyBase.CreateSecurityTokenProvider(tokenRequirement)
        End If

        Return result

    End Function
End Class
'</snippet2>
'</snippet0>
