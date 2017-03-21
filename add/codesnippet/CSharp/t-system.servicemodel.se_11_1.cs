    public class CreditCardTokenParameters : SecurityTokenParameters
    {
        public CreditCardTokenParameters()
        {
        }

        protected CreditCardTokenParameters(CreditCardTokenParameters other)
            : base(other)
        {
        }

        protected override SecurityTokenParameters CloneCore()
        {
            return new CreditCardTokenParameters(this);
        }

        protected override void InitializeSecurityTokenRequirement(SecurityTokenRequirement requirement)
        {
            requirement.TokenType = Constants.CreditCardTokenType;
            return;
        }

        // A credit card token has no cryptography, no windows identity, and supports only client authentication.
        protected override bool HasAsymmetricKey 
        { 
            get { return false; } 
        }
        
        protected override bool SupportsClientAuthentication 
        { 
            get { return true; } 
        }
        
        protected override bool SupportsClientWindowsIdentity 
        { 
            get { return false; } 
        }
        
        protected override bool SupportsServerAuthentication 
        { 
            get { return false; } 
        }

        protected override SecurityKeyIdentifierClause CreateKeyIdentifierClause(SecurityToken token, SecurityTokenReferenceStyle referenceStyle)
        {
            if (referenceStyle == SecurityTokenReferenceStyle.Internal)
            {
                return token.CreateKeyIdentifierClause<LocalIdKeyIdentifierClause>();
            }
            else
            {
                throw new NotSupportedException("External references are not supported for credit card tokens");
            }
        }
    }