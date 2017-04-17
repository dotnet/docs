
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.
// <snippet0>
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Principal;
using System.ServiceModel.Security;
using System.Text.RegularExpressions;

namespace Microsoft.ServiceModel.Samples
{
    class MyTokenAuthenticator : UserNameSecurityTokenAuthenticator
    {
        static bool IsRogueDomain(string domain)
        {
            return false;
        }
        static bool IsEmail(string inputEmail)
        {
            
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

        bool ValidateUserNameFormat(string UserName)
        {
            if (!IsEmail(UserName))
            {
                Console.WriteLine("Not a valid email");
                return false;
            }
            string[] emailAddress = UserName.Split('@');
            string user = emailAddress[0];
            string domain = emailAddress[1];
            if (IsRogueDomain(domain))
                return false;
            return true;   
        }
        // <snippet1>
        protected override ReadOnlyCollection<IAuthorizationPolicy> ValidateUserNamePasswordCore(string userName, string password)
        {
            if (!ValidateUserNameFormat(userName))
                throw new SecurityTokenValidationException("Incorrect UserName format");

            ClaimSet claimSet = new DefaultClaimSet(ClaimSet.System, new Claim(ClaimTypes.Name, userName, Rights.PossessProperty));
            List<IIdentity> identities = new List<IIdentity>(1);
            identities.Add(new GenericIdentity(userName));
            List<IAuthorizationPolicy> policies = new List<IAuthorizationPolicy>(1);
            policies.Add(new UnconditionalPolicy(ClaimSet.System, claimSet, DateTime.MaxValue.ToUniversalTime(), identities));
            return policies.AsReadOnly();
        }
        // </snippet1>
    }

    class UnconditionalPolicy : IAuthorizationPolicy
    {
        String id = Guid.NewGuid().ToString();
        ClaimSet issuer;
        ClaimSet issuance;
        DateTime expirationTime;
        IList<IIdentity> identities;
        
        public UnconditionalPolicy(ClaimSet issuer, ClaimSet issuance, DateTime expirationTime, IList<IIdentity> identities)
        {
            if (issuer == null)
                throw new ArgumentNullException("issuer");
            if (issuance == null)
                throw new ArgumentNullException("issuance");

            this.issuer = issuer;
            this.issuance = issuance;
            this.identities = identities;
            this.expirationTime = expirationTime;
        }

        public string Id
        {
            get { return this.id; }
        }

        public ClaimSet Issuer
        {
            get { return this.issuer; }
        }

        public DateTime ExpirationTime
        {
            get { return this.expirationTime; }
        }

        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            evaluationContext.AddClaimSet(this, this.issuance);

            if (this.identities != null)
            {
                object value;
                IList<IIdentity> contextIdentities;
                if (!evaluationContext.Properties.TryGetValue("Identities", out value))
                {
                    contextIdentities = new List<IIdentity>(this.identities.Count);
                    evaluationContext.Properties.Add("Identities", contextIdentities);
                }
                else
                {
                    contextIdentities = value as IList<IIdentity>;
                }
                foreach (IIdentity identity in this.identities)
                {
                    contextIdentities.Add(identity);
                }
            }

            evaluationContext.RecordExpirationTime(this.expirationTime);
            return true;
        }
    }
}
// </snippet0>