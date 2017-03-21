	Public Class MyServiceAuthorizationManager
		Inherits ServiceAuthorizationManager
		Protected Overrides Function CheckAccessCore(ByVal operationContext As OperationContext) As Boolean
			' Extract the action URI from the OperationContext. Match this against the claims
			' in the AuthorizationContext.
			Dim action As String = operationContext.RequestContext.RequestMessage.Headers.Action
			Console.WriteLine("action: {0}", action)

			' Iterate through the various claim sets in the AuthorizationContext.
			For Each cs As ClaimSet In operationContext.ServiceSecurityContext.AuthorizationContext.ClaimSets
				' Examine only those claim sets issued by System.
				If cs.Issuer Is ClaimSet.System Then
					' Iterate through claims of type "http://example.org/claims/allowedoperation".
					For Each c As Claim In cs.FindClaims("http://example.org/claims/allowedoperation", Rights.PossessProperty)
						' Write the claim resource to the console.
						Console.WriteLine("resource: {0}", c.Resource.ToString())

						' If the claim resource matches the action URI, then return true to allow access.
						If action = c.Resource.ToString() Then
							Return True
						End If
					Next c
				End If
			Next cs

			' If this point is reached, return false to deny access.
			Return False
		End Function
	End Class