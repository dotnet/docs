    Friend Class MyServiceCredentialsSecurityTokenManager
        Inherits ServiceCredentialsSecurityTokenManager

        Private credentials As ServiceCredentials

        Public Sub New(ByVal credentials As ServiceCredentials)
            MyBase.New(credentials)
            Me.credentials = credentials
        End Sub

        Public Overrides Function CreateSecurityTokenAuthenticator(ByVal tokenRequirement As SecurityTokenRequirement, _
                                                                   <System.Runtime.InteropServices.Out()> _
                                                                   ByRef outOfBandTokenResolver _
                                                                   As SecurityTokenResolver) As SecurityTokenAuthenticator
            ' Return your implementation of the SecurityTokenProvider based on the 
            ' tokenRequirement argument.
            Dim result As SecurityTokenAuthenticator
            If tokenRequirement.TokenType = SecurityTokenTypes.UserName Then
                Dim direction = tokenRequirement.GetProperty(Of MessageDirection)(ServiceModelSecurityTokenRequirement.MessageDirectionProperty)
                If direction = MessageDirection.Input Then
                    outOfBandTokenResolver = Nothing
                    result = New MySecurityTokenAuthenticator()
                Else
                    result = MyBase.CreateSecurityTokenAuthenticator(tokenRequirement, _
                                                                     outOfBandTokenResolver)
                End If
            Else
                result = MyBase.CreateSecurityTokenAuthenticator(tokenRequirement, _
                                                                 outOfBandTokenResolver)
            End If

            Return result
        End Function

    End Class