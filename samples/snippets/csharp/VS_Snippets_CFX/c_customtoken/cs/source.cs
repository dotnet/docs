//<snippet0>
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Xml;

namespace Microsoft.ServiceModel.Samples
{
    //<snippet5>
    public class Constants
    {
        public const string CreditCardNumberClaim = "http://samples.microsoft.com/wcf/security/Extensibility/Claims/CreditCardNumber";
        public const string CreditCardTokenType = "http://samples.microsoft.com/wcf/security/Extensibility/Tokens/CreditCardToken";

        internal const string CreditCardTokenPrefix = "cct";
        internal const string CreditCardTokenNamespace = "http://samples.microsoft.com/wcf/security/Extensibility/";
        internal const string CreditCardTokenName = "CreditCardToken";
        internal const string Id = "Id";
        internal const string WsUtilityPrefix = "wsu";
        internal const string WsUtilityNamespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd";
        internal const string CreditCardNumberElementName = "CreditCardNumber";
        internal const string CreditCardIssuerElementName = "CreditCardIssuer";
        internal const string CreditCardExpirationElementName = "Expires";
    }
    //</snippet5>

    //<snippet4>
    public class CreditCardInfo
    {
        string cardNumber;
        string cardIssuer;
        DateTime expirationDate;

        public CreditCardInfo(string cardNumber, string cardIssuer, DateTime expirationDate)
        {
            this.cardNumber = cardNumber;
            this.cardIssuer = cardIssuer;
            this.expirationDate = expirationDate;
        }

        public string CardNumber
        {
            get { return this.cardNumber; }
        }

        public string CardIssuer
        {
            get { return this.cardIssuer; }
        }

        public DateTime ExpirationDate
        {
            get { return this.expirationDate; }
        }
    }
    //</snippet4>

    //<snippet1>
    class CreditCardToken : SecurityToken
    {
        CreditCardInfo cardInfo;
        DateTime effectiveTime = DateTime.UtcNow;
        string id;
        ReadOnlyCollection<SecurityKey> securityKeys;

        public CreditCardToken(CreditCardInfo cardInfo) : this(cardInfo, Guid.NewGuid().ToString()) { }

        public CreditCardToken(CreditCardInfo cardInfo, string id)
        {
            if (cardInfo == null)
            {
                throw new ArgumentNullException("cardInfo");
            }
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            this.cardInfo = cardInfo;
            this.id = id;
            // The credit card token is not capable of any cryptography.
            this.securityKeys = new ReadOnlyCollection<SecurityKey>(new List<SecurityKey>());
        }

        public CreditCardInfo CardInfo
        {
            get { return this.cardInfo; }
        }

        public override ReadOnlyCollection<SecurityKey> SecurityKeys
        {
            get { return this.securityKeys; }
        }

        public override DateTime ValidFrom
        {
            get { return this.effectiveTime; }
        }

        public override DateTime ValidTo
        {
            get { return this.cardInfo.ExpirationDate; }
        }

        public override string Id
        {
            get { return this.id; }
        }
    }
    //</snippet1>

    //<snippet2>
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
    //</snippet2>

    //<snippet3>
    public class CreditCardSecurityTokenSerializer : WSSecurityTokenSerializer
    {
        public CreditCardSecurityTokenSerializer(SecurityTokenVersion version) : base() { }

        protected override bool CanReadTokenCore(XmlReader reader)
        {
            XmlDictionaryReader localReader = XmlDictionaryReader.CreateDictionaryReader(reader);
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.IsStartElement(Constants.CreditCardTokenName, Constants.CreditCardTokenNamespace))
            {
                return true;
            }
            return base.CanReadTokenCore(reader);
        }

        protected override SecurityToken ReadTokenCore(XmlReader reader, SecurityTokenResolver tokenResolver)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.IsStartElement(Constants.CreditCardTokenName, Constants.CreditCardTokenNamespace))
            {
                string id = reader.GetAttribute(Constants.Id, Constants.WsUtilityNamespace);

                reader.ReadStartElement();

                // Read the credit card number.
                string creditCardNumber = reader.ReadElementString(Constants.CreditCardNumberElementName, Constants.CreditCardTokenNamespace);

                // Read the expiration date.
                string expirationTimeString = reader.ReadElementString(Constants.CreditCardExpirationElementName, Constants.CreditCardTokenNamespace);
                DateTime expirationTime = XmlConvert.ToDateTime(expirationTimeString, XmlDateTimeSerializationMode.Utc);

                // Read the issuer of the credit card.
                string creditCardIssuer = reader.ReadElementString(Constants.CreditCardIssuerElementName, Constants.CreditCardTokenNamespace);
                reader.ReadEndElement();

                CreditCardInfo cardInfo = new CreditCardInfo(creditCardNumber, creditCardIssuer, expirationTime);

                return new CreditCardToken(cardInfo, id);
            }
            else
            {
                return WSSecurityTokenSerializer.DefaultInstance.ReadToken(reader, tokenResolver);
            }
        }

        protected override bool CanWriteTokenCore(SecurityToken token)
        {
            if (token is CreditCardToken)
            {
                return true;
            }
            else
            {
                return base.CanWriteTokenCore(token);
            }
        }

        protected override void WriteTokenCore(XmlWriter writer, SecurityToken token)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            if (token == null)
            {
                throw new ArgumentNullException("token");
            }

            CreditCardToken c = token as CreditCardToken;
            if (c != null)
            {
                writer.WriteStartElement(Constants.CreditCardTokenPrefix, Constants.CreditCardTokenName, Constants.CreditCardTokenNamespace);
                writer.WriteAttributeString(Constants.WsUtilityPrefix, Constants.Id, Constants.WsUtilityNamespace, token.Id);
                writer.WriteElementString(Constants.CreditCardNumberElementName, Constants.CreditCardTokenNamespace, c.CardInfo.CardNumber);
                writer.WriteElementString(Constants.CreditCardExpirationElementName, Constants.CreditCardTokenNamespace, XmlConvert.ToString(c.CardInfo.ExpirationDate, XmlDateTimeSerializationMode.Utc));
                writer.WriteElementString(Constants.CreditCardIssuerElementName, Constants.CreditCardTokenNamespace, c.CardInfo.CardIssuer);
                writer.WriteEndElement();
                writer.Flush();
            }
            else
            {
                base.WriteTokenCore(writer, token);
            }
        }
    }
    //</snippet3>

    //<snippet6>
    class CreditCardTokenProvider : SecurityTokenProvider
    {
        CreditCardInfo creditCardInfo;

        public CreditCardTokenProvider(CreditCardInfo creditCardInfo)
            : base()
        {
            if (creditCardInfo == null)
            {
                throw new ArgumentNullException("creditCardInfo");
            }
            this.creditCardInfo = creditCardInfo;
        }

        protected override SecurityToken GetTokenCore(TimeSpan timeout)
        {
            SecurityToken result = new CreditCardToken(this.creditCardInfo);
            return result;
        }
    }
    //</snippet6>

    //<snippet7>
    class CreditCardTokenAuthenticator : SecurityTokenAuthenticator
    {
        string creditCardsFile;
        public CreditCardTokenAuthenticator(string creditCardsFile)
        {
            this.creditCardsFile = creditCardsFile;
        }

        protected override bool CanValidateTokenCore(SecurityToken token)
        {
            return (token is CreditCardToken);
        }

        protected override ReadOnlyCollection<IAuthorizationPolicy> ValidateTokenCore(SecurityToken token)
        {
            CreditCardToken creditCardToken = token as CreditCardToken;

            if (creditCardToken.CardInfo.ExpirationDate < DateTime.UtcNow)
            {
                throw new SecurityTokenValidationException("The credit card has expired");
            }
            if (!IsCardNumberAndExpirationValid(creditCardToken.CardInfo))
            {
                throw new SecurityTokenValidationException("Unknown or invalid credit card");
            }

            // The credit card token has only 1 claim: the card number. The issuer for the claim is the
            // credit card issuer.
            DefaultClaimSet cardIssuerClaimSet = new DefaultClaimSet(new Claim(ClaimTypes.Name, creditCardToken.CardInfo.CardIssuer, Rights.PossessProperty));
            DefaultClaimSet cardClaimSet = new DefaultClaimSet(cardIssuerClaimSet, new Claim(Constants.CreditCardNumberClaim, creditCardToken.CardInfo.CardNumber, Rights.PossessProperty));
            List<IAuthorizationPolicy> policies = new List<IAuthorizationPolicy>(1);
            policies.Add(new CreditCardTokenAuthorizationPolicy(cardClaimSet));
            return policies.AsReadOnly();
        }

        // This helper method checks whether a given credit card entry is present in the user database.
        private bool IsCardNumberAndExpirationValid(CreditCardInfo cardInfo)
        {
            try
            {
                using (StreamReader myStreamReader = new StreamReader(this.creditCardsFile))
                {
                    string line = "";
                    while ((line = myStreamReader.ReadLine()) != null)
                    {
                        string[] splitEntry = line.Split('#');
                        if (splitEntry[0] == cardInfo.CardNumber)
                        {
                            string expirationDateString = splitEntry[1].Trim();
                            DateTime expirationDateOnFile = DateTime.Parse(expirationDateString, System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.AdjustToUniversal);
                            if (cardInfo.ExpirationDate == expirationDateOnFile)
                            {
                                string issuer = splitEntry[2];
                                return issuer.Equals(cardInfo.CardIssuer, StringComparison.InvariantCultureIgnoreCase);
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception("BookStoreService: Error while retrieving credit card information from User DB " + e.ToString());
            }
        }
    }
    //</snippet7>

    //<snippet12>
    public class CreditCardTokenAuthorizationPolicy : IAuthorizationPolicy
    {
        string id;
        ClaimSet issuer;
        IEnumerable<ClaimSet> issuedClaimSets;

        public CreditCardTokenAuthorizationPolicy(ClaimSet issuedClaims)
        {
            if (issuedClaims == null)
                throw new ArgumentNullException("issuedClaims");
            this.issuer = issuedClaims.Issuer;
            this.issuedClaimSets = new ClaimSet[] { issuedClaims };
            this.id = Guid.NewGuid().ToString();
        }

        public ClaimSet Issuer { get { return this.issuer; } }

        public string Id { get { return this.id; } }

        public bool Evaluate(EvaluationContext context, ref object state)
        {
            foreach (ClaimSet issuance in this.issuedClaimSets)
            {
                context.AddClaimSet(this, issuance);
            }

            return true;
        }
    }
    //</snippet12>

    //<snippet8>
    public class CreditCardClientCredentialsSecurityTokenManager : ClientCredentialsSecurityTokenManager
    {
        CreditCardClientCredentials creditCardClientCredentials;

        public CreditCardClientCredentialsSecurityTokenManager(CreditCardClientCredentials creditCardClientCredentials)
            : base(creditCardClientCredentials)
        {
            this.creditCardClientCredentials = creditCardClientCredentials;
        }

        public override SecurityTokenProvider CreateSecurityTokenProvider(SecurityTokenRequirement tokenRequirement)
        {
            if (tokenRequirement.TokenType == Constants.CreditCardTokenType)
            {
                // Handle this token for Custom.
                return new CreditCardTokenProvider(this.creditCardClientCredentials.CreditCardInfo);
            }
            else if (tokenRequirement is InitiatorServiceModelSecurityTokenRequirement)
            {
                // Return server certificate.
                if (tokenRequirement.TokenType == SecurityTokenTypes.X509Certificate)
                {
                    return new X509SecurityTokenProvider(creditCardClientCredentials.ServiceCertificate.DefaultCertificate);
                }
            }
            return base.CreateSecurityTokenProvider(tokenRequirement);
        }

        public override SecurityTokenSerializer CreateSecurityTokenSerializer(SecurityTokenVersion version)
        {
            return new CreditCardSecurityTokenSerializer(version);
        }
    }
    //</snippet8>

    //<snippet9>
    public class CreditCardServiceCredentialsSecurityTokenManager : ServiceCredentialsSecurityTokenManager
    {
        CreditCardServiceCredentials creditCardServiceCredentials;

        public CreditCardServiceCredentialsSecurityTokenManager(CreditCardServiceCredentials creditCardServiceCredentials)
            : base(creditCardServiceCredentials)
        {
            this.creditCardServiceCredentials = creditCardServiceCredentials;
        }

        public override SecurityTokenAuthenticator CreateSecurityTokenAuthenticator(SecurityTokenRequirement tokenRequirement, out SecurityTokenResolver outOfBandTokenResolver)
        {
            if (tokenRequirement.TokenType == Constants.CreditCardTokenType)
            {
                outOfBandTokenResolver = null;
                return new CreditCardTokenAuthenticator(creditCardServiceCredentials.CreditCardDataFile);
            }
            return base.CreateSecurityTokenAuthenticator(tokenRequirement, out outOfBandTokenResolver);
        }

        public override SecurityTokenSerializer CreateSecurityTokenSerializer(SecurityTokenVersion version)
        {
            return new CreditCardSecurityTokenSerializer(version);
        }
    }
    //</snippet9>

    //<snippet10>
    public class CreditCardClientCredentials : ClientCredentials
    {
        CreditCardInfo creditCardInfo;

        public CreditCardClientCredentials(CreditCardInfo creditCardInfo)
            : base()
        {
            if (creditCardInfo == null)
            {
                throw new ArgumentNullException("creditCardInfo");
            }

            this.creditCardInfo = creditCardInfo;
        }

        public CreditCardInfo CreditCardInfo
        {
            get { return this.creditCardInfo; }
        }

        protected override ClientCredentials CloneCore()
        {
            return new CreditCardClientCredentials(this.creditCardInfo);
        }

        public override SecurityTokenManager CreateSecurityTokenManager()
        {
            return new CreditCardClientCredentialsSecurityTokenManager(this);
        }
    }
    //</snippet10>

    //<snippet11>
    public class CreditCardServiceCredentials : ServiceCredentials
    {
        string creditCardFile;

        public CreditCardServiceCredentials(string creditCardFile)
            : base()
        {
            if (creditCardFile == null)
            {
                throw new ArgumentNullException("creditCardFile");
            }

            this.creditCardFile = creditCardFile;
        }

        public string CreditCardDataFile
        {
            get { return this.creditCardFile; }
        }

        protected override ServiceCredentials CloneCore()
        {
            return new CreditCardServiceCredentials(this.creditCardFile);
        }

        public override SecurityTokenManager CreateSecurityTokenManager()
        {
            return new CreditCardServiceCredentialsSecurityTokenManager(this);
        }
    }
    //</snippet11>

    //<snippet13>
    public static class BindingHelper
    {
        public static Binding CreateCreditCardBinding()
        {
            HttpTransportBindingElement httpTransport = new HttpTransportBindingElement();

            // The message security binding element is configured to require a credit card
            // token that is encrypted with the service's certificate.
            SymmetricSecurityBindingElement messageSecurity = new SymmetricSecurityBindingElement();
            messageSecurity.EndpointSupportingTokenParameters.SignedEncrypted.Add(new CreditCardTokenParameters());
            X509SecurityTokenParameters x509ProtectionParameters = new X509SecurityTokenParameters();
            x509ProtectionParameters.InclusionMode = SecurityTokenInclusionMode.Never;
            messageSecurity.ProtectionTokenParameters = x509ProtectionParameters;
            return new CustomBinding(messageSecurity, httpTransport);
        }
    }
    //</snippet13>
}
//</snippet0>
