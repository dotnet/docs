Friend Class MyServiceCredentialsSecurityTokenManager
    Inherits ServiceCredentialsSecurityTokenManager
    Private credentials As MyServiceCredentials

    Public Sub New(ByVal credentials As MyServiceCredentials) 
        MyBase.New(credentials)
        Me.credentials = credentials
    
    End Sub 'New
    
    
    Public Overrides Function CreateSecurityTokenProvider(ByVal tokenRequirement As SecurityTokenRequirement) _
    As SecurityTokenProvider
        ' Return your implementation of SecurityTokenProvider, if required.
        ' This implementation delegates to the base class.
        Return MyBase.CreateSecurityTokenProvider(tokenRequirement)

    End Function

    Public Overrides Function CreateSecurityTokenAuthenticator( _
    ByVal tokenRequirement As SecurityTokenRequirement, _
    ByRef outOfBandTokenResolver As SecurityTokenResolver) _
    As SecurityTokenAuthenticator
        ' Return your implementation of SecurityTokenProvider, if required.
        ' This implementation delegates to the base class.
        Return MyBase.CreateSecurityTokenAuthenticator(tokenRequirement, outOfBandTokenResolver)

    End Function
    
    
    Public Overrides Function CreateSecurityTokenSerializer(ByVal version As SecurityTokenVersion) _
    As SecurityTokenSerializer
        ' Return your implementation of SecurityTokenProvider, if required.
        ' This implementation delegates to the base class.
        Return MyBase.CreateSecurityTokenSerializer(version)

    End Function
End Class