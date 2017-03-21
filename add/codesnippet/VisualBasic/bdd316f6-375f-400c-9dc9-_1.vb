		Private Function CreateIdentityFromClaimSet(ByVal claims As ClaimSet) As SpnEndpointIdentity
			For Each claim As Claim In claims.FindClaims(Nothing, Rights.Identity)
				Return New SpnEndpointIdentity(claim)
			Next claim
			Return Nothing
		End Function