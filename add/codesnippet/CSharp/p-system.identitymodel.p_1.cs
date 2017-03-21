                // Iterate through the various claim sets in the AuthorizationContext.
                foreach(ClaimSet cs in operationContext.ServiceSecurityContext.AuthorizationContext.ClaimSets)
                {
                    // Examine only those claim sets issued by System.
                    if (cs.Issuer == ClaimSet.System)
                    {
                        // Iterate through claims of type "http://example.org/claims/allowedoperation".
                        foreach (Claim c in cs.FindClaims("http://example.org/claims/allowedoperation", Rights.PossessProperty))
                        {
                            // Write the Claim resource to the console.
                            Console.WriteLine("resource: {0}", c.Resource.ToString());

                            // If the Claim resource matches the action URI then return true to allow access.
                            if (action == c.Resource.ToString())
                                return true;
                        }
                    }
                }