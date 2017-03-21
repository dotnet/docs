
Public Class MyServiceAuthorizationManager
    Inherits ServiceAuthorizationManager
    
    Protected Overrides Function CheckAccessCore(ByVal operationContext As OperationContext) As Boolean 
        ' Extract the action URI from the OperationContext. Match this against the claims.
        ' in the AuthorizationContext.
        Dim action As String = operationContext.RequestContext.RequestMessage.Headers.Action
        
        ' Iterate through the various claimsets in the AuthorizationContext.
        Dim cs As ClaimSet
        For Each cs In  operationContext.ServiceSecurityContext.AuthorizationContext.ClaimSets
            ' Examine only those claim sets issued by System.
            If cs.Issuer Is ClaimSet.System Then
                ' Iterate through claims of type "http://www.contoso.com/claims/allowedoperation".
                Dim c As Claim
                For Each c In  cs.FindClaims("http://www.contoso.com/claims/allowedoperation", _
                     Rights.PossessProperty)
                    ' If the Claim resource matches the action URI then return true to allow access.
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
