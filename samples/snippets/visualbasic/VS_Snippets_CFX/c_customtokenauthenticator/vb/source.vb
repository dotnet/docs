'<snippet0>

Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.IdentityModel.Claims
Imports System.IdentityModel.Policy
Imports System.IdentityModel.Selectors
Imports System.IdentityModel.Tokens
Imports System.Security.Permissions
Imports System.ServiceModel.Description
Imports System.ServiceModel.Security
Imports System.ServiceModel.Security.Tokens

Namespace CustomTokenAuthenticator

    '<snippet1>
    Friend Class MySecurityTokenAuthenticator
        Inherits SecurityTokenAuthenticator

        Protected Overrides Function CanValidateTokenCore(ByVal token As SecurityToken) As Boolean
            ' Check that the incoming token is a username token type that  
            ' can be validated by this implementation.
            Return (TypeOf token Is UserNameSecurityToken)
        End Function

        Protected Overrides Function ValidateTokenCore(ByVal token As SecurityToken) As ReadOnlyCollection(Of IAuthorizationPolicy)

            Dim userNameToken = TryCast(token, UserNameSecurityToken)

            ' Validate the information contained in the username token. For demonstration 
            ' purposes, this code just checks that the user name matches the password.
            If userNameToken.UserName <> userNameToken.Password Then
                Throw New SecurityTokenValidationException("Invalid user name or password")
            End If

            ' Create just one Claim instance for the username token - the name of the user.
            Dim userNameClaimSet As New DefaultClaimSet(ClaimSet.System, _
                                                        New Claim(ClaimTypes.Name, _
                                                        userNameToken.UserName, _
                                                        Rights.PossessProperty))
            Dim policies As New List(Of IAuthorizationPolicy)(1)
            policies.Add(New MyAuthorizationPolicy(userNameClaimSet))
            Return policies.AsReadOnly()
        End Function

    End Class
    '</snippet1>

    '<snippet2>
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
    '</snippet2>

    '<snippet3>
    Friend Class MyAuthorizationPolicy
        Implements IAuthorizationPolicy

        Private _id As String
        Private _tokenClaims As ClaimSet
        Private _issuer As ClaimSet

        Public Sub New(ByVal tokenClaims As ClaimSet)
            If _tokenClaims Is Nothing Then
                Throw New ArgumentNullException("tokenClaims")
            End If
            Me._issuer = tokenClaims.Issuer
            Me._tokenClaims = tokenClaims
            Me._id = Guid.NewGuid().ToString()
        End Sub

        Public ReadOnly Property Issuer() As ClaimSet Implements IAuthorizationPolicy.Issuer
            Get
                Return _issuer
            End Get
        End Property

        Public ReadOnly Property Id() As String Implements System.IdentityModel.Policy.IAuthorizationComponent.Id
            Get
                Return _id
            End Get
        End Property

        Public Function Evaluate(ByVal evaluationContext As EvaluationContext, _
                                 ByRef state As Object) As Boolean Implements IAuthorizationPolicy.Evaluate

            ' Add the token claim set to the evaluation context.
            evaluationContext.AddClaimSet(Me, _tokenClaims)
            ' Return true if the policy evaluation is finished.
            Return True
        End Function

    End Class
    '</snippet3>

End Namespace
'</snippet0>
