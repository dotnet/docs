//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
using System;

using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.IdentityModel.Tokens;

using System.Configuration;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Security.Permissions;
using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

[assembly: SecurityPermission(
   SecurityAction.RequestMinimum, Execution = true)]
namespace Microsoft.ServiceModel.Samples.Federation
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class BookStoreSTS : SecurityTokenService
    {
        /// <summary>
        /// Sets up the BookStoreSTS by loading relevant application settings.
        /// </summary>
        public BookStoreSTS()
            : base(ServiceConstants.SecurityTokenServiceName,
                   FederationUtilities.GetX509TokenFromCert(ServiceConstants.CertStoreName, ServiceConstants.CertStoreLocation, ServiceConstants.CertDistinguishedName),
                   FederationUtilities.GetX509TokenFromCert(ServiceConstants.CertStoreName, ServiceConstants.CertStoreLocation, ServiceConstants.TargetDistinguishedName))
        {
        }

        /// <summary>
        /// Overrides the GetIssuedClaims from the SecurityTokenService base class.
        /// Checks if the caller can purchase the book specified in the RST and if so
        /// issues a purchase authorized claim.
        /// </summary>
        //<snippet1>
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
        //</snippet1>
        public static void Main() {}

        #region Helper Methods
        /// <summary>
        /// Wrapper for the Application level check performed at the BookStoreSTS for 
        /// the existence of required purchase limit.
        /// </summary>
        private static void EnsurePurchaseLimitSufficient(string bookName)
        {
            if (!CheckIfPurchaseLimitMet(bookName))
            {
                throw new FaultException(String.Format("Purchase limit not sufficient to purchase '{0}'", bookName));
            }
        }

        /// <summary>
        /// Helper method to get the book price from the Books Database.
        /// </summary>
        /// <param name="bookID">ID of the book that is intended for purchase.</param>
        /// <returns>Price of the book with the given ID.</returns>
        private static double GetBookPrice(string bookName)
        {
            using (StreamReader myStreamReader = new StreamReader(ServiceConstants.BookDB))
            {
                string line = "";
                while ((line = myStreamReader.ReadLine()) != null)
                {
                    string[] splitEntry = line.Split('#');
                    if (splitEntry[1].Trim().Equals(bookName.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        return Double.Parse(splitEntry[3]);
                    }
                }
                // invalid bookName - throw
                throw new FaultException("Invalid Book Name " + bookName);
            }
        }

        /// <summary>
        /// Application level check for claims at the BookStoreSTS.
        /// </summary>
        /// <param name="bookID">ID of the book that is intended for purchase<./param>
        /// <returns>True on success. False on failure.</returns>
        private static bool CheckIfPurchaseLimitMet(string bookID)
        {
            // Extract the AuthorizationContext from the ServiceSecurityContext.
            AuthorizationContext authContext = OperationContext.Current.ServiceSecurityContext.AuthorizationContext;

            // If there are no Claims in the AuthorizationContext, return false.
            // The issued token used to authenticate should contain claims. 
            if (authContext.ClaimSets == null)
                return false;

            // If there is more than two ClaimSets in the AuthorizationContext, return false.
            // The issued token used to authenticate should only contain two sets of claims.
            if (authContext.ClaimSets.Count != 2)
                return false;

            List<ClaimSet> claimsets = new List<ClaimSet>(authContext.ClaimSets);
            ClaimSet myClaimSet = claimsets.Find((Predicate<ClaimSet>)delegate(ClaimSet target)
            {
                X509CertificateClaimSet certClaimSet = target.Issuer as X509CertificateClaimSet;
                return certClaimSet != null && certClaimSet.X509Certificate.Subject == "CN=HomeRealmSTS.com";
            });

            // If the ClaimSet was NOT issued by the HomeRealmSTS, then return false.
            // The BookStoreSTS only accepts requests where the client authenticated using a token
            // issued by the HomeRealmSTS.
            if (!IssuedByHomeRealmSTS(myClaimSet))
                return false;

            // Find all the PurchaseLimit claims.
            IEnumerable<Claim> purchaseLimitClaims = myClaimSet.FindClaims(Constants.PurchaseLimitClaim, Rights.PossessProperty);

            // If there are no PurchaseLimit claims, return false.
            // The HomeRealmSTS issues tokens that contain PurchaseLimit claims for all authorized requests.
            if (purchaseLimitClaims == null)
                return false;

            // Get the price of the book being purchased.
            double bookPrice = GetBookPrice(bookID);

            // Iterate through the PurchaseLimit claims and verify that the Resource value is 
            // greater than or equal to the price of the book being purchased.
            foreach (Claim c in purchaseLimitClaims)
            {
                double purchaseLimit = Double.Parse(c.Resource.ToString());
                if (purchaseLimit >= bookPrice)
                    return true;
            }

            // If no PurchaseLimit claim had a resource value that was greater than or equal
            // to the price of the book being purchased, return false.
            return false;
        }


        /// <summary>
        /// Helper function to check if SAML Token was issued by HomeRealmSTS.
        /// </summary>
        /// <returns>True on success. False on failure.</returns>
        private static bool IssuedByHomeRealmSTS(ClaimSet myClaimSet)
        {
            // Extract the issuer ClaimSet.
            ClaimSet issuerClaimSet = myClaimSet.Issuer;

            // If the Issuer is null, return false.
            if (issuerClaimSet == null)
                return false;

            // Find all the Thumbprint claims in the issuer ClaimSet.
            IEnumerable<Claim> issuerClaims = issuerClaimSet.FindClaims(ClaimTypes.Thumbprint, null);

            // If there are no Thumbprint claims, return false.
            if (issuerClaims == null)
                return false;

            // Get the enumerator for the set of Thumbprint claims...                        
            IEnumerator<Claim> issuerClaimsEnum = issuerClaims.GetEnumerator();

            // ...and set issuerClaim to the first such Claim.
            Claim issuerClaim = null;
            if (issuerClaimsEnum.MoveNext())
                issuerClaim = issuerClaimsEnum.Current;

            // If there was no Thumbprint claim, return false.
            if (issuerClaim == null)
                return false;

            // If, despite the above checks, the returned claim is not a Thumbprint claim, return false
            if (issuerClaim.ClaimType != ClaimTypes.Thumbprint)
                return false;

            // If the returned claim does not contain a Resource, return false.
            if (issuerClaim.Resource == null)
                return false;

            // Extract the thumbprint data from the claim.
            byte[] issuerThumbprint = (byte[])issuerClaim.Resource;

            // Extract the thumbprint for the HomeRealmSTS.com certificate.
            byte[] certThumbprint = FederationUtilities.GetCertificateThumbprint(ServiceConstants.CertStoreName,
                                                                     ServiceConstants.CertStoreLocation,
                                                                     ServiceConstants.IssuerDistinguishedName);

            // If the lengths of the two thumbprints are different, return false.
            if (issuerThumbprint.Length != certThumbprint.Length)
                return false;

            // Check the individual bytes of the two thumbprints for equality...
            for (int i = 0; i < issuerThumbprint.Length; i++)
            {
                //... if any byte in the thumbprint from the claim does NOT match the corresponding
                // byte from the thumbprint in the BookStoreSTS.com certificate, return false.
                if (issuerThumbprint[i] != certThumbprint[i])
                    return false;
            }

            // If we get through all the preceding checks, return true (ClaimSet was issued by HomeRealmSTS.com).
            return true;
        }
        #endregion
    }
    
    /// <summary>
    /// Abstract base class for STS implementations.
    /// </summary>
	public abstract class SecurityTokenService : ISecurityTokenService
	{
		string stsName; // The name of the STS. Used to populate saml:Assertion/@Issuer
        SecurityToken issuerToken; // The SecurityToken used to sign issued tokens
        SecurityToken proofKeyEncryptionToken; // The SecurityToken used to encrypt the proof key in the issued token.

        /// <summary>
        /// constructor 
        /// </summary>
        /// <param name="stsName">The name of the STS. Used to populate saml:Assertion/@Issuer.</param>
        /// <param name="token">The X509SecurityToken that the STS uses to sign SAML assertions.</param>
        /// <param name="targetServiceName">The X509SecurityToken that is used to encrypt the proof key in the SAML token.</param>
        protected SecurityTokenService(string stsName, X509SecurityToken issuerToken, X509SecurityToken encryptionToken)
        {
            this.stsName = stsName;
            this.issuerToken = issuerToken;
            this.proofKeyEncryptionToken = encryptionToken;
        }

        /// <summary>
        /// The name of the STS.
        /// </summary>
        protected string SecurityTokenServiceName
        {
            get { return this.stsName; }
        }


        /// <summary>
        /// The SecurityToken used to sign tokens the STS issues.
        /// </summary>
        protected SecurityToken IssuerToken
        {
            get { return this.issuerToken; }
        }

        /// <summary>
        /// The SecurityToken used to encrypt the proof key in the issued token.
        /// </summary>
        protected SecurityToken ProofKeyEncryptionToken
        {
            get { return this.proofKeyEncryptionToken; }
        }

		#region Abstract methods
        

        /// <summary>
        /// Abstract method for setting up claims in the SAML Token issued by the STS
        /// Should be overriden by STS implementations that derive from this base class
        /// to set up appropriate claims.
        /// </summary>
        protected abstract Collection<SamlAttribute> GetIssuedClaims(RequestSecurityToken requestSecurityToken);

        #endregion

        #region Helper Methods
        /// <summary>
        /// Validate action header and discard messages with inappropriate headers.
        /// </summary>
        protected static void EnsureRequestSecurityTokenAction(Message message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            if (message.Headers.Action != Constants.Trust.Actions.Issue)
                throw new InvalidOperationException(String.Format("Bad or Unsupported Action: {0}", message.Headers.Action));
        }

        /// <summary>
        /// Helper method to create proof token. Creates BinarySecretSecuryToken 
        /// with the requested number of bits of random key material.
        /// </summary>
        /// <param name="keySize">keySize</param>
        /// <returns>Proof Token</returns>
        protected static BinarySecretSecurityToken CreateProofToken(int keySize)
        {
            // Create an array to store the key bytes.
            byte[] key = new byte[keySize/8];
            // Create some random bytes.
            RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
            random.GetNonZeroBytes(key);
            // Create a BinarySecretSecurityToken from the random bytes and return it.
            return new BinarySecretSecurityToken(key);
        }

        /// <summary>
        /// Helper method to set up the RSTR.
        /// </summary>
        /// <param name="rst">RequestSecurityToken</param>
        /// <param name="keySize">keySize</param>
        /// <param name="proofToken">proofToken</param>
        /// <param name="samlToken">The SAML Token to be issued</param>
        /// <returns>RequestSecurityTokenResponse</returns>
        protected static RequestSecurityTokenBase GetRequestSecurityTokenResponse(RequestSecurityTokenBase requestSecurityToken,
                                                                                      int keySize, 
                                                                                      SecurityToken proofToken,
                                                                                      SecurityToken samlToken,
                                                                                      byte[] senderEntropy,
                                                                                      byte[] stsEntropy)
        {
            // Create an uninitialized RequestSecurityTokenResponse object and set the various properties.
            RequestSecurityTokenResponse rstr = new RequestSecurityTokenResponse();
            rstr.TokenType = Constants.SamlTokenTypeUri;
            rstr.RequestedSecurityToken = samlToken;
            rstr.RequestedUnattachedReference = samlToken.CreateKeyIdentifierClause<SamlAssertionKeyIdentifierClause>();
            rstr.RequestedAttachedReference = samlToken.CreateKeyIdentifierClause<SamlAssertionKeyIdentifierClause>();
            rstr.Context = requestSecurityToken.Context;
            rstr.KeySize = keySize;

            // If the sender provided entropy then combined entropy is used, so set the IssuerEntropy.
            if (senderEntropy != null)
            {
                rstr.IssuerEntropy = new BinarySecretSecurityToken(stsEntropy);
                rstr.ComputeKey = true;
            }
            else // Issuer entropy only...
            {
                rstr.RequestedProofToken = proofToken;
            }
            
            return rstr;
        }
        #endregion

        /// <summary>
        /// Virtual method for ProcessRequestSecurityToken.
        /// Should be overriden by STS implementations that derive from this base class.
        /// </summary>
        public virtual Message ProcessRequestSecurityToken(Message message)
        {
            // Check for appropriate action header.
            EnsureRequestSecurityTokenAction(message);

            // Extract the MessageID from the request message.
            UniqueId requestMessageID = message.Headers.MessageId;
            if (requestMessageID == null)
                throw new InvalidOperationException("The request message does not have a message ID.");

            // Get the RST from the message.
            RequestSecurityToken rst = RequestSecurityToken.CreateFrom(message.GetReaderAtBodyContents());

            // Set up the claims to be issued.
            Collection<SamlAttribute> samlAttributes = GetIssuedClaims(rst);

            // Get the key size, default to 192.
            int keySize = (rst.KeySize != 0) ? rst.KeySize : 192;

            // Create proof token.
            // Get requestor entropy, if any.
            byte[] senderEntropy = null;
            SecurityToken entropyToken = rst.RequestorEntropy;
            if (entropyToken != null)
            {
                senderEntropy = ((BinarySecretSecurityToken)entropyToken).GetKeyBytes();
            }

            byte[] key = null;
            byte[] stsEntropy = null;

            // If sender provided entropy, then use combined entropy.
            if (senderEntropy != null)
            {
                // Create an array to store the entropy bytes.
                stsEntropy = new byte[keySize / 8];
                // Create some random bytes.
                RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
                random.GetNonZeroBytes(stsEntropy);
                // Compute the combined key.
                key = RequestSecurityTokenResponse.ComputeCombinedKey(senderEntropy, stsEntropy, keySize);
            }
            else // Issuer entropy only...
            {
                // Create an array to store the entropy bytes.
                key = new byte[keySize / 8];
                // Create some random bytes.
                RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
                random.GetNonZeroBytes(key);
            }

            // Create a BinarySecretSecurityToken to be the proof token, based on the key material
            // in the key. The key is the combined key in the combined entropy case, or the issuer entropy
            // otherwise.
            BinarySecretSecurityToken proofToken = new BinarySecretSecurityToken(key);

            // Create a SAML token, valid for around 10 hours.
            SamlSecurityToken samlToken = SamlTokenCreator.CreateSamlToken(this.stsName,
                                                                           proofToken,
                                                                           this.IssuerToken,
                                                                           this.ProofKeyEncryptionToken,
                                                                           new SamlConditions(DateTime.UtcNow - TimeSpan.FromMinutes(5), DateTime.UtcNow + TimeSpan.FromHours(10)),
                                                                           samlAttributes);

            // Set up RSTR.
            RequestSecurityTokenBase rstr = GetRequestSecurityTokenResponse(rst, keySize, proofToken, samlToken, senderEntropy, stsEntropy);
            
            // Create a message from the RSTR.
            Message rstrMessage = Message.CreateMessage(message.Version, Constants.Trust.Actions.IssueReply, rstr);
            
            // Set RelatesTo of the response message to MessageID of the request message.
            rstrMessage.Headers.RelatesTo = requestMessageID;

            // Return the created message.
            return rstrMessage;
        }
    }
    [ServiceContract(Name = "SecurityTokenService", Namespace = "http://tempuri.org")]
    public interface ISecurityTokenService
    {
        [OperationContract(Action = Constants.Trust.Actions.Issue,
                           ReplyAction = Constants.Trust.Actions.IssueReply)]
        Message ProcessRequestSecurityToken(Message message);
    }
    /// <summary>
    /// Abstract base class that contains properties that are shared by RST and RSTR classes.
    /// </summary>
    [ComVisible(false)]
    public abstract class RequestSecurityTokenBase : BodyWriter
    {
        // Private members.
        private string m_context;
        private string m_tokenType;
        private int m_keySize;
        private EndpointAddress m_appliesTo;

        // Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        protected RequestSecurityTokenBase()
            : this(String.Empty, String.Empty, 0, null)
        {
        }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        /// <param name="context">The value of the wst:RequestSecurityToken/@Context attribute in the request message, if any.</param>
        /// <param name="tokenType">The content of the wst:RequestSecurityToken/wst:TokenType element in the request message, if any.</param>
        /// <param name="keySize">The content of the wst:RequestSecurityToken/wst:KeySize element in the request message, if any.</param>
        /// <param name="appliesTo">An EndpointReference that corresponds to the content of the wst:RequestSecurityToken/wsp:AppliesTo element in the request message, if any.</param>
        protected RequestSecurityTokenBase(string context, string tokenType, int keySize, EndpointAddress appliesTo)
            : base(true)
        {
            this.m_context = context;
            this.m_tokenType = tokenType;
            this.m_keySize = keySize;
            this.m_appliesTo = appliesTo;
        }

        // public properties

        /// <summary>
        /// Context for the RST/RSTR exchange. 
        /// The value of the wst:RequestSecurityToken/@Context attribute from RequestSecurityToken messages.
        /// The value of the wst:RequestSecurityTokenResponse/@Context attribute from RequestSecurityTokenResponse messages.        
        /// </summary>
        public string Context
        {
            get { return m_context; }
            set { m_context = value; }
        }

        /// <summary>
        /// The type of token requested or returned.
        /// The value of the wst:RequestSecurityToken/wst:TokenType element from RequestSecurityToken messages.
        /// The value of the wst:RequestSecurityTokenResponse/wst:TokenType element from RequestSecurityTokenResponse messages.       
        /// </summary>
        public string TokenType
        {
            get { return m_tokenType; }
            set { m_tokenType = value; }
        }


        /// <summary>
        /// The size of the requested proof key.
        /// The value of the wst:RequestSecurityToken/wst:KeySize element from RequestSecurityToken messages.
        /// The value of the wst:RequestSecurityTokenResponse/wst:KeySize element from RequestSecurityTokenResponse messages.       
        /// </summary>
        public int KeySize
        {
            get { return m_keySize; }
            set { m_keySize = value; }
        }

        /// <summary>
        /// The EndpointAddress a token is being requested or returned for. 
        /// The content of the wst:RequestSecurityToken/wsp:AppliesTo element from RequestSecurityToken messages.
        /// The content of the wst:RequestSecurityTokenResponse/wsp:AppliesTo element from RequestSecurityTokenResponse messages.       
        /// </summary>public int KeySize
        public EndpointAddress AppliesTo
        {
            get { return m_appliesTo; }
            set { m_appliesTo = value; }
        }
    }
    /// <summary>
    /// A class that represents a RequestSecurityToken message according to February 2005 WS-Trust.
    /// </summary>
    [ComVisible(false)]
    public class RequestSecurityToken : RequestSecurityTokenBase
    {
        // Private members.
        private SecurityToken requestorEntropy;

        // Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public RequestSecurityToken()
            :
            this(String.Empty, String.Empty, 0, null, null)
        {
        }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        /// <param name="context">The value of the wst:RequestSecurityToken/@Context attribute.</param>
        /// <param name="tokenType">The content of the wst:RequestSecurityToken/wst:TokenType element.</param>
        /// <param name="keySize">The content of the wst:RequestSecurityToken/wst:KeySize element.</param>
        /// <param name="appliesTo">An EndpointReference that corresponds to the content of the wst:RequestSecurityToken/wsp:AppliesTo element.</param>
        /// <param name="entropy">A SecurityToken that represents entropy provided by the requestor in the wst:RequestSecurityToken/wst:Entropy element.</param>        
        public RequestSecurityToken(string context,
                                    string tokenType,
                                    int keySize,
                                    EndpointAddress appliesTo,
                                    SecurityToken entropy)
            :
            base(context, tokenType, keySize, appliesTo) // Pass first 4 params to base class
        {
            this.requestorEntropy = entropy;
        }

        // public properties

        /// <summary>
        /// The SecurityToken that represents entropy provided by the requestor.
        /// Null if the requestor did not provide entropy.
        /// </summary>
        public SecurityToken RequestorEntropy
        {
            get { return requestorEntropy; }
            set { requestorEntropy = value; }
        }

        // Static methods

        /// <summary>
        /// Reads a wst:RequestSecurityToken element, its attributes and children and 
        /// creates a RequestSecurityToken instance with the appropriate values.
        /// </summary>
        /// <param name="xr">An XmlReader positioned on wst:RequestSecurityToken.</param>
        /// <returns>A RequestSecurityToken instance, initialized with the data read from the XmlReader.</returns>
        public static RequestSecurityToken CreateFrom(XmlReader xr)
        {
            return ProcessRequestSecurityTokenElement(xr);
        }

        // Methods of BodyWriter
        /// <summary>
        /// Writes out an XML representation of the instance.
        /// Provided here for completeness. Not actually called by this sample.
        /// </summary>
        /// <param name="writer">The writer to be used to write out the XML content.</param>
        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            // Write out the wst:RequestSecurityToken start tag.
            writer.WriteStartElement(Constants.Trust.Elements.RequestSecurityToken, Constants.Trust.NamespaceUri);

            // If it is a non-null, non-empty tokenType...
            if (this.TokenType != null && this.TokenType.Length > 0)
            {
                // Write out the wst:TokenType start tag.
                writer.WriteStartElement(Constants.Trust.Elements.TokenType, Constants.Trust.NamespaceUri);
                // Write out the tokenType string.
                writer.WriteString(this.TokenType);
                writer.WriteEndElement(); // wst:TokenType
            }

            // If it is a non-null appliesTo...
            if (this.AppliesTo != null)
            {
                // Write out the wsp:AppliesTo start tag.
                writer.WriteStartElement(Constants.Policy.Elements.AppliesTo, Constants.Policy.NamespaceUri);
                // Write the appliesTo in WS-Addressing 1.0 format.
                this.AppliesTo.WriteTo(AddressingVersion.WSAddressing10, writer);
                writer.WriteEndElement(); // wsp:AppliesTo
            }

            // If the requestor provided entropy...
            if (this.requestorEntropy != null)
            {
                // Write out the wst:Entropy start tag.
                writer.WriteStartElement(Constants.Trust.Elements.Entropy, Constants.Trust.NamespaceUri);

                // Make the requesterEntropy SecurityToken into a BinaerySecretSecurityToken
                BinarySecretSecurityToken bsst = this.requestorEntropy as BinarySecretSecurityToken;

                // If requesterEntropy is a BinarySecretSecurityToken...
                if (bsst != null)
                {
                    // Write out the wst:BinarySecret start tag.
                    writer.WriteStartElement(Constants.Trust.Elements.BinarySecret, Constants.Trust.NamespaceUri);

                    // Get the entropy bytes.
                    byte[] key = bsst.GetKeyBytes();

                    // Write them out as base64.
                    writer.WriteBase64(key, 0, key.Length);
                    writer.WriteEndElement(); // wst:BinarySecret
                }

                writer.WriteEndElement(); // wst:Entropy
            }

            // If there is a specified keySize.
            if (this.KeySize > 0)
            {
                // Write the wst:KeySize start tag.
                writer.WriteStartElement(Constants.Trust.Elements.KeySize, Constants.Trust.NamespaceUri);
                // Write the keySize.
                writer.WriteValue(this.KeySize);
                writer.WriteEndElement(); // wst:KeySize
            }

            writer.WriteEndElement(); // wst:RequestSecurityToken
        }


        // Private methods

        /// <summary>
        /// Reads the wst:RequestSecurityToken element.
        /// </summary>
        /// <param name="xr">An XmlReader, positioned on the start tag of wst:RequestSecurityToken.</param>
        /// <returns>A RequestSecurityToken instance, initialized with the data read from the XmlReader.</returns>
        private static RequestSecurityToken ProcessRequestSecurityTokenElement(XmlReader xr)
        {
            // If provided XmlReader is null, throw an exception.
            if (xr == null)
                throw new ArgumentNullException("xr");

            // If the wst:RequestSecurityToken element is empty, then throw an exception.
            if (xr.IsEmptyElement)
                throw new ArgumentException("wst:RequestSecurityToken element was empty. Unable to create RequestSecurityToken object");

            // Store the initial depth so this function can be exited when the corresponding end-tag is reached.
            int initialDepth = xr.Depth;

            // Extract the @Context attribute value.                        
            string context = xr.GetAttribute(Constants.Trust.Attributes.Context, String.Empty);

            // Set up some default values.
            string tokenType = String.Empty;
            int keySize = 0;
            EndpointAddress appliesTo = null;
            SecurityToken entropy = null;

            // Enter a read loop...
            while (xr.Read())
            {
                // Process element start tags.
                if (XmlNodeType.Element == xr.NodeType)
                {
                    // Process WS-Trust elements.
                    if (Constants.Trust.NamespaceUri == xr.NamespaceURI)
                    {
                        if (Constants.Trust.Elements.TokenType == xr.LocalName &&
                                 !xr.IsEmptyElement)
                        {
                            xr.Read();
                            tokenType = xr.ReadContentAsString();
                        }
                        else if (Constants.Trust.Elements.KeySize == xr.LocalName &&
                                 !xr.IsEmptyElement)
                        {
                            xr.Read();
                            keySize = xr.ReadContentAsInt();
                        }
                        else if (Constants.Trust.Elements.Entropy == xr.LocalName &&
                            !xr.IsEmptyElement)
                        {
                            entropy = ProcessEntropyElement(xr);
                        }
                    }
                    // Process WS-Policy elements.
                    else if (Constants.Policy.NamespaceUri == xr.NamespaceURI)
                    {
                        if (Constants.Policy.Elements.AppliesTo == xr.LocalName &&
                            !xr.IsEmptyElement)
                        {
                            appliesTo = ProcessAppliesToElement(xr);
                        }
                    }
                }

                // Look for the end-tag that corresponds to the start-tag the reader was positioned 
                // on when the method was called. When we find it, break out of the read loop.
                if (Constants.Trust.Elements.RequestSecurityToken == xr.LocalName &&
                    Constants.Trust.NamespaceUri == xr.NamespaceURI &&
                    xr.Depth == initialDepth &&
                    XmlNodeType.EndElement == xr.NodeType)
                    break;
            }

            // Construct a new RequestSecurityToken based on the values read and return it.
            return new RequestSecurityToken(context, tokenType, keySize, appliesTo, entropy);
        }

        /// <summary>
        /// Reads a wst:Entropy element and constructs a SecurityToken.
        /// Assumes that the provided entropy is never more than 1Kb in size.
        /// </summary>
        /// <param name="xr">An XmlReader positioned on the start tag of wst:Entropy.</param>
        /// <returns>A SecurityToken that contains the entropy value.</returns>
        private static SecurityToken ProcessEntropyElement(XmlReader xr)
        {
            // If the provided XmlReader is null, throw an exception.
            if (xr == null)
                throw new ArgumentNullException("xr");

            // If the wst:Entropy element is empty, then throw an exception.
            if (xr.IsEmptyElement)
                throw new ArgumentException("wst:Entropy element was empty. Unable to create SecurityToken object");

            // Store the initial depth so this function can be exited when the corresponding end-tag is reached.
            int initialDepth = xr.Depth;

            // Set our return value to null.
            SecurityToken st = null;

            // Enter a read loop...
            while (xr.Read())
            {
                // Look for a non-empty wst:BinarySecret element.
                if (Constants.Trust.Elements.BinarySecret == xr.LocalName &&
                    Constants.Trust.NamespaceUri == xr.NamespaceURI &&
                    !xr.IsEmptyElement &&
                    XmlNodeType.Element == xr.NodeType)
                {
                    // Allocate a 1024 byte buffer for the entropy.
                    byte[] temp = new byte[1024];
                    // Move reader to the content of wst:BinarySecret element...
                    xr.Read();

                    // ...and read that content as base64. Store the actual number of bytes retrieved.                    
                    int nBytes = xr.ReadContentAsBase64(temp, 0, temp.Length);

                    // Allocate a new array of the correct size to hold the provided entropy.
                    byte[] entropy = new byte[nBytes];

                    // Copy the entropy from the temporary array into the new array.
                    for (int i = 0; i < nBytes; i++)
                        entropy[i] = temp[i];

                    // Create new BinarySecretSecurityToken from the provided entropy.
                    st = new BinarySecretSecurityToken(entropy);
                }

                // Look for the end-tag that corresponds to the start-tag that the reader was positioned 
                // on when the method was called. When it is found, break out of the read loop.
                if (Constants.Trust.Elements.Entropy == xr.LocalName &&
                    Constants.Trust.NamespaceUri == xr.NamespaceURI &&
                    xr.Depth == initialDepth &&
                    XmlNodeType.EndElement == xr.NodeType)
                    break;
            }

            // Return the SecurityToken.
            return st;
        }

        /// <summary>
        /// Reads a wsp:AppliesTo element.
        /// </summary>
        /// <param name="xr">An XmlReader positioned on the start tag of wsp:AppliesTo.</param>
        /// <returns>An EndpointAddress.</returns>
        private static EndpointAddress ProcessAppliesToElement(XmlReader xr)
        {
            // If the provided XmlReader is null, throw an exception.
            if (xr == null)
                throw new ArgumentNullException("xr");

            // If the wsp:AppliesTo element is empty, then throw an exception.
            if (xr.IsEmptyElement)
                throw new ArgumentException("wsp:AppliesTo element was empty. Unable to create EndpointAddress object");

            // Store the initial depth so this function can be exited when the corresponding end-tag is reached.
            int initialDepth = xr.Depth;

            // Set our return value to null.
            EndpointAddress ea = null;

            // Enter a read loop...
            while (xr.Read())
            {
                // Look for a WS-Addressing 1.0 Endpoint Reference...
                if (Constants.Addressing.Elements.EndpointReference == xr.LocalName &&
                    Constants.Addressing.NamespaceUri == xr.NamespaceURI &&
                    !xr.IsEmptyElement &&
                    XmlNodeType.Element == xr.NodeType)
                {
		    // <Snippet11>
                    // Create a DataContractSerializer for an EndpointAddress10.
                    DataContractSerializer dcs = new DataContractSerializer(typeof(EndpointAddress10));
                    // Read the EndpointAddress10 from the DataContractSerializer.
                    EndpointAddress10 ea10 = (EndpointAddress10)dcs.ReadObject(xr, false);
                    // Convert the EndpointAddress10 into an EndpointAddress.
                    ea = ea10.ToEndpointAddress();
		    // </Snippet11>
		    
                }

                // Look for the end-tag that corresponds to the start-tag that the reader was positioned 
                // on when the method was called. When it is found, break out of the read loop.
                if (Constants.Policy.Elements.AppliesTo == xr.LocalName &&
                    Constants.Policy.NamespaceUri == xr.NamespaceURI &&
                    xr.Depth == initialDepth &&
                    XmlNodeType.EndElement == xr.NodeType)
                    break;
            }

            // Return the EndpointAddress.
            return ea;
        }
    }
    public class Constants
    {
        public const string BookNameHeaderNamespace = "http://tempuri.org/";
        public const string BookNameHeaderName = "BookName";
        public const string PurchaseClaimNamespace = "http://tempuri.org/";
        public const string PurchaseAuthorizedClaim = PurchaseClaimNamespace + "PurchaseAuthorizedClaim";
        public const string PurchaseLimitClaim = PurchaseClaimNamespace + "PurchaseLimitClaim";
        public const string SamlTokenTypeUri = "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV1.1";

        // Various constants for WS-Trust.
        public class Trust
        {
            public const string NamespaceUri = "http://schemas.xmlsoap.org/ws/2005/02/trust";

            public class Actions
            {
                public const string Issue = "http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue";
                public const string IssueReply = "http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/Issue";
            }

            public class Attributes
            {
                public const string Context = "Context";
            }

            public class Elements
            {
                public const string KeySize = "KeySize";
                public const string Entropy = "Entropy";
                public const string BinarySecret = "BinarySecret";
                public const string RequestSecurityToken = "RequestSecurityToken";
                public const string RequestSecurityTokenResponse = "RequestSecurityTokenResponse";
                public const string TokenType = "TokenType";
                public const string RequestedSecurityToken = "RequestedSecurityToken";
                public const string RequestedAttachedReference = "RequestedAttachedReference";
                public const string RequestedUnattachedReference = "RequestedUnattachedReference";
                public const string RequestedProofToken = "RequestedProofToken";
                public const string ComputedKey = "ComputedKey";
            }

            public class ComputedKeyAlgorithms
            {
                public const string PSHA1 = "http://schemas.xmlsoap.org/ws/2005/02/trust/CK/PSHA1";
            }
        }

        // Various constants for WS-Policy.
        public class Policy
        {
            public const string NamespaceUri = "http://schemas.xmlsoap.org/ws/2004/09/policy";

            public class Elements
            {
                public const string AppliesTo = "AppliesTo";
            }
        }

        // Various constants for WS-Addressing.
        public class Addressing
        {
            public const string NamespaceUri = "http://www.w3.org/2005/08/addressing";

            public class Elements
            {
                public const string EndpointReference = "EndpointReference";
            }
        }
    }
    /// <summary>
    /// A class that represents a RequestSecurityTokenResponse message according to February 2005 WS-Trust.
    /// </summary>
    [ComVisible(false)]
    public class RequestSecurityTokenResponse : RequestSecurityTokenBase
    {
        // Private members
        private SecurityToken requestedSecurityToken;
        private SecurityToken requestedProofToken;
        private SecurityToken issuerEntropy;
        private SecurityKeyIdentifierClause requestedAttachedReference;
        private SecurityKeyIdentifierClause requestedUnattachedReference;
        private bool computeKey;

        // Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public RequestSecurityTokenResponse()
            : this(String.Empty, String.Empty, 0, null, null, null, false)
        {
        }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        /// <param name="context">The value of the wst:RequestSecurityTokenResponse/@Context attribute.</param>
        /// <param name="tokenType">The content of the wst:RequestSecurityTokenResponse/wst:TokenType element.</param>
        /// <param name="keySize">The content of the wst:RequestSecurityTokenResponse/wst:KeySize element. </param>
        /// <param name="appliesTo">An EndpointReference that corresponds to the content of the wst:RequestSecurityTokenResponse/wsp:AppliesTo element.</param>
        /// <param name="requestedSecurityToken">The requested security token.</param>
        /// <param name="requestedProofToken">The proof token associated with the requested security token.</param>
        /// <param name="computeKey">A boolean that specifies whether a key value must be computed.</param>
        public RequestSecurityTokenResponse(string context,
                                            string tokenType,
                                            int keySize,
                                            EndpointAddress appliesTo,
                                            SecurityToken requestedSecurityToken,
                                            SecurityToken requestedProofToken,
                                            bool computeKey)
            :
            base(context, tokenType, keySize, appliesTo) // Pass first 4 params to base class
        {
            this.requestedSecurityToken = requestedSecurityToken;
            this.requestedProofToken = requestedProofToken;
            this.computeKey = computeKey;
        }

        // public properties
        /// <summary>
        /// The requested SecurityToken.
        /// </summary>
        public SecurityToken RequestedSecurityToken
        {
            get { return requestedSecurityToken; }
            set { requestedSecurityToken = value; }
        }

        /// <summary>
        /// A SecurityToken that represents the proof token associated with 
        /// the requested SecurityToken.
        /// </summary>
        public SecurityToken RequestedProofToken
        {
            get { return requestedProofToken; }
            set { requestedProofToken = value; }
        }

        /// <summary>
        /// A SecurityKeyIdentifierClause that can be used to refer to the requested 
        /// SecurityToken when that token is present in messages.
        /// </summary>
        public SecurityKeyIdentifierClause RequestedAttachedReference
        {
            get { return requestedAttachedReference; }
            set { requestedAttachedReference = value; }
        }

        /// <summary>
        /// A SecurityKeyIdentifierClause that can be used to refer to the requested 
        /// SecurityToken when that token is present in messages.
        /// </summary>
        public SecurityKeyIdentifierClause RequestedUnattachedReference
        {
            get { return requestedUnattachedReference; }
            set { requestedUnattachedReference = value; }
        }

        /// <summary>
        /// The SecurityToken that represents entropy provided by the issuer.
        /// Null if the issuer did not provide entropy
        /// </summary>
        public SecurityToken IssuerEntropy
        {
            get { return issuerEntropy; }
            set { issuerEntropy = value; }
        }

        /// <summary>
        /// Indicates whether a key must be computed (typically from the combination of issuer and requestor entropy).
        /// </summary>
        public bool ComputeKey
        {
            get { return computeKey; }
            set { computeKey = value; }
        }

        // Public methods
        /// <summary>
        /// Static method that computes a combined key from issue and requestor entropy using PSHA1 according to WS-Trust.
        /// </summary>
        /// <param name="requestorEntropy">Entropy provided by the requestor.</param>
        /// <param name="issuerEntropy">Entropy provided by the issuer.</param>
        /// <param name="keySize">Size of required key, in bits.</param>
        /// <returns>Array of bytes that contain key material.</returns>
        public static byte[] ComputeCombinedKey(byte[] requestorEntropy, byte[] issuerEntropy, int keySize)
        {
            KeyedHashAlgorithm kha = new HMACSHA1(requestorEntropy, true);

            byte[] key = new byte[keySize / 8]; // Final key
            byte[] a = issuerEntropy; // A(0)
            byte[] b = new byte[kha.HashSize / 8 + a.Length]; // Buffer for A(i) + seed

            for (int i = 0; i < key.Length; )
            {
                // Calculate A(i+1).                
                kha.Initialize();
                a = kha.ComputeHash(a);

                // Calculate A(i) + seed
                a.CopyTo(b, 0);
                issuerEntropy.CopyTo(b, a.Length);
                kha.Initialize();
                byte[] result = kha.ComputeHash(b);

                for (int j = 0; j < result.Length; j++)
                {
                    if (i < key.Length)
                        key[i++] = result[j];
                    else
                        break;
                }
            }

            return key;
        }

        // Methods of BodyWriter        
        /// <summary>
        /// Writes out an XML representation of the instance.
        /// </summary>
        /// <param name="writer">The writer to be used to write out the XML content</param>
        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            // Write out the wst:RequestSecurityTokenResponse start tag.
            writer.WriteStartElement(Constants.Trust.Elements.RequestSecurityTokenResponse, Constants.Trust.NamespaceUri);

            // If we have a non-null, non-empty tokenType...
            if (this.TokenType != null && this.TokenType.Length > 0)
            {
                // Write out the wst:TokenType start tag.
                writer.WriteStartElement(Constants.Trust.Elements.TokenType, Constants.Trust.NamespaceUri);
                // Write out the tokenType string.
                writer.WriteString(this.TokenType);
                writer.WriteEndElement(); // wst:TokenType
            }

            // Create a serializer that knows how to write out security tokens.
            WSSecurityTokenSerializer ser = new WSSecurityTokenSerializer();

            // If there is a requestedSecurityToken...
            if (this.requestedSecurityToken != null)
            {
                // Write out the wst:RequestedSecurityToken start tag.
                writer.WriteStartElement(Constants.Trust.Elements.RequestedSecurityToken, Constants.Trust.NamespaceUri);
                // Write out the requested token using the serializer.
                ser.WriteToken(writer, requestedSecurityToken);
                writer.WriteEndElement(); // wst:RequestedSecurityToken
            }

            // If we have a requestedAttachedReference...
            if (this.requestedAttachedReference != null)
            {
                // Write out the wst:RequestedAttachedReference start tag.
                writer.WriteStartElement(Constants.Trust.Elements.RequestedAttachedReference, Constants.Trust.NamespaceUri);
                // Write out the reference using the serializer.
                ser.WriteKeyIdentifierClause(writer, this.requestedAttachedReference);
                writer.WriteEndElement(); // wst:RequestedAttachedReference
            }

            // If we have a requestedUnattachedReference...
            if (this.requestedUnattachedReference != null)
            {
                // Write out the wst:RequestedUnattachedReference start tag.
                writer.WriteStartElement(Constants.Trust.Elements.RequestedUnattachedReference, Constants.Trust.NamespaceUri);
                // Write out the reference using the serializer.
                ser.WriteKeyIdentifierClause(writer, this.requestedUnattachedReference);
                writer.WriteEndElement(); // wst:RequestedAttachedReference
            }

            // If we have a non-null appliesTo.
            if (this.AppliesTo != null)
            {
                // Write out the wsp:AppliesTo start tag.
                writer.WriteStartElement(Constants.Policy.Elements.AppliesTo, Constants.Policy.NamespaceUri);
                // Write the appliesTo in WS-Addressing 1.0 format.
                this.AppliesTo.WriteTo(AddressingVersion.WSAddressing10, writer);
                writer.WriteEndElement(); // wsp:AppliesTo
            }

            // If the requestedProofToken is non-null, then the STS is providing all the key material...
            if (this.requestedProofToken != null)
            {
                // Write the wst:RequestedProofToken start tag.
                writer.WriteStartElement(Constants.Trust.Elements.RequestedProofToken, Constants.Trust.NamespaceUri);
                // Write the proof token using the serializer.
                ser.WriteToken(writer, requestedProofToken);
                writer.WriteEndElement(); // wst:RequestedSecurityToken
            }

            // If issuerEntropy is non-null and computeKey is true, then combined entropy is being used...
            if (this.issuerEntropy != null && this.computeKey)
            {
                // Write the wst:RequestedProofToken start tag.
                writer.WriteStartElement(Constants.Trust.Elements.RequestedProofToken, Constants.Trust.NamespaceUri);
                // Write the wst:ComputeKey start tag.
                writer.WriteStartElement(Constants.Trust.Elements.ComputedKey, Constants.Trust.NamespaceUri);
                // Write the PSHA1 algorithm value.
                writer.WriteValue(Constants.Trust.ComputedKeyAlgorithms.PSHA1);
                writer.WriteEndElement(); // wst:ComputedKey
                writer.WriteEndElement(); // wst:RequestedSecurityToken

                // Write the wst:Entropy start tag.
                writer.WriteStartElement(Constants.Trust.Elements.Entropy, Constants.Trust.NamespaceUri);
                // Write the issuerEntropy out using the serializer.
                ser.WriteToken(writer, this.issuerEntropy);
                writer.WriteEndElement(); // wst:Entropy
            }

            writer.WriteEndElement(); // wst:RequestSecurityTokenResponse
        }
    }
    public sealed class FederationUtilities
    {
        /// <summary>
        /// Utility method to get a certificate from a given store.
        /// </summary>
        /// <param name="storeName">Name of certificate store (for example: My, TrustedPeople).</param>
        /// <param name="storeLocation">Location of certificate store (for example: LocalMachine, CurrentUser).</param>
        /// <param name="subjectDistinguishedName">The Subject Distinguished Name of the certificate<./param>
        /// <returns>The specified X.509 certificate.</returns>
        static X509Certificate2 LookupCertificate(StoreName storeName, StoreLocation storeLocation, string subjectDistinguishedName)
        {
            X509Store store = null;
            try
            {
                store = new X509Store(storeName, storeLocation);
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection certs = store.Certificates.Find(X509FindType.FindBySubjectDistinguishedName,
                                                                           subjectDistinguishedName, false);
                if (certs.Count != 1)
                {
                    throw new Exception(String.Format("FedUtil: Certificate {0} not found or more than one certificate found", subjectDistinguishedName));
                }
                return (X509Certificate2)certs[0];
            }
            finally
            {
                if (store != null) store.Close();
            }
        }


        #region GetX509TokenFromCert()
        /// <summary>
        /// Utility method to get a X.509 token from a given certificate.
        /// </summary>
        /// <param name="storeName">Name of certificate store (for example: My, TrustedPeople).</param>
        /// <param name="storeLocation">Location of certificate store (for example: LocalMachine, CurrentUser).</param>
        /// <param name="subjectDistinguishedName">The Subject Distinguished Name of the certificate.</param>
        /// <returns>The corresponding X.509 token.</returns>
        public static X509SecurityToken GetX509TokenFromCert(StoreName storeName,
                                                             StoreLocation storeLocation,
                                                             string subjectDistinguishedName)
        {
            X509Certificate2 certificate = LookupCertificate(storeName, storeLocation, subjectDistinguishedName);
            X509SecurityToken t = new X509SecurityToken(certificate);
            return t;
        }
        #endregion

        #region GetCertificateThumbprint
        /// <summary>
        /// Utility method to get an X.509 Certificate thumbprint.
        /// </summary>
        /// <param name="storeName">Name of certificate store (for example: My, TrustedPeople).</param>
        /// <param name="storeLocation">Location of certificate store (for example: LocalMachine, CurrentUser).</param>
        /// <param name="subjectDistinguishedName">The Subject Distinguished Name of the certificate.</param>
        /// <returns>The corresponding X.509 Certificate thumbprint.</returns>
        public static byte[] GetCertificateThumbprint(StoreName storeName, StoreLocation storeLocation, string subjectDistinguishedName)
        {
            X509Certificate2 certificate = LookupCertificate(storeName, storeLocation, subjectDistinguishedName);
            return certificate.GetCertHash();
        }

        #endregion

        private FederationUtilities() { }
    }
    public sealed class SamlTokenCreator
    {
        #region CreateSamlToken()
        /// <summary>
        /// Creates a SAML token with the input parameters.
        /// </summary>
        /// <param name="stsName">Name of the STS that issues the SAML token.</param>
        /// <param name="proofToken">Associated Proof Token.</param>
        /// <param name="issuerToken">Associated Issuer Token.</param>
        /// <param name="proofKeyEncryptionToken">Token to encrypt the proof key with.</param>
        /// <param name="samlConditions">The Saml Conditions to be used in the construction of the SAML token.</param>
        /// <param name="samlAttributes">The Saml Attributes to be used in the construction of the SAML token.</param>
        /// <returns>A SAML token.</returns>
        public static SamlSecurityToken CreateSamlToken(string stsName,
                                                        BinarySecretSecurityToken proofToken,
                                                        SecurityToken issuerToken,
                                                        SecurityToken proofKeyEncryptionToken,
                                                        SamlConditions samlConditions,
                                                        IEnumerable<SamlAttribute> samlAttributes)
        {
            // Create a security token reference to the issuer certificate. 
            SecurityKeyIdentifierClause skic = issuerToken.CreateKeyIdentifierClause<X509ThumbprintKeyIdentifierClause>();
            SecurityKeyIdentifier issuerKeyIdentifier = new SecurityKeyIdentifier(skic);

            // Create an encrypted key clause that contains the encrypted proof key.
            byte[] wrappedKey = proofKeyEncryptionToken.SecurityKeys[0].EncryptKey(SecurityAlgorithms.RsaOaepKeyWrap, proofToken.GetKeyBytes());
            SecurityKeyIdentifierClause encryptingTokenClause = proofKeyEncryptionToken.CreateKeyIdentifierClause<X509ThumbprintKeyIdentifierClause>();
            EncryptedKeyIdentifierClause encryptedKeyClause = new EncryptedKeyIdentifierClause(wrappedKey, SecurityAlgorithms.RsaOaepKeyWrap, new SecurityKeyIdentifier(encryptingTokenClause));
            SecurityKeyIdentifier proofKeyIdentifier = new SecurityKeyIdentifier(encryptedKeyClause);

            // Create a comfirmationMethod for HolderOfKey.
            List<string> confirmationMethods = new List<string>(1);
            confirmationMethods.Add(SamlConstants.HolderOfKey);

            // Create a SamlSubject with proof key and confirmation method from above.
            SamlSubject samlSubject = new SamlSubject(null,
                                                      null,
                                                      null,
                                                      confirmationMethods,
                                                      null,
                                                      proofKeyIdentifier);

            // Create a SamlAttributeStatement from the passed in SamlAttribute collection and the SamlSubject from above
            SamlAttributeStatement samlAttributeStatement = new SamlAttributeStatement(samlSubject, samlAttributes);

            // Put the SamlAttributeStatement into a list of SamlStatements.
            List<SamlStatement> samlSubjectStatements = new List<SamlStatement>();
            samlSubjectStatements.Add(samlAttributeStatement);

            // Create a SigningCredentials instance from the key associated with the issuerToken.
            SigningCredentials signingCredentials = new SigningCredentials(issuerToken.SecurityKeys[0],
                                                                           SecurityAlgorithms.RsaSha1Signature,
                                                                           SecurityAlgorithms.Sha1Digest,
                                                                           issuerKeyIdentifier);

            // Create a SamlAssertion from the list of SamlStatements created above and the passed in
            // SamlConditions.
            SamlAssertion samlAssertion = new SamlAssertion("_" + Guid.NewGuid().ToString(),
                                                            stsName,
                                                            DateTime.UtcNow,
                                                            samlConditions,
                                                            new SamlAdvice(),
                                                            samlSubjectStatements
                                                            );
            // Set the SigningCredentials for the SamlAssertion.
            samlAssertion.SigningCredentials = signingCredentials;

            // Create a SamlSecurityToken from the SamlAssertion and return it.
            return new SamlSecurityToken(samlAssertion);
        }

        #endregion

        private SamlTokenCreator() { }
    }
    class ServiceConstants
    {
        // Issuer name placed into issued tokens.
        internal const string SecurityTokenServiceName = "BookStore STS";

        // Statics for location of certificates.
        internal static readonly StoreName CertStoreName = StoreName.TrustedPeople;
        internal static readonly StoreLocation CertStoreLocation = StoreLocation.LocalMachine;

        // Statics initialized from app.config.
        internal static string CertDistinguishedName = "";
        internal static string TargetDistinguishedName = "";
        internal static string IssuerDistinguishedName = "";
        internal static string BookDB = "";

        #region Helper functions to load appsettings from configuration.
        /// <summary>
        /// Helper function to load Application Settings from configuration.
        /// </summary>
        public static void LoadAppSettings()
        {
/*		
            BookDB = ConfigurationManager.AppSettings["bookDB"];
            CheckIfLoaded(BookDB);
            BookDB = String.Format("{0}\\{1}", System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, BookDB);

            CertDistinguishedName = ConfigurationManager.AppSettings["certDistinguishedName"];
            CheckIfLoaded(CertDistinguishedName);

            TargetDistinguishedName = ConfigurationManager.AppSettings["targetDistinguishedName"];
            CheckIfLoaded(TargetDistinguishedName);

            IssuerDistinguishedName = ConfigurationManager.AppSettings["issuerDistinguishedName"];
            CheckIfLoaded(IssuerDistinguishedName);
            */
        }

        /// <summary>
        /// Helper function to check whether a required Application Setting has been specified in configuration.
        /// Throw an exception if some Application Setting has not been specified.
        /// </summary>
        private static void CheckIfLoaded(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                throw new ConfigurationErrorsException("Required Configuration Element(s) missing at BookStoreSTS. Please check the STS configuration file.");
            }
        }

        #endregion

        private ServiceConstants() { }
    }
}
