  public class MyServiceAuthorizationManager : ServiceAuthorizationManager
  {
	protected override bool CheckAccessCore(OperationContext operationContext)
	{                
	  // Extract the action URI from the OperationContext. Match this against the claims
	  // in the AuthorizationContext.
	  string action = operationContext.RequestContext.RequestMessage.Headers.Action;
	  
	  // Iterate through the various claim sets in the AuthorizationContext.
	  foreach(ClaimSet cs in operationContext.ServiceSecurityContext.AuthorizationContext.ClaimSets)
	  {
		// Examine only those claim sets issued by System.
		if (cs.Issuer == ClaimSet.System)
		{
		  // Iterate through claims of type "http://www.contoso.com/claims/allowedoperation".
            foreach (Claim c in cs.FindClaims("http://www.contoso.com/claims/allowedoperation", Rights.PossessProperty))
		  {
			// If the Claim resource matches the action URI then return true to allow access.
			if (action == c.Resource.ToString())
			  return true;
		  }
		}
	  }
	  
	  // If this point is reached, return false to deny access.
	  return false;                 
	}
  }