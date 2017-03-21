                        // Iterate through claims of type "http://example.org/claims/allowedoperation".
                        foreach (Claim c in cs.FindClaims("http://example.org/claims/allowedoperation", 
                            Rights.PossessProperty))
                        {