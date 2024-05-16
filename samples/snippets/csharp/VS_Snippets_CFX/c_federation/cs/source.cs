//<snippet0>
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
//</snippet0>

namespace Federation_Conceptual
{
    class Program
    {
        static void Main()
        {
        }
    }
}

namespace FederationSample
{
    // <snippet1>
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
            else
            {
                return false;
            }
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
        // </snippet1>
        public X509Certificate2 GetStsBCertificate()
        {
            // Code not shown.
            return new X509Certificate2();
        }

        private void ProcessSamlSecurityToken()
        {
            string proofToken = "1";
            string issuerToken = "2";
            string samlConditions = "3";
            string samlSubjectNameFormat = "4";
            string samlSubjectEmailAddress = "5";

            //<snippet5>
            // Create the list of SAML Attributes.
            List<SamlAttribute> samlAttributes = new List<SamlAttribute>();
            // Add the userAuthenticated claim.
            List<string> strList = new List<string>();
            strList.Add("true");
            SamlAttribute mySamlAttribute = new SamlAttribute("http://www.tmpuri.org",
                 "userAuthenticated", strList);
            samlAttributes.Add(mySamlAttribute);
            // Create the SAML token with the userAuthenticated claim. It is assumed that
            // the method CreateSamlToken() is implemented as part of STS-A.
            SamlSecurityToken samlToken = CreateSamlToken(
                proofToken,
                issuerToken,
                samlConditions,
                samlSubjectNameFormat,
                samlSubjectEmailAddress,
                samlAttributes);
            //</snippet5>
        }
        private SamlSecurityToken CreateSamlToken(string proofToken, string issuerToken,
    string samlConditions, string samlSubjectNameFormat, string samlSubjectEmailAddress,
     List<SamlAttribute> samlAttributes)
        {
            return new SamlSecurityToken(new SamlAssertion());
        }
    }
}

// <snippet2>
public class STS_B_AuthorizationManager : ServiceAuthorizationManager
{

    // Override AccessCheck to enforce access control requirements.
    public override bool CheckAccess(OperationContext operationContext)
    {
        AuthorizationContext authContext =
        operationContext.ServiceSecurityContext.AuthorizationContext;
        if (authContext.ClaimSets == null) return false;
        if (authContext.ClaimSets.Count != 1) return false;
        ClaimSet myClaimSet = authContext.ClaimSets[0];
        if (!IssuedBySTS_A(myClaimSet)) return false;
        if (myClaimSet.Count != 1) return false;
        Claim myClaim = myClaimSet[0];
        if (myClaim.ClaimType == "http://www.tmpuri.org:userAuthenticated")
        {
            string resource = myClaim.Resource as string;
            if (resource == null) return false;
            if (resource != "true") return false;
            return true;
        }
        else
        {
            return false;
        }
    }

    // This helper method checks whether SAML Token was issued by STS-A.
    // It compares the Thumbprint Claim of the Issuer against the
    // Certificate of STS-A.
    private bool IssuedBySTS_A(ClaimSet myClaimSet)
    {
        ClaimSet issuerClaimSet = myClaimSet.Issuer;
        if (issuerClaimSet == null) return false;
        if (issuerClaimSet.Count != 1) return false;
        Claim issuerClaim = issuerClaimSet[0];
        if (issuerClaim.ClaimType != ClaimTypes.Thumbprint) return false;
        if (issuerClaim.Resource == null) return false;
        byte[] claimThumbprint = (byte[])issuerClaim.Resource;
        // It is assumed that stsA_Certificate is a variable of type X509Certificate2
        // that is initialized with the Certificate of STS-A.
        X509Certificate2 stsA_Certificate = GetStsACertificate();

        byte[] certThumbprint = stsA_Certificate.GetCertHash();
        if (claimThumbprint.Length != certThumbprint.Length) return false;
        for (int i = 0; i < claimThumbprint.Length; i++)
        {
            if (claimThumbprint[i] != certThumbprint[i]) return false;
        }
        return true;
    }
    // </snippet2>
    public X509Certificate2 GetStsACertificate()
    {
        // Code not shown.
        return new X509Certificate2();
    }

    public SamlSecurityToken ReturnSamlSecurityToken()
    {
        string proofToken = "1";
        string issuerToken = "2";
        string samlConditions = "3";
        string samlSubjectNameFormat = "4";
        string samlSubjectEmailAddress = "5";

        //<snippet3>
        // Create the list of SAML Attributes.
        List<SamlAttribute> samlAttributes = new List<SamlAttribute>();

        // Add the accessAuthorized claim.
        List<string> strList = new List<string>();
        strList.Add("true");
        samlAttributes.Add(new SamlAttribute("http://www.tmpuri.org",
        "accessAuthorized",
        strList));

        // Create the SAML token with the accessAuthorized claim. It is assumed that
        // the method CreateSamlToken() is implemented as part of STS-B.
        SamlSecurityToken samlToken = CreateSamlToken(
            proofToken,
            issuerToken,
            samlConditions,
            samlSubjectNameFormat,
            samlSubjectEmailAddress,
            samlAttributes);
        //</snippet3>
        return samlToken;
    }

    private SamlSecurityToken CreateSamlToken(string proofToken, string issuerToken,
        string samlConditions, string samlSubjectNameFormat, string samlSubjectEmailAddress,
         List<SamlAttribute> samlAttributes)
    {
        return new SamlSecurityToken(new SamlAssertion());
    }

    //<snippet4>

    public class STS_A_AuthorizationManager : ServiceAuthorizationManager
    {
        // Override AccessCheck to enforce access control requirements.
        public override bool CheckAccess(OperationContext operationContext)
        {
            AuthorizationContext authContext =
            operationContext.ServiceSecurityContext.AuthorizationContext;
            if (authContext.ClaimSets == null) return false;
            if (authContext.ClaimSets.Count != 1) return false;
            ClaimSet myClaimSet = authContext.ClaimSets[0];
            if (myClaimSet.Count != 1) return false;
            Claim myClaim = myClaimSet[0];
            if ((myClaim.ClaimType ==
            @"http://schemas.microsoft.com/ws/2005/05/identity/claims:EmailAddress") &&
            (myClaim.Right == Rights.PossessProperty))
            {
                string emailAddress = myClaim.Resource as string;
                if (emailAddress == null) return false;
                if (!IsValidEmailAddress(emailAddress)) return false;
                return true;
            }
            else
            {
                return false;
            }
        }

        // This helper method performs a rudimentary check for whether
        //a given email is valid.
        private static bool IsValidEmailAddress(string emailAddress)
        {
            string[] splitEmail = emailAddress.Split('@');
            if (splitEmail.Length != 2) return false;
            if (!splitEmail[1].Contains(".")) return false;
            return true;
        }
    }
    //</snippet4>
}
