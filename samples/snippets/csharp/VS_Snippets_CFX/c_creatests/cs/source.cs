using System;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.IdentityModel.Tokens;
using System.Collections.Generic;
using System.ServiceModel.Description;
using System.ServiceModel.Security.Tokens;
using System.IdentityModel.Claims;
using System.ServiceModel.Channels;
using System.Security.Cryptography.X509Certificates;

namespace CreateSts
{
    public class Test
    {
        // Used in: How To: Create Security Token Service.
        //<snippet1>
        void AddSigningCredentials(SamlAssertion assertion, SecurityKey signingKey)
        {
            SigningCredentials sc = new SigningCredentials(signingKey,
                SecurityAlgorithms.RsaSha1Signature, SecurityAlgorithms.Sha1Digest);
            assertion.SigningCredentials = sc;
        }
        //</snippet1>

        //<snippet2>
        byte[] EncryptKey(byte[] plainTextKey, SecurityKey encryptingKey)
        {
            return encryptingKey.EncryptKey(SecurityAlgorithms.RsaOaepKeyWrap, plainTextKey);
        }
        //</snippet2>

        //<snippet3>
        SecurityKeyIdentifier GetKeyIdentifierForEncryptedKey(byte[] encryptedKey,
            SecurityToken encryptingToken)
        {
            SecurityKeyIdentifier encryptingKeyIdentifier = new SecurityKeyIdentifier(encryptingToken.CreateKeyIdentifierClause<X509ThumbprintKeyIdentifierClause>());
            return new SecurityKeyIdentifier(new EncryptedKeyIdentifierClause(encryptedKey, SecurityAlgorithms.RsaOaepKeyWrap, encryptingKeyIdentifier));
        }
        //</snippet3>

        //<snippet4>
        SamlSubject CreateSamlSubjectForProofKey(SecurityKeyIdentifier proofKeyIdentifier)
        {
            List<string> confirmations = new List<string>();

            confirmations.Add("urn:oasis:names:tc:SAML:1.0:cm:holder-of-key");

            return new SamlSubject(null, null, "IssuerName", confirmations, null, proofKeyIdentifier);
        }
        //</snippet4>

        //<snippet5>
        SecurityToken CreateIssuedToken(SamlAssertion assertion)
        {
            return new SamlSecurityToken(assertion);
        }
        //</snippet5>

        //<snippet6>
        BinarySecretSecurityToken CreateProofToken(byte[] proofKey)
        {
            return new BinarySecretSecurityToken(proofKey);
        }
        //</snippet6>

        //<snippet7>
        SecurityKeyIdentifierClause CreateTokenReference(SamlSecurityToken token)
        {
            return token.CreateKeyIdentifierClause<SamlAssertionKeyIdentifierClause>();
        }
        //</snippet7>

        private void CreateClaim()
        {
            //<snippet8>
            Claim myClaim = new Claim(
                ClaimTypes.GivenName, "Martin", Rights.PossessProperty);
            SamlAttribute sa = new SamlAttribute(myClaim);
            //</snippet8>
        }
    }
}
namespace Client
{
    class Test
    {
        private void Run()
        {
            //<snippet31>
            //<snippet30>
            WSHttpBinding b = new WSHttpBinding();
            EndpointAddress ea = new EndpointAddress("http://localhost/Calculator");
            CalculatorClient client = new CalculatorClient(b, ea);
            //<snippet9>
            IssuedTokenClientCredential itcc = client.ClientCredentials.IssuedToken;
            //</snippet9>
            //</snippet30>

            //<snippet10>
            itcc.LocalIssuerAddress = new EndpointAddress("http://fabrikam.com/sts");
            //</snippet10>
            //</snippet31>

            AddressHeader a1 = AddressHeader.CreateAddressHeader("Hello", "World", "hello");
            AddressHeader[] addressHeaders = new AddressHeader[] { a1 };

            //<snippet11>
            itcc.LocalIssuerAddress = new EndpointAddress(new Uri("http://fabrikam.com/sts"),
                addressHeaders);
            //</snippet11>

            //<snippet12>
            itcc.LocalIssuerAddress = new EndpointAddress(
                new Uri("http://fabrikam.com/sts"),
                EndpointIdentity.CreateDnsIdentity("fabrikam.com"),
                addressHeaders);
            //</snippet12>

            //<snippet13>
            itcc.LocalIssuerBinding = new WSHttpBinding("LocalIssuerBinding");
            //</snippet13>

            //<snippet32>
            SynchronousReceiveBehavior myEndpointBehavior = new SynchronousReceiveBehavior();
            //<snippet14>
            itcc.LocalIssuerChannelBehaviors.Add(myEndpointBehavior);
            //</snippet14>
            //</snippet32>

            //<snippet15>
            itcc.MaxIssuedTokenCachingTime = new TimeSpan(0, 10, 0);
            //</snippet15>

            //<snippet16>
            itcc.IssuedTokenRenewalThresholdPercentage = 80;
            //</snippet16>

            //<snippet17>
            itcc.DefaultKeyEntropyMode = SecurityKeyEntropyMode.ServerEntropy;
            //</snippet17>

            //<snippet33>
            //<snippet18>
            X509CertificateRecipientClientCredential rcc =
                client.ClientCredentials.ServiceCertificate;
            //</snippet18>

            X509Certificate2 cert = new X509Certificate2();
            //<snippet19>
            rcc.ScopedCertificates.Add(new Uri("http://fabrikam.com/sts"), cert);
            //</snippet19>
            //</snippet33>
        }

        //<snippet20>
        public void snippet20(CalculatorClient client)
        {
            X509CertificateRecipientClientCredential rcc = client.ClientCredentials.ServiceCertificate;
            rcc.SetScopedCertificate(StoreLocation.CurrentUser,
                                     StoreName.TrustedPeople,
                                     X509FindType.FindBySubjectName,
                                     "FabrikamSTS",
                                     new Uri("http://fabrikam.com/sts"));
        }
        //</snippet20>

        //<snippet21>
        public void snippet21(CalculatorClient cc)
        {
            X509CertificateRecipientClientCredential rcc = cc.ClientCredentials.ServiceCertificate;
            X509ServiceCertificateAuthentication xauth = rcc.Authentication;
        }
        //</snippet21>

        //<snippet22>
        public void snippet22(CalculatorClient cc)
        {
            X509CertificateRecipientClientCredential rcc = cc.ClientCredentials.ServiceCertificate;
            rcc.SetDefaultCertificate(StoreLocation.CurrentUser,
                                     StoreName.TrustedPeople,
                                     X509FindType.FindBySubjectName,
                                     "FabrikamSTS");
        }
        //</snippet22>

        //<snippet23>
        public void snippet23(CalculatorClient cc)
        {
            X509CertificateRecipientClientCredential rcc = cc.ClientCredentials.ServiceCertificate;
            rcc.SetDefaultCertificate("http://fabrikam.com/sts",
                                     StoreLocation.CurrentUser,
                                     StoreName.TrustedPeople);
        }
        //</snippet23>

        //<snippet24>
        public void snippet24(CalculatorClient cc)
        {
            X509CertificateRecipientClientCredential rcc = cc.ClientCredentials.ServiceCertificate;
            X509Certificate2 cert = rcc.DefaultCertificate;
        }
        //</snippet24>

        //<snippet25>
        public void snippet25(CalculatorClient cc)
        {
            X509CertificateRecipientClientCredential rcc = cc.ClientCredentials.ServiceCertificate;
            rcc.SetScopedCertificate("http://fabrikam.com/sts",
                                     StoreLocation.CurrentUser,
                                     StoreName.TrustedPeople,
                                     new Uri("http://fabrikam.com"));
        }
        //</snippet25>

        //<snippet26>
        public void snippet26(CalculatorClient client)
        {
            PeerCredential peercred = client.ClientCredentials.Peer;
        }
        //</snippet26>

        //<snippet27>
        public void snippet27(CalculatorClient client)
        {
            client.ClientCredentials.SupportInteractive = false;
        }
        //</snippet27>
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute()]
    public interface ICalculator
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICalculator/Divide", ReplyAction = "http://tempuri.org/ICalculator/DivideResponse")]
        double Divide(double a, double b);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICalculator/CalculateTax", ReplyAction = "http://tempuri.org/ICalculator/CalculateTaxResponse")]
        double CalculateTax(double a);
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface ICalculatorChannel : ICalculator, System.ServiceModel.IClientChannel
    {
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class CalculatorClient : System.ServiceModel.ClientBase<ICalculator>, ICalculator
    {

        public CalculatorClient()
        {
        }

        public CalculatorClient(string endpointConfigurationName)
            :
                base(endpointConfigurationName)
        {
        }

        public CalculatorClient(string endpointConfigurationName, string remoteAddress)
            :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public CalculatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress)
            :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public CalculatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress)
            :
                base(binding, remoteAddress)
        {
        }

        public double Divide(double a, double b)
        {
            return base.Channel.Divide(a, b);
        }

        public double CalculateTax(double a)
        {
            return base.Channel.CalculateTax(a);
        }
    }
}
