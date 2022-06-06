'<snippet0>
Imports System.Collections.Generic
Imports System.IdentityModel.Claims
Imports System.IdentityModel.Policy
Imports System.IdentityModel.Tokens
Imports System.Security.Cryptography.X509Certificates
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Security.Tokens
Imports System.Text
'</snippet0>

Namespace Federation_Conceptual
    Friend Class Program
        Shared Sub Main()
        End Sub
    End Class
End Namespace

Namespace FederationSample
    ' <snippet1>
    Public Class myServiceAuthorizationManager
        Inherits ServiceAuthorizationManager

        ' Override the CheckAccess method to enforce access control requirements.
        Public Overloads Overrides Function CheckAccess(ByVal operationContext As OperationContext) As Boolean
            Dim authContext = operationContext.ServiceSecurityContext.AuthorizationContext
            If authContext.ClaimSets Is Nothing Then
                Return False
            End If

            If authContext.ClaimSets.Count <> 1 Then
                Return False
            End If

            Dim myClaimSet = authContext.ClaimSets(0)
            If Not IssuedBySTS_B(myClaimSet) Then
                Return False
            End If
            If myClaimSet.Count <> 1 Then
                Return False
            End If
            Dim myClaim = myClaimSet(0)
            If myClaim.ClaimType = "http://www.tmpuri.org:accessAuthorized" Then
                Dim resource = TryCast(myClaim.Resource, String)
                If resource Is Nothing Then
                    Return False
                End If
                If resource <> "true" Then
                    Return False
                End If
                Return True
            Else
                Return False
            End If
        End Function

        ' This helper method checks whether SAML Token was issued by STS-B.     
        ' It compares the Thumbprint Claim of the Issuer against the 
        ' Certificate of STS-B. 
        Private Function IssuedBySTS_B(ByVal myClaimSet As ClaimSet) As Boolean
            Dim issuerClaimSet = myClaimSet.Issuer
            If issuerClaimSet Is Nothing Then
                Return False
            End If
            If issuerClaimSet.Count <> 1 Then
                Return False
            End If
            Dim issuerClaim = issuerClaimSet(0)
            If issuerClaim.ClaimType <> ClaimTypes.Thumbprint Then
                Return False
            End If
            If issuerClaim.Resource Is Nothing Then
                Return False
            End If
            Dim claimThumbprint() = CType(issuerClaim.Resource, Byte())
            ' It is assumed that stsB_Certificate is a variable of type 
            ' X509Certificate2 that is initialized with the Certificate of 
            ' STS-B.
            Dim stsB_Certificate = GetStsBCertificate()
            Dim certThumbprint() = stsB_Certificate.GetCertHash()
            If claimThumbprint.Length <> certThumbprint.Length Then
                Return False
            End If
            For i = 0 To claimThumbprint.Length - 1
                If claimThumbprint(i) <> certThumbprint(i) Then
                    Return False
                End If
            Next i
            Return True
        End Function

        ' </snippet1>
        Public Function GetStsBCertificate() As X509Certificate2
            ' Code not shown.
            Return New X509Certificate2()
        End Function

        Private Sub ProcessSamlSecurityToken()
            Dim proofToken = "1"
            Dim issuerToken = "2"
            Dim samlConditions = "3"
            Dim samlSubjectNameFormat = "4"
            Dim samlSubjectEmailAddress = "5"

            '<snippet5>    
            ' Create the list of SAML Attributes.
            Dim samlAttributes As New List(Of SamlAttribute)()
            ' Add the userAuthenticated claim.
            Dim strList As New List(Of String)()
            strList.Add("true")
            Dim mySamlAttribute As New SamlAttribute("http://www.tmpuri.org", _
                                                     "userAuthenticated", _
                                                     strList)
            samlAttributes.Add(mySamlAttribute)
            ' Create the SAML token with the userAuthenticated claim. It is assumed that 
            ' the method CreateSamlToken() is implemented as part of STS-A.
            Dim samlToken = CreateSamlToken(proofToken, issuerToken, samlConditions, _
                                            samlSubjectNameFormat, _
                                            samlSubjectEmailAddress, _
                                            samlAttributes)
            '</snippet5>    
        End Sub

        Private Function CreateSamlToken(ByVal proofToken As String, _
                                         ByVal issuerToken As String, _
                                         ByVal samlConditions As String, _
                                         ByVal samlSubjectNameFormat As String, _
                                         ByVal samlSubjectEmailAddress As String, _
                                         ByVal samlAttributes As List(Of SamlAttribute)) As SamlSecurityToken
            Return New SamlSecurityToken(New SamlAssertion())
        End Function

    End Class
End Namespace

' <snippet2>
Public Class STS_B_AuthorizationManager
    Inherits ServiceAuthorizationManager

    ' Override AccessCheck to enforce access control requirements.
    Public Overloads Overrides Function CheckAccess(ByVal operationContext As OperationContext) As Boolean
        Dim authContext = operationContext.ServiceSecurityContext.AuthorizationContext
        If authContext.ClaimSets Is Nothing Then
            Return False
        End If
        If authContext.ClaimSets.Count <> 1 Then
            Return False
        End If
        Dim myClaimSet = authContext.ClaimSets(0)
        If Not IssuedBySTS_A(myClaimSet) Then
            Return False
        End If
        If myClaimSet.Count <> 1 Then
            Return False
        End If
        Dim myClaim = myClaimSet(0)
        If myClaim.ClaimType = "http://www.tmpuri.org:userAuthenticated" Then
            Dim resource = TryCast(myClaim.Resource, String)
            If resource Is Nothing Then
                Return False
            End If
            If resource <> "true" Then
                Return False
            End If
            Return True
        Else
            Return False
        End If
    End Function

    ' This helper method checks whether SAML Token was issued by STS-A. 
    ' It compares the Thumbprint Claim of the Issuer against the 
    ' Certificate of STS-A.
    Private Function IssuedBySTS_A(ByVal myClaimSet As ClaimSet) As Boolean
        Dim issuerClaimSet = myClaimSet.Issuer
        If issuerClaimSet Is Nothing Then
            Return False
        End If
        If issuerClaimSet.Count <> 1 Then
            Return False
        End If
        Dim issuerClaim = issuerClaimSet(0)
        If issuerClaim.ClaimType <> ClaimTypes.Thumbprint Then
            Return False
        End If
        If issuerClaim.Resource Is Nothing Then
            Return False
        End If
        Dim claimThumbprint() = CType(issuerClaim.Resource, Byte())
        ' It is assumed that stsA_Certificate is a variable of type X509Certificate2
        ' that is initialized with the Certificate of STS-A.
        Dim stsA_Certificate = GetStsACertificate()

        Dim certThumbprint() = stsA_Certificate.GetCertHash()
        If claimThumbprint.Length <> certThumbprint.Length Then
            Return False
        End If
        For i = 0 To claimThumbprint.Length - 1
            If claimThumbprint(i) <> certThumbprint(i) Then
                Return False
            End If
        Next i
        Return True
    End Function

    ' </snippet2>
    Public Function GetStsACertificate() As X509Certificate2
        ' Code not shown.
        Return New X509Certificate2()
    End Function

    Public Function ReturnSamlSecurityToken() As SamlSecurityToken
        Dim proofToken = "1"
        Dim issuerToken = "2"
        Dim samlConditions = "3"
        Dim samlSubjectNameFormat = "4"
        Dim samlSubjectEmailAddress = "5"

        '<snippet3>
        ' Create the list of SAML Attributes.
        Dim samlAttributes As New List(Of SamlAttribute)()

        ' Add the accessAuthorized claim.
        Dim strList As New List(Of String)()
        strList.Add("true")
        samlAttributes.Add(New SamlAttribute("http://www.tmpuri.org", "accessAuthorized", strList))

        ' Create the SAML token with the accessAuthorized claim. It is assumed that 
        ' the method CreateSamlToken() is implemented as part of STS-B.
        Dim samlToken = CreateSamlToken(proofToken, _
                                        issuerToken, _
                                        samlConditions, _
                                        samlSubjectNameFormat, _
                                        samlSubjectEmailAddress, _
                                        samlAttributes)
        '</snippet3>
        Return samlToken
    End Function

    Private Function CreateSamlToken(ByVal proofToken As String, _
                                     ByVal issuerToken As String, _
                                     ByVal samlConditions As String, _
                                     ByVal samlSubjectNameFormat As String, _
                                     ByVal samlSubjectEmailAddress As String, _
                                     ByVal samlAttributes As List(Of SamlAttribute)) As SamlSecurityToken
        Return New SamlSecurityToken(New SamlAssertion())
    End Function

    '<snippet4>
    Public Class STS_A_AuthorizationManager
        Inherits ServiceAuthorizationManager

        ' Override AccessCheck to enforce access control requirements.
        Public Overloads Overrides Function CheckAccess(ByVal operationContext As OperationContext) As Boolean
            Dim authContext = operationContext.ServiceSecurityContext.AuthorizationContext
            If authContext.ClaimSets Is Nothing Then
                Return False
            End If
            If authContext.ClaimSets.Count <> 1 Then
                Return False
            End If
            Dim myClaimSet = authContext.ClaimSets(0)
            If myClaimSet.Count <> 1 Then
                Return False
            End If
            Dim myClaim = myClaimSet(0)
            If myClaim.ClaimType = "http://schemas.microsoft.com/ws/2005/05/identity/claims:EmailAddress" AndAlso myClaim.Right = Rights.PossessProperty Then
                Dim emailAddress = TryCast(myClaim.Resource, String)
                If emailAddress Is Nothing Then
                    Return False
                End If
                If Not IsValidEmailAddress(emailAddress) Then
                    Return False
                End If
                Return True
            Else
                Return False
            End If
        End Function

        ' This helper method performs a rudimentary check for whether 
        'a given email is valid.
        Private Shared Function IsValidEmailAddress(ByVal emailAddress As String) As Boolean
            Dim splitEmail() = emailAddress.Split("@"c)
            If splitEmail.Length <> 2 Then
                Return False
            End If
            If Not splitEmail(1).Contains(".") Then
                Return False
            End If
            Return True
        End Function
    End Class
    '</snippet4>

    ' <snippet6>
    Public Class myService_M_AuthorizationManager
        Inherits ServiceAuthorizationManager

        ' set max size for message
        Private someMaxSize As Integer = 16000

        Public Overrides Function CheckAccess(ByVal operationContext As OperationContext, _
                                              ByRef message As Message) As Boolean
            Dim accessAllowed = False
            Dim requestBuffer = Message.CreateBufferedCopy(someMaxSize)

            ' do access checks using the message parameter value and set accessAllowed appropriately
            If accessAllowed Then
                ' replace incoming message with fresh copy since accessing the message consumes it
                Message = requestBuffer.CreateMessage()
            End If
            Return accessAllowed
        End Function
    End Class
    '</snippet6>

End Class

