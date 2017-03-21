        // Utility function to create an EndpointIdentity from a ClaimSet.
        private EndpointIdentity CreateIdentityFromClaimSet(ClaimSet claims)
        {
            foreach (Claim claim in claims.FindClaims(null, Rights.Identity))
            {
                return EndpointIdentity.CreateIdentity(claim);
            }
            return null;
        }