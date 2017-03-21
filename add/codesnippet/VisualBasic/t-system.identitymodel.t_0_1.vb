        Protected Overrides Function GetIssuedClaims(ByVal RST As RequestSecurityToken) As Collection(Of SamlAttribute)

            Dim rstAppliesTo As EndpointAddress = RST.AppliesTo

            If rstAppliesTo Is Nothing Then
                Throw New InvalidOperationException("No AppliesTo EndpointAddress in RequestSecurityToken")
            End If

            Dim bookName As String = rstAppliesTo.Headers.FindHeader(Constants.BookNameHeaderName, Constants.BookNameHeaderNamespace).GetValue(Of String)()

            If String.IsNullOrEmpty(bookName) Then
                Throw New FaultException("The book name was not specified in the RequestSecurityToken")
            End If
            EnsurePurchaseLimitSufficient(bookName)

            Dim samlAttributes As New Collection(Of SamlAttribute)()

            Dim claimSet As ClaimSet
            For Each claimSet In ServiceSecurityContext.Current.AuthorizationContext.ClaimSets
                ' Copy Name claims from the incoming credentials into the set of claims we're going to issue
                Dim nameClaims As IEnumerable(Of Claim) = claimSet.FindClaims(ClaimTypes.Name, Rights.PossessProperty)
                If Not (nameClaims Is Nothing) Then
                    Dim nameClaim As Claim
                    For Each nameClaim In nameClaims
                        samlAttributes.Add(New SamlAttribute(nameClaim))
                    Next nameClaim
                End If
            Next claimSet
            ' add a purchase authorized claim
            samlAttributes.Add(New SamlAttribute(New Claim(Constants.PurchaseAuthorizedClaim, bookName, Rights.PossessProperty)))
            Return samlAttributes

        End Function