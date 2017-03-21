    public class myServiceAuthorizationManager : ServiceAuthorizationManager 
    {
        // Override the CheckAccess method to enforce access control requirements.
        public override bool CheckAccess(OperationContext operationContext)
        {
            AuthorizationContext authContext =
            operationContext.ServiceSecurityContext.AuthorizationContext;
            if (authContext.ClaimSets == null) return false;
            if (authContext.ClaimSets.Count != 1) return false;
            ClaimSet myClaimSet = authContext.ClaimSets[0];
            if (!IssuedBySTS_B(myClaimSet)) return false;
            if (myClaimSet.Count != 1) return false;
            Claim myClaim = myClaimSet[0];
            if (myClaim.ClaimType ==
              "http://www.tmpuri.org:accessAuthorized")
            {
                string resource = myClaim.Resource as string;
                if (resource == null) return false;
                if (resource != "true") return false;
                return true;
            }
            else return false;
        }

        // This helper method checks whether SAML Token was issued by STS-B.     
        // It compares the Thumbprint Claim of the Issuer against the 
        // Certificate of STS-B. 
        private bool IssuedBySTS_B(ClaimSet myClaimSet)
        {
            ClaimSet issuerClaimSet = myClaimSet.Issuer;
            if (issuerClaimSet == null) return false;
            if (issuerClaimSet.Count != 1) return false;
            Claim issuerClaim = issuerClaimSet[0];
            if (issuerClaim.ClaimType != ClaimTypes.Thumbprint)
                return false;
            if (issuerClaim.Resource == null) return false;
            byte[] claimThumbprint = (byte[])issuerClaim.Resource;
            // It is assumed that stsB_Certificate is a variable of type 
            // X509Certificate2 that is initialized with the Certificate of 
            // STS-B.
            X509Certificate2 stsB_Certificate = GetStsBCertificate();
            byte[] certThumbprint = stsB_Certificate.GetCertHash();
            if (claimThumbprint.Length != certThumbprint.Length)
                return false;
            for (int i = 0; i < claimThumbprint.Length; i++)
            {
                if (claimThumbprint[i] != certThumbprint[i]) return false;
            }
            return true;
        }