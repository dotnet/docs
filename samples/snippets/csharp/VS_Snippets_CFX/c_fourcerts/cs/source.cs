//<snippet0>
using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.ServiceModel.Channels;
using System.IdentityModel.Policy;

namespace Microsoft.ServiceModel.Samples
{
    //<snippet1>
    public class MyClientCredentials : ClientCredentials
    {
        X509Certificate2 clientSigningCert;
        X509Certificate2 clientEncryptingCert;
        X509Certificate2 serviceSigningCert;
        X509Certificate2 serviceEncryptingCert;

        public MyClientCredentials()
        {
        }

        protected MyClientCredentials(MyClientCredentials other)
            : base(other)
        {
            this.clientEncryptingCert = other.clientEncryptingCert;
            this.clientSigningCert = other.clientSigningCert;
            this.serviceEncryptingCert = other.serviceEncryptingCert;
            this.serviceSigningCert = other.serviceSigningCert;
        }

        public X509Certificate2 ClientSigningCertificate
        {
            get
            {
                return this.clientSigningCert;
            }
            set
            {
                this.clientSigningCert = value;
            }
        }

        public X509Certificate2 ClientEncryptingCertificate
        {
            get
            {
                return this.clientEncryptingCert;
            }
            set
            {
                this.clientEncryptingCert = value;
            }
        }

        public X509Certificate2 ServiceSigningCertificate
        {
            get
            {
                return this.serviceSigningCert;
            }
            set
            {
                this.serviceSigningCert = value;
            }
        }

        public X509Certificate2 ServiceEncryptingCertificate
        {
            get
            {
                return this.serviceEncryptingCert;
            }
            set
            {
                this.serviceEncryptingCert = value;
            }
        }

        public override SecurityTokenManager CreateSecurityTokenManager()
        {
            return new MyClientCredentialsSecurityTokenManager(this);
        }

        protected override ClientCredentials CloneCore()
        {
            return new MyClientCredentials(this);
        }
    }
    //</snippet1>

    //<snippet2>
    internal class MyClientCredentialsSecurityTokenManager :
        ClientCredentialsSecurityTokenManager
    {
        MyClientCredentials credentials;

        public MyClientCredentialsSecurityTokenManager(
            MyClientCredentials credentials): base(credentials)
        {
            this.credentials = credentials;
        }

        public override SecurityTokenProvider CreateSecurityTokenProvider(
            SecurityTokenRequirement requirement)
        {
            SecurityTokenProvider result = null;
            if (requirement.TokenType == SecurityTokenTypes.X509Certificate)
            {
                MessageDirection direction = requirement.GetProperty
                    <MessageDirection>(ServiceModelSecurityTokenRequirement.
                    MessageDirectionProperty);
                if (direction == MessageDirection.Output)
                {
                    if (requirement.KeyUsage == SecurityKeyUsage.Signature)
                    {
                        result = new X509SecurityTokenProvider(
                            this.credentials.ClientSigningCertificate);
                    }
                    else
                    {
                        result = new X509SecurityTokenProvider(this.credentials.
                            ServiceEncryptingCertificate);
                    }
                }
                else
                {
                    if (requirement.KeyUsage == SecurityKeyUsage.Signature)
                    {
                        result = new X509SecurityTokenProvider(this.
                            credentials.ServiceSigningCertificate);
                    }
                    else
                    {
                        result = new X509SecurityTokenProvider(credentials.
                            ClientEncryptingCertificate);
                    }
                }
            }
            else
            {
                result = base.CreateSecurityTokenProvider(requirement);
            }

            return result;
        }

        public override SecurityTokenAuthenticator
            CreateSecurityTokenAuthenticator(SecurityTokenRequirement
            tokenRequirement, out SecurityTokenResolver outOfBandTokenResolver)
        {
            return base.CreateSecurityTokenAuthenticator(tokenRequirement,
                out outOfBandTokenResolver);
        }
    }
    //</snippet2>

    //<snippet3>
    public class MyServiceCredentials : ServiceCredentials
    {
        X509Certificate2 clientSigningCert;
        X509Certificate2 clientEncryptingCert;
        X509Certificate2 serviceSigningCert;
        X509Certificate2 serviceEncryptingCert;

        public MyServiceCredentials()
        {
        }

        protected MyServiceCredentials(MyServiceCredentials other)
            : base(other)
        {
            this.clientEncryptingCert = other.clientEncryptingCert;
            this.clientSigningCert = other.clientSigningCert;
            this.serviceEncryptingCert = other.serviceEncryptingCert;
            this.serviceSigningCert = other.serviceSigningCert;
        }

        public X509Certificate2 ClientSigningCertificate
        {
            get
            {
                return this.clientSigningCert;
            }
            set
            {
                this.clientSigningCert = value;
            }
        }

        public X509Certificate2 ClientEncryptingCertificate
        {
            get
            {
                return this.clientEncryptingCert;
            }
            set
            {
                this.clientEncryptingCert = value;
            }
        }

        public X509Certificate2 ServiceSigningCertificate
        {
            get
            {
                return this.serviceSigningCert;
            }
            set
            {
                this.serviceSigningCert = value;
            }
        }

        public X509Certificate2 ServiceEncryptingCertificate
        {
            get
            {
                return this.serviceEncryptingCert;
            }
            set
            {
                this.serviceEncryptingCert = value;
            }
        }

        public override SecurityTokenManager CreateSecurityTokenManager()
        {
            return new MyServiceCredentialsSecurityTokenManager(this);
        }

        protected override ServiceCredentials CloneCore()
        {
            return new MyServiceCredentials(this);
        }
    }
    //</snippet3>

    //<snippet4>
    internal class MyServiceCredentialsSecurityTokenManager :
        ServiceCredentialsSecurityTokenManager
    {
        MyServiceCredentials credentials;

        public MyServiceCredentialsSecurityTokenManager(
            MyServiceCredentials credentials)
            : base(credentials)
        {
            this.credentials = credentials;
        }

        public override SecurityTokenProvider CreateSecurityTokenProvider(
            SecurityTokenRequirement requirement)
        {
            SecurityTokenProvider result = null;
            if (requirement.TokenType == SecurityTokenTypes.X509Certificate)
            {
                MessageDirection direction = requirement.
                    GetProperty<MessageDirection>(
                    ServiceModelSecurityTokenRequirement.
                    MessageDirectionProperty);
                if (direction == MessageDirection.Input)
                {
                    if (requirement.KeyUsage == SecurityKeyUsage.Exchange)
                    {
                        result = new X509SecurityTokenProvider(
                            credentials.ServiceEncryptingCertificate);
                    }
                    else
                    {
                        result = new X509SecurityTokenProvider(
                            credentials.ClientSigningCertificate);
                    }
                }
                else
                {
                    if (requirement.KeyUsage == SecurityKeyUsage.Signature)
                    {
                        result = new X509SecurityTokenProvider(
                            credentials.ServiceSigningCertificate);
                    }
                    else
                    {
                        result = new X509SecurityTokenProvider(
                            credentials.ClientEncryptingCertificate);
                    }
                }
            }
            else
            {
                result = base.CreateSecurityTokenProvider(requirement);
            }
            return result;
        }
    }
    //</snippet4>

    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Security.Samples")]
    public interface IMyService
    {
        [OperationContract]
        string Hello(string value);
    }

    public interface IMyServiceChannel : IMyService, IClientChannel
    {
    }

    public class Client
    {
        static void Main(string[] args)
        {
            //<snippet5>
            EndpointAddress serviceEndpoint =
                new EndpointAddress(new Uri("http://localhost:6060/service"));

            CustomBinding binding = new CustomBinding();

            AsymmetricSecurityBindingElement securityBE =
                SecurityBindingElement.CreateMutualCertificateDuplexBindingElement(
                MessageSecurityVersion.
WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10);
            // Add a custom IdentityVerifier because the service uses two certificates
            // (one for signing and one for encryption) and an endpoint identity that
            // contains a single identity claim.
            securityBE.LocalClientSettings.IdentityVerifier = new MyIdentityVerifier();
            binding.Elements.Add(securityBE);

            CompositeDuplexBindingElement compositeDuplex =
                new CompositeDuplexBindingElement();
            compositeDuplex.ClientBaseAddress = new Uri("http://localhost:6061/client");
            binding.Elements.Add(compositeDuplex);

            binding.Elements.Add(new OneWayBindingElement());

            binding.Elements.Add(new HttpTransportBindingElement());

            using (ChannelFactory<IMyServiceChannel> factory =
                new ChannelFactory<IMyServiceChannel>(binding, serviceEndpoint))
            {
                MyClientCredentials credentials = new MyClientCredentials();
                SetupCertificates(credentials);
                factory.Endpoint.Behaviors.Remove(typeof(ClientCredentials));
                factory.Endpoint.Behaviors.Add(credentials);

                IMyServiceChannel channel = factory.CreateChannel();
                Console.WriteLine(channel.Hello("world"));
                channel.Close();
            }
            //</snippet5>
        }

        private static void SetupCertificates(MyClientCredentials credentials)
        {
        }
    }

    //<snippet6>
    class MyIdentityVerifier : IdentityVerifier
    {
        IdentityVerifier defaultVerifier;

        public MyIdentityVerifier()
        {
            this.defaultVerifier = IdentityVerifier.CreateDefault();
        }

        public override bool CheckAccess(EndpointIdentity identity,
            AuthorizationContext authContext)
        {
            // The following implementation is for demonstration only, and
            // does not perform any checks regarding EndpointIdentity.
            // Do not use this for production code.
            return true;
        }

        public override bool TryGetIdentity(EndpointAddress reference,
            out EndpointIdentity identity)
        {
            return this.defaultVerifier.TryGetIdentity(reference, out identity);
        }
    }

    //</snippet6>
    class Service : IMyService
    {
        static void Main(string[] args)
        {
            //<snippet7>
            Uri serviceEndpoint = new Uri("http://localhost:6060/service");
            using (ServiceHost host = new ServiceHost(typeof(Service), serviceEndpoint))
            {
                CustomBinding binding = new CustomBinding();
                binding.Elements.Add(SecurityBindingElement.
                    CreateMutualCertificateDuplexBindingElement(
MessageSecurityVersion.WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10));
                binding.Elements.Add(new CompositeDuplexBindingElement());
                binding.Elements.Add(new OneWayBindingElement());
                binding.Elements.Add(new HttpTransportBindingElement());

                MyServiceCredentials credentials = new MyServiceCredentials();
                SetupCertificates(credentials);
                host.Description.Behaviors.Remove(typeof(ServiceCredentials));
                host.Description.Behaviors.Add(credentials);

                ServiceEndpoint endpoint = host.AddServiceEndpoint(
                    typeof(IMyService), binding, "");
                host.Open();

                Console.WriteLine("Service started, press ENTER to stop...");
                Console.ReadLine();
            }
            //</snippet7>
        }

        private static void SetupCertificates(MyServiceCredentials credentials)
        {
        }
        #region IMyService Members

        public string Hello(string value)
        {
            return "Hello " + value;
        }

        #endregion
    }
}
//</snippet0>
