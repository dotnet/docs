namespace ServerInitiatedNego
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.DirectoryServices.ActiveDirectory;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Net.Security;
    using System.Security.Authentication;
    using System.IdentityModel.Claims;
    using System.IdentityModel.Policy;
    using System.IdentityModel.Selectors;
    using System.IdentityModel.Tokens;
    using System.Security.Principal;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Security; 
    using System.ServiceModel.Security.Tokens;

    public class IdentitySamples
    {
        static void Main(string[] args)
        {
        }
        internal const string UpgradeString = "application/reverse-negotiate";

        IdentityVerifier identityVerifier = IdentityVerifier.CreateDefault();


       // <snippet1>
       static EndpointIdentity CreateIdentity()
        {
            WindowsIdentity self = WindowsIdentity.GetCurrent();
            SecurityIdentifier sid = self.User;

            EndpointIdentity identity = null;

            if (sid.IsWellKnown(WellKnownSidType.LocalSystemSid) ||
                sid.IsWellKnown(WellKnownSidType.NetworkServiceSid) ||
                sid.IsWellKnown(WellKnownSidType.LocalServiceSid))
            {
                identity = EndpointIdentity.CreateSpnIdentity(
                    String.Format(CultureInfo.InvariantCulture, "host/{0}", GetMachineName()));
            }
            else
            {
                // Need an UPN string here
                string domain = GetPrimaryDomain();
                if (domain != null)
                {
                    string[] split = self.Name.Split('\\');
                    if (split.Length == 2)
                    {
                        identity = EndpointIdentity.CreateUpnIdentity(split[1] + "@" + domain);
                    }
                }
            }

            return identity;
        }
        // </snippet1>

        // <snippet2>
        private SpnEndpointIdentity CreateIdentityFromClaimSet(ClaimSet claims)
        {
            foreach (Claim claim in claims.FindClaims(null, Rights.Identity))
            {
                return new SpnEndpointIdentity(claim);
            }
            return null;
        }
        // </snippet2>

        // <snippet3>
        static EndpointIdentity CreateSpnIdentity()
        {
            WindowsIdentity self = WindowsIdentity.GetCurrent();
            SecurityIdentifier sid = self.User;

            SpnEndpointIdentity identity = null;

            identity = new SpnEndpointIdentity(String.Format(CultureInfo.InvariantCulture, "host/{0}", GetMachineName()));

            return identity;
        }
        static string GetMachineName()
        {
            return Dns.GetHostEntry(string.Empty).HostName;
        }
        // </snippet3>

        static string GetPrimaryDomain()
        {
            string currentDomain = null;
            try
            {
                currentDomain = Domain.GetCurrentDomain().Name;
            }
            catch (ActiveDirectoryObjectNotFoundException)
            {
                // ignore
            }
            catch (ActiveDirectoryOperationException)
            {
                // ignore
            }
            catch (ActiveDirectoryServerDownException)
            {
                // ignore
            }
            return currentDomain;
        }
    }


    class SimpleAuthorizationPolicy : IAuthorizationPolicy
    {
        string id = Guid.NewGuid().ToString();
        Claim primaryIdentity;

        public SimpleAuthorizationPolicy(Claim primaryIdentity)
        {
            this.primaryIdentity = primaryIdentity;
        }

        public string Id
        {
            get
            {
                return this.id;
            }
        }

        public ClaimSet Issuer
        {
            get
            {
                return ClaimSet.System;
            }
        }

        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            evaluationContext.AddClaimSet(this, new DefaultClaimSet(ClaimSet.System, this.primaryIdentity));
            if (!evaluationContext.Properties.ContainsKey("PrimaryIdentity"))
            {
                evaluationContext.Properties.Add("PrimaryIdentity", this.primaryIdentity);
            }
            return true;
        }
    }
}
