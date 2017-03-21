                // Write the claimsets in the authorization context. By default, there is only one claimset
                // provided by the system. 
                foreach (ClaimSet claimset in ServiceSecurityContext.Current.AuthorizationContext.ClaimSets)
                {
                    foreach (Claim claim in claimset)
                    {
                        // Write out each claim type, claim value, and the right. There are two
                        // possible values for the right: "identity" and "possessproperty". 
                        sw.WriteLine("Claim Type = {0}", claim.ClaimType);
                        sw.WriteLine("\t Resource = {0}", claim.Resource.ToString());
                        sw.WriteLine("\t Right = {0}", claim.Right);
                    }
                }