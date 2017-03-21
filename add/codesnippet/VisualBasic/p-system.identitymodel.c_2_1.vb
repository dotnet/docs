            ' Write the claimsets in the authorization context. By default, there is only one claimset
            ' provided by the system. 
            Dim claimset As ClaimSet
            For Each claimset In ServiceSecurityContext.Current.AuthorizationContext.ClaimSets
                Dim claim As Claim
                For Each claim In claimset
                    ' Write out each claim type, claim value, and the right. There are two
                    ' possible values for the right: "identity" and "possessproperty". 
                    sw.WriteLine("Claim Type = {0}", claim.ClaimType)
                    sw.WriteLine(vbTab + " Resource = {0}", claim.Resource.ToString())
                    sw.WriteLine(vbTab + " Right = {0}", claim.Right)
                Next claim
            Next claimset