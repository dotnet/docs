        protected override Collection<SamlAttribute> GetIssuedClaims(RequestSecurityToken RST)
        {
            EndpointAddress rstAppliesTo = RST.AppliesTo;

            if (rstAppliesTo == null)
            {
                throw new InvalidOperationException("No AppliesTo EndpointAddress in RequestSecurityToken");
            }

            string bookName = rstAppliesTo.Headers.FindHeader(Constants.BookNameHeaderName, Constants.BookNameHeaderNamespace).GetValue<string>();
            if (string.IsNullOrEmpty(bookName))
                throw new FaultException("The book name was not specified in the RequestSecurityToken");

            EnsurePurchaseLimitSufficient(bookName);

            Collection<SamlAttribute> samlAttributes = new Collection<SamlAttribute>();

            foreach (ClaimSet claimSet in ServiceSecurityContext.Current.AuthorizationContext.ClaimSets)
            {
                // Copy Name claims from the incoming credentials into the set of claims to be issued.
                IEnumerable<Claim> nameClaims = claimSet.FindClaims(ClaimTypes.Name, Rights.PossessProperty);
                if (nameClaims != null)
                {
                    foreach (Claim nameClaim in nameClaims)
                    {
                        samlAttributes.Add(new SamlAttribute(nameClaim));
                    }
                }
            }
            // Add a purchase authorized claim.
            samlAttributes.Add(new SamlAttribute(new Claim(Constants.PurchaseAuthorizedClaim, bookName, Rights.PossessProperty)));
            return samlAttributes;
        }