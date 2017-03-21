
Friend Class MyClientCredentialsSecurityTokenManager
    Inherits ClientCredentialsSecurityTokenManager
    Private credentials As MyClientCredentials
    
    
    Public Sub New(ByVal credentials As MyClientCredentials) 
        MyBase.New(credentials)
        Me.credentials = credentials
    
    End Sub
    
    
    Public Overrides Function CreateSecurityTokenProvider( _
    ByVal tokenRequirement As SecurityTokenRequirement) As SecurityTokenProvider
        ' Return your implementation of the SecurityTokenProvider, if required.
        ' This implementation delegates to the base class.
        Return MyBase.CreateSecurityTokenProvider(tokenRequirement)

    End Function
    
    
    Public Overrides Function CreateSecurityTokenAuthenticator( _
    ByVal tokenRequirement As SecurityTokenRequirement, _
    ByRef outOfBandTokenResolver As SecurityTokenResolver) As SecurityTokenAuthenticator
        ' Return your implementation of the SecurityTokenAuthenticator, if required.
        ' This implementation delegates to the base class.
        Return MyBase.CreateSecurityTokenAuthenticator(tokenRequirement, outOfBandTokenResolver)

    End Function
    
    
    Public Overrides Function CreateSecurityTokenSerializer(ByVal version As SecurityTokenVersion) _
    As SecurityTokenSerializer
        ' Return your implementation of the SecurityTokenSerializer, if required.
        ' This implementation delegates to the base class.
        Return MyBase.CreateSecurityTokenSerializer(version)

    End Function
End Class