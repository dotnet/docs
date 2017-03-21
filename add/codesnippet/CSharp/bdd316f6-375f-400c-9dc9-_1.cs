        private SpnEndpointIdentity CreateIdentityFromClaimSet(ClaimSet claims)
        {
            foreach (Claim claim in claims.FindClaims(null, Rights.Identity))
            {
                return new SpnEndpointIdentity(claim);
            }
            return null;
        }