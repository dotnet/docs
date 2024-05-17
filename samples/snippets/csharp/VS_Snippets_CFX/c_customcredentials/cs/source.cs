//<snippet0>
using System;
using System.IdentityModel.Selectors;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Configuration;
using System.Configuration;

namespace Microsoft.ServiceModel.Samples
{
    //<snippet1>
    public class MyClientCredentials : ClientCredentials
    {
        string creditCardNumber;

        public MyClientCredentials()
        {
            // Perform client credentials initialization.
        }

        protected MyClientCredentials(MyClientCredentials other)
            : base(other)
        {
            // Clone fields defined in this class.
            this.creditCardNumber = other.creditCardNumber;
        }

        public string CreditCardNumber
        {
            get
            {
                return this.creditCardNumber;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                this.creditCardNumber = value;
            }
        }

        public override SecurityTokenManager CreateSecurityTokenManager()
        {
            // Return your implementation of the SecurityTokenManager.
            return new MyClientCredentialsSecurityTokenManager(this);
        }

        protected override ClientCredentials CloneCore()
        {
            // Implement the cloning functionality.
            return new MyClientCredentials(this);
        }
    }
    //</snippet1>

    //<snippet2>
    internal class MyClientCredentialsSecurityTokenManager :
        ClientCredentialsSecurityTokenManager
    {
        MyClientCredentials credentials;

        public MyClientCredentialsSecurityTokenManager(MyClientCredentials credentials)
            : base(credentials)
        {
            this.credentials = credentials;
        }

        public override SecurityTokenProvider CreateSecurityTokenProvider(
            SecurityTokenRequirement tokenRequirement)
        {
            // Return your implementation of the SecurityTokenProvider, if required.
            // This implementation delegates to the base class.
            return base.CreateSecurityTokenProvider(tokenRequirement);
        }

        public override SecurityTokenAuthenticator CreateSecurityTokenAuthenticator(
            SecurityTokenRequirement tokenRequirement, out SecurityTokenResolver outOfBandTokenResolver)
        {
            // Return your implementation of the SecurityTokenAuthenticator, if required.
            // This implementation delegates to the base class.
            return base.CreateSecurityTokenAuthenticator(tokenRequirement, out outOfBandTokenResolver);
        }

        public override SecurityTokenSerializer CreateSecurityTokenSerializer(SecurityTokenVersion version)
        {
            // Return your implementation of the SecurityTokenSerializer, if required.
            // This implementation delegates to the base class.
            return base.CreateSecurityTokenSerializer(version);
        }
    }
    //</snippet2>

    //<snippet4>
    public class MyServiceCredentials : ServiceCredentials
    {
        X509Certificate2 additionalCertificate;

        public MyServiceCredentials()
        {
        }

        protected MyServiceCredentials(MyServiceCredentials other)
            : base(other)
        {
            this.additionalCertificate = other.additionalCertificate;
        }

        public X509Certificate2 AdditionalCertificate
        {
            get
            {
                return this.additionalCertificate;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                this.additionalCertificate = value;
            }
        }

        public override SecurityTokenManager CreateSecurityTokenManager()
        {
            return base.CreateSecurityTokenManager();
        }

        protected override ServiceCredentials CloneCore()
        {
            return new MyServiceCredentials(this);
        }
    }
    //</snippet4>

    //<snippet5>
    internal class MyServiceCredentialsSecurityTokenManager :
        ServiceCredentialsSecurityTokenManager
    {
        MyServiceCredentials credentials;

        public MyServiceCredentialsSecurityTokenManager(MyServiceCredentials credentials)
            : base(credentials)
        {
            this.credentials = credentials;
        }

        public override SecurityTokenProvider CreateSecurityTokenProvider(SecurityTokenRequirement tokenRequirement)
        {
            // Return your implementation of SecurityTokenProvider, if required.
            // This implementation delegates to the base class.
            return base.CreateSecurityTokenProvider(tokenRequirement);
        }

        public override SecurityTokenAuthenticator CreateSecurityTokenAuthenticator(SecurityTokenRequirement tokenRequirement, out SecurityTokenResolver outOfBandTokenResolver)
        {
            // Return your implementation of SecurityTokenProvider, if required.
            // This implementation delegates to the base class.
            return base.CreateSecurityTokenAuthenticator(tokenRequirement, out outOfBandTokenResolver);
        }

        public override SecurityTokenSerializer CreateSecurityTokenSerializer(SecurityTokenVersion version)
        {
            // Return your implementation of SecurityTokenProvider, if required.
            // This implementation delegates to the base class.
            return base.CreateSecurityTokenSerializer(version);
        }
    }
    //</snippet5>

    //<snippet7>
    public class MyClientCredentialsConfigHandler : ClientCredentialsElement
    {
        ConfigurationPropertyCollection properties;

        public override Type BehaviorType
        {
            get { return typeof(MyClientCredentials); }
        }

        public string CreditCardNumber
        {
            get { return (string)base["creditCardNumber"]; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    value = String.Empty;
                }
                base["creditCardNumber"] = value;
            }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                if (this.properties == null)
                {
                    ConfigurationPropertyCollection properties = base.Properties;
                    properties.Add(new ConfigurationProperty(
                        "creditCardNumber",
                        typeof(System.String),
                        string.Empty,
                        null,
                        new StringValidator(0, 32, null),
                        ConfigurationPropertyOptions.None));
                    this.properties = properties;
                }
                return this.properties;
            }
        }

        protected override object CreateBehavior()
        {
            MyClientCredentials creds = new MyClientCredentials();
            creds.CreditCardNumber = CreditCardNumber;
            base.ApplyConfiguration(creds);
            return creds;
        }
    }
    //</snippet7>

    public class Client
    {
        static void Main()
        {
            //<snippet3>
            // Create a client with the client endpoint configuration.
            CalculatorClient client = new CalculatorClient();

            // Remove the ClientCredentials behavior.
            client.ChannelFactory.Endpoint.Behaviors.Remove<ClientCredentials>();

            // Add a custom client credentials instance to the behaviors collection.
            client.ChannelFactory.Endpoint.Behaviors.Add(new MyClientCredentials());
            //</snippet3>
            double value1 = 100.00D;
            double value2 = 15.99D;
            double result = client.Add(value1, value2);
            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

            // Closing the client closes the connection and cleans up resources.
            client.Close();

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }

    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string Echo(string value);
    }

    public class Service : IService
    {
        static void Main()
        {
            //<snippet6>
            // Create a service host with a service type.
            ServiceHost serviceHost = new ServiceHost(typeof(Service));

            // Remove the default ServiceCredentials behavior.
            serviceHost.Description.Behaviors.Remove<ServiceCredentials>();

            // Add a custom service credentials instance to the collection.
            serviceHost.Description.Behaviors.Add(new MyServiceCredentials());
            //</snippet6>

            Console.WriteLine("Service started");
            Console.WriteLine("Press <ENTER> to terminate.");
            Console.ReadLine();
        }

        #region IService Members

        public string Echo(string value)
        {
            return value;
        }

        #endregion
    }
    public partial class CalculatorClient : System.ServiceModel.ClientBase<ICalculator>, ICalculator
{

    public CalculatorClient()
    {
    }

    public CalculatorClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
    {
    }

    public CalculatorClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
    {
    }

    public CalculatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
    {
    }

    public CalculatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
    {
    }

    public double Add(double a, double b)
    {
        return base.Channel.Add(a, b);
    }
}

    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "ICalculator")]
    public interface ICalculator
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICalculator/Add", ReplyAction = "http://tempuri.org/ICalculator/AddResponse")]
        double Add(double a, double b);
    }
}
//</snippet0>
