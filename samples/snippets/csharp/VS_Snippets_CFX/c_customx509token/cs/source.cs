//<snippet0>
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;

namespace Microsoft.ServiceModel.Samples
{
    //<snippet1>
    class CustomX509AsymmetricSecurityKey : X509AsymmetricSecurityKey
    {
        X509Certificate2 certificate;
        object thisLock = new Object();
        bool privateKeyAvailabilityDetermined;
        AsymmetricAlgorithm privateKey;
        PublicKey publicKey;

        public CustomX509AsymmetricSecurityKey(X509Certificate2 certificate)
            : base(certificate)
        {
            this.certificate = certificate;
        }

        public override int KeySize
        {
            get { return this.PublicKey.Key.KeySize; }
        }

        AsymmetricAlgorithm PrivateKey
        {
            // You need to modify this to obtain the private key using a different cryptographic
            // provider if you do not want to use the default provider.
            get
            {
                if (!this.privateKeyAvailabilityDetermined)
                {
                    lock (ThisLock)
                    {
                        if (!this.privateKeyAvailabilityDetermined)
                        {
                            this.privateKey = this.certificate.PrivateKey;
                            this.privateKeyAvailabilityDetermined = true;
                        }
                    }
                }
                return this.privateKey;
            }
        }

        PublicKey PublicKey
        {
            get
            {
                if (this.publicKey == null)
                {
                    lock (ThisLock)
                    {
                        this.publicKey ??= this.certificate.PublicKey;
                    }
                }
                return this.publicKey;
            }
        }

        Object ThisLock
        {
            get
            {
                return thisLock;
            }
        }

        public override byte[] DecryptKey(string algorithm, byte[] keyData)
        {
            // You can decrypt the key only if you have the private key in the certificate.
            if (this.PrivateKey == null)
            {
                throw new NotSupportedException("Missing private key");
            }

            RSA rsa = this.PrivateKey as RSA;
            if (rsa == null)
            {
                throw new NotSupportedException("Private key cannot be used with RSA algorithm");
            }

            // Support exchange keySpec, AT_EXCHANGE ?
            if (rsa.KeyExchangeAlgorithm == null)
            {
                throw new NotSupportedException("Private key does not support key exchange");
            }

            switch (algorithm)
            {
                case EncryptedXml.XmlEncRSA15Url:
                    return EncryptedXml.DecryptKey(keyData, rsa, false);

                case EncryptedXml.XmlEncRSAOAEPUrl:
                    return EncryptedXml.DecryptKey(keyData, rsa, true);

                default:
                    throw new NotSupportedException(String.Format("Algorithm {0} is not supported", algorithm));
            }
        }

        public override AsymmetricAlgorithm GetAsymmetricAlgorithm(string algorithm, bool privateKey)
        {
            if (privateKey)
            {
                if (this.PrivateKey == null)
                {
                    throw new NotSupportedException("Missing private key");
                }

                switch (algorithm)
                {
                    case SignedXml.XmlDsigDSAUrl:
                        if ((this.PrivateKey as DSA) != null)
                        {
                            return (this.PrivateKey as DSA);
                        }
                        throw new NotSupportedException("Private key cannot be used with DSA");

                    case SignedXml.XmlDsigRSASHA1Url:
                    case EncryptedXml.XmlEncRSA15Url:
                    case EncryptedXml.XmlEncRSAOAEPUrl:
                        if ((this.PrivateKey as RSA) != null)
                        {
                            return (this.PrivateKey as RSA);
                        }
                        throw new NotSupportedException("Private key cannot be used with RSA");
                    default:
                        throw new NotSupportedException(String.Format("Algorithm {0} is not supported", algorithm));
                }
            }
            else
            {
                switch (algorithm)
                {
                    case SignedXml.XmlDsigDSAUrl:
                        if ((this.PublicKey.Key as DSA) != null)
                        {
                            return (this.PublicKey.Key as DSA);
                        }
                        throw new NotSupportedException("Public key cannot be used with DSA");
                    case SignedXml.XmlDsigRSASHA1Url:
                    case EncryptedXml.XmlEncRSA15Url:
                    case EncryptedXml.XmlEncRSAOAEPUrl:
                        if ((this.PublicKey.Key as RSA) != null)
                        {
                            return (this.PublicKey.Key as RSA);
                        }
                        throw new NotSupportedException("Public key cannot be used with RSA");
                    default:
                        throw new NotSupportedException(String.Format("Algorithm {0} is not supported", algorithm));
                }
            }
        }

        public override HashAlgorithm GetHashAlgorithmForSignature(string algorithm)
        {
            if (!this.IsSupportedAlgorithm(algorithm))
            {
                throw new NotSupportedException(String.Format("Algorithm {0} is not supported", algorithm));
            }

            switch (algorithm)
            {
                case SignedXml.XmlDsigDSAUrl:
                case SignedXml.XmlDsigRSASHA1Url:
                    return new SHA1Managed();
                default:
                    throw new NotSupportedException(String.Format("Algorithm {0} is not supported", algorithm));
            }
        }

        public override AsymmetricSignatureFormatter GetSignatureFormatter(string algorithm)
        {
            // The signature can be created only if the private key is present.
            if (this.PrivateKey == null)
            {
                throw new NotSupportedException("Private key is missing");
            }

            // Only one of the two algorithms is supported, not both.
            //     XmlDsigDSAUrl = "http://www.w3.org/2000/09/xmldsig#dsa-sha1";
            //     XmlDsigRSASHA1Url = "http://www.w3.org/2000/09/xmldsig#rsa-sha1";
            switch (algorithm)
            {
                case SignedXml.XmlDsigDSAUrl:

                    // Ensure that this is a DSA algorithm object.
                    DSA dsa = (this.PrivateKey as DSA);
                    if (dsa == null)
                    {
                        throw new NotSupportedException("Private key cannot be used DSA");
                    }

                    return new DSASignatureFormatter(dsa);

                case SignedXml.XmlDsigRSASHA1Url:
                    // Ensure that this is an RSA algorithm object.
                    RSA rsa = (this.PrivateKey as RSA);
                    if (rsa == null)
                    {
                        throw new NotSupportedException("Private key cannot be used RSA");
                    }

                    return new RSAPKCS1SignatureFormatter(rsa);
                default:
                    throw new NotSupportedException(String.Format("Algorithm {0} is not supported", algorithm));
            }
        }

        public override bool IsSupportedAlgorithm(string algorithm)
        {
            switch (algorithm)
            {
                case SignedXml.XmlDsigDSAUrl:
                    return (this.PublicKey.Key is DSA);

                case SignedXml.XmlDsigRSASHA1Url:
                case EncryptedXml.XmlEncRSA15Url:
                case EncryptedXml.XmlEncRSAOAEPUrl:
                    return (this.PublicKey.Key is RSA);

                default:
                    return false;
            }
        }
    }
    //</snippet1>

    //<snippet2>
    class CustomX509SecurityToken : X509SecurityToken
    {
        ReadOnlyCollection<SecurityKey> securityKeys;
        public CustomX509SecurityToken(X509Certificate2 certificate)
            : base(certificate)
        {
        }

        public override ReadOnlyCollection<SecurityKey> SecurityKeys
        {
            get
            {
                if (this.securityKeys == null)
                {
                    List<SecurityKey> temp = new List<SecurityKey>(1);
                    temp.Add(new CustomX509AsymmetricSecurityKey(this.Certificate));
                    this.securityKeys = temp.AsReadOnly();
                }
                return this.securityKeys;
            }
        }
    }
    //</snippet2>

    //<snippet3>
    class CustomX509SecurityTokenProvider : SecurityTokenProvider
    {
        X509Certificate2 certificate;

        public CustomX509SecurityTokenProvider(X509Certificate2 certificate)
        {
            this.certificate = certificate;
        }

        protected override SecurityToken GetTokenCore(TimeSpan timeout)
        {
            return new CustomX509SecurityToken(certificate);
        }
    }
    //</snippet3>

    //<snippet4>
    class CustomClientSecurityTokenManager : ClientCredentialsSecurityTokenManager
    {
        CustomClientCredentials credentials;

        public CustomClientSecurityTokenManager(CustomClientCredentials credentials)
            : base(credentials)
        {
            this.credentials = credentials;
        }

        public override SecurityTokenProvider CreateSecurityTokenProvider(SecurityTokenRequirement tokenRequirement)
        {
            SecurityTokenProvider result = null;

            if (tokenRequirement.TokenType == SecurityTokenTypes.X509Certificate)
            {
                MessageDirection direction = tokenRequirement.GetProperty<MessageDirection>(ServiceModelSecurityTokenRequirement.MessageDirectionProperty);
                if (direction == MessageDirection.Output)
                {
                    if (tokenRequirement.KeyUsage == SecurityKeyUsage.Signature)
                    {
                        result = new CustomX509SecurityTokenProvider(credentials.ClientCertificate.Certificate);
                    }
                }
                else
                {
                    if (tokenRequirement.KeyUsage == SecurityKeyUsage.Exchange)
                    {
                        result = new CustomX509SecurityTokenProvider(credentials.ClientCertificate.Certificate);
                    }
                }
            }

            result ??= base.CreateSecurityTokenProvider(tokenRequirement);
            return result;
        }
    }
    //</snippet4>

    //<snippet5>
    class CustomServiceSecurityTokenManager : ServiceCredentialsSecurityTokenManager
    {
        CustomServiceCredentials credentials;

        public CustomServiceSecurityTokenManager(CustomServiceCredentials credentials)
            : base(credentials)
        {
            this.credentials = credentials;
        }

        public override SecurityTokenProvider CreateSecurityTokenProvider(SecurityTokenRequirement tokenRequirement)
        {
            SecurityTokenProvider result = null;

            if (tokenRequirement.TokenType == SecurityTokenTypes.X509Certificate)
            {
                MessageDirection direction = tokenRequirement.GetProperty<MessageDirection>(ServiceModelSecurityTokenRequirement.MessageDirectionProperty);
                if (direction == MessageDirection.Input)
                {
                    if (tokenRequirement.KeyUsage == SecurityKeyUsage.Exchange)
                    {
                        result = new CustomX509SecurityTokenProvider(credentials.ServiceCertificate.Certificate);
                    }
                }
                else
                {
                    if (tokenRequirement.KeyUsage == SecurityKeyUsage.Signature)
                    {
                        result = new CustomX509SecurityTokenProvider(credentials.ServiceCertificate.Certificate);
                    }
                }
            }

            result ??= base.CreateSecurityTokenProvider(tokenRequirement);
            return result;
        }
    }
    //</snippet5>

    //<snippet6>
    public class CustomClientCredentials : ClientCredentials
    {
        public CustomClientCredentials()
        {
        }

        protected CustomClientCredentials(CustomClientCredentials other)
            : base(other)
        {
        }

        protected override ClientCredentials CloneCore()
        {
            return new CustomClientCredentials(this);
        }

        public override SecurityTokenManager CreateSecurityTokenManager()
        {
            return new CustomClientSecurityTokenManager(this);
        }
    }
    //</snippet6>

    //<snippet7>
    public class CustomServiceCredentials : ServiceCredentials
    {
        public CustomServiceCredentials()
        {
        }

        protected CustomServiceCredentials(CustomServiceCredentials other)
            : base(other)
        {
        }

        protected override ServiceCredentials CloneCore()
        {
            return new CustomServiceCredentials(this);
        }

        public override SecurityTokenManager CreateSecurityTokenManager()
        {
            return new CustomServiceSecurityTokenManager(this);
        }
    }
    //</snippet7>
}
//</snippet0>
