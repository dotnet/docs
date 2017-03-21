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