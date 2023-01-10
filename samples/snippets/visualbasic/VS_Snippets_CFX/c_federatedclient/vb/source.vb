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
Namespace Samples
    '</snippet1>

    Public NotInheritable Class IssuedTokenClientCredentialsConfiguration

        '<snippet2>
        ' This method configures the IssuedToken property of the Credentials property of a proxy/channel factory
        Public Shared Sub ConfigureIssuedTokenClientCredentials(ByVal cf As ChannelFactory, _
                                                                ByVal cacheTokens As Boolean, _
                                                                ByVal tokenCacheTime As TimeSpan, _
                                                                ByVal renewalPercentage As Integer, _
                                                                ByVal entropyMode As SecurityKeyEntropyMode)
            If cf Is Nothing Then
                Throw New ArgumentNullException("ChannelFactory")
            End If
            ' Set the CacheIssuedTokens property
            With cf.Credentials.IssuedToken
                .CacheIssuedTokens = cacheTokens

                ' Set the MaxIssuedTokenCachingTime property
                .MaxIssuedTokenCachingTime = tokenCacheTime

                ' Set the IssuedTokenRenewalThresholdPercentage property
                .IssuedTokenRenewalThresholdPercentage = renewalPercentage

                ' Set the DefaulyKeyEntropyMode property
                .DefaultKeyEntropyMode = entropyMode
            End With
        End Sub

        '</snippet2>

        ' It is a good practice to create a private constructor for a class that only 
        ' defines static methods.
        Private Sub New()
        End Sub
    End Class
End Namespace
'</snippet0>


