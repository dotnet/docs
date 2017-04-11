
//  <snippet1>

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.IdentityModel.Claims; 
using System.IdentityModel.Policy; 
using System.IdentityModel.Tokens; 
using System.IdentityModel.Selectors;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples.SupportingTokens
{
    [ServiceContract]
    public interface IEchoService : IDisposable
    {
        [OperationContract]
        string Echo();
    }
    // Service class that implements the service contract.
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class EchoService : IEchoService
    {
        public string Echo()
        {
            string userName;
            string certificateSubjectName;
            GetCallerIdentities(OperationContext.Current.ServiceSecurityContext, out userName, out certificateSubjectName);
            return String.Format("Hello {0}, {1}", userName, certificateSubjectName);
        }

        public void Dispose()
        {
        }


        bool TryGetClaimValue<TClaimResource>(ClaimSet claimSet, string claimType, out TClaimResource resourceValue)
            where TClaimResource : class
        {
            resourceValue = default(TClaimResource);
            IEnumerable<Claim> matchingClaims = claimSet.FindClaims(claimType, Rights.PossessProperty);
            if (matchingClaims == null)
                return false;
            IEnumerator<Claim> enumerator = matchingClaims.GetEnumerator();
            if (enumerator.MoveNext())
            {
                resourceValue = (enumerator.Current.Resource == null) ? null : (enumerator.Current.Resource as TClaimResource);
                return true;
            }
            else
            {
                return false;
            }
        }

        // Returns the username and certificate subject name provided by the client.
        void GetCallerIdentities(ServiceSecurityContext callerSecurityContext, out string userName, out string certificateSubjectName)
        {
            userName = null;
            certificateSubjectName = null;

            // Look in all the claimsets in the authorization context.
            foreach (ClaimSet claimSet in callerSecurityContext.AuthorizationContext.ClaimSets)
            {
                // Try to find a Upn claim. This has been generated from the windows username.
                string tmpName;
                if (TryGetClaimValue<string>(claimSet, ClaimTypes.Upn, out tmpName))
                {
                    userName = tmpName;
                }
                else
                {
                    // Try to find an X500DisinguishedName claim. This has been generated from the client certificate.
                    X500DistinguishedName tmpDistinguishedName;
                    if (TryGetClaimValue<X500DistinguishedName>(claimSet, ClaimTypes.X500DistinguishedName, out tmpDistinguishedName))
                    {
                        certificateSubjectName = tmpDistinguishedName.Name;
                    }
                }
            }
        }
    }
}
// </snippet1>