    Protected Overrides Function ValidateUserNamePasswordCore(ByVal userName As String, ByVal password As String) As ReadOnlyCollection(Of IAuthorizationPolicy)

        If Not ValidateUserNameFormat(userName) Then
            Throw New SecurityTokenValidationException("Incorrect UserName format")
        End If
        Dim setOfClaims As New DefaultClaimSet(ClaimSet.System, New Claim(ClaimTypes.Name, userName, Rights.PossessProperty))
        Dim identities As New List(Of IIdentity)(1)

        identities.Add(New GenericIdentity(userName))
        Dim policies As New List(Of IAuthorizationPolicy)(1)
        policies.Add(New UnconditionalPolicy(ClaimSet.System, setOfClaims, DateTime.MaxValue.ToUniversalTime(), identities))
        Return policies.AsReadOnly()

    End Function 'New
End Class