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
