//<snippet0>
using System;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Description;
//</snippet0>
namespace TcpService
{
    class Test
    {
        static void Main(string[] args)
        {
            try
            {
                Test t = new Test();
                t.TcpTransportCert();
            }
            catch (InvalidOperationException iexc)
            {
                Console.WriteLine(iexc.Message);
                Console.ReadLine();
            }
            catch (System.Exception exc)
            {
                Console.WriteLine(exc.Message);
                Console.ReadLine();
            }
        }

        private void TcpTransportCert()
        {
            //<snippet1>
            // This string uses a function to prepend the computer name at run time.
            string addressTCP = String.Format(
                "net.tcp://{0}:8036/Calculator",
                System.Net.Dns.GetHostEntry("").HostName);

            NetTcpBinding b = new NetTcpBinding();
            b.Security.Mode = SecurityMode.Transport;
            b.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;

            // You must create an array of URI objects to have a base address.
            Uri a = new Uri(addressTCP);
            Uri[] baseAddresses = new Uri[] { a };

            // Create the ServiceHost. The service type (Calculator) is not
            // shown here.
            ServiceHost sh = new ServiceHost(typeof(Calculator), baseAddresses);

            // Add an endpoint to the service. Insert the thumbprint of an X.509
            // certificate found on your computer.
            Type c = typeof(ICalculator);
            sh.AddServiceEndpoint(c, b, "MyCalculator");
            sh.Credentials.ServiceCertificate.SetCertificate(
                StoreLocation.LocalMachine,
                StoreName.My,
                X509FindType.FindBySubjectName,
                "contoso.com");

            // This next line is optional. It specifies that the client's certificate
            // does not have to be issued by a trusted authority, but can be issued
            // by a peer if it is in the Trusted People store. Do not use this setting
            // for production code. The default is PeerTrust, which specifies that
            // the certificate must originate from a trusted certificate authority.

            // sh.Credentials.ClientCertificate.Authentication.CertificateValidationMode =
            // X509CertificateValidationMode.PeerOrChainTrust;
            try
            {
                sh.Open();

                string address = sh.Description.Endpoints[0].ListenUri.AbsoluteUri;
                Console.WriteLine($"Listening @ {address}");
                Console.WriteLine("Press enter to close the service");
                Console.ReadLine();
                sh.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine($"A communication error occurred: {ce.Message}");
                Console.WriteLine();
            }
            catch (System.Exception exc)
            {
                Console.WriteLine($"An unforeseen error occurred: {exc.Message}");
                Console.ReadLine();
            }
            //</snippet1>
        }
        private void AddMexEndpoint( ref ServiceHost sh)
        {
            ServiceMetadataBehavior sb = new ServiceMetadataBehavior();
            sb.HttpGetEnabled=true;
            sb.HttpGetUrl = new Uri("http://localhost:90//calcluator");
            sh.Description.Behaviors.Add(sb);
        }

        private void TcpMessageCert()
        {
            //<snippet2>
            // This string uses a function to prepend the computer name at run time.
            string addressTCP = String.Format(
                "net.tcp://{0}:8036/Calculator",
                System.Net.Dns.GetHostEntry("").HostName);

            // Create an instance of the NetTcpBinding and set its security mode to Message.
            NetTcpBinding b = new NetTcpBinding();
            b.Security.Mode = SecurityMode.Message;

            // Specify that the client must authenticate itself using an X.509 certificate.
            b.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;
            Uri a = new Uri(addressTCP);
            Uri[] baseAddresses = new Uri[] { a };

            // Create the ServiceHost. The service type (Calculator) is not
            // shown here.
            ServiceHost sh = new ServiceHost(typeof(Calculator), baseAddresses);

            // Add an endpoint to the service. The code to define the service
            // type (ICalculator) is not shown here. The code also requires
            // you to insert the thumbprint of an X.509 certificate on your
            // computer. The SetCertificate method specifies where the certificate
            // is stored, and how to find it, as well as the value to find.
            Type c = typeof(ICalculator);
            sh.AddServiceEndpoint(c, b, "MyCalculator");
            try
            {
                sh.Credentials.ServiceCertificate.SetCertificate(
                StoreLocation.LocalMachine,
                StoreName.My,
                X509FindType.FindByThumbprint,
                "0000000000000000000000000000000000000000");
                sh.Open();

                string address = sh.Description.Endpoints[0].ListenUri.AbsoluteUri;
                Console.WriteLine($"Listening @ {address}");
                Console.WriteLine("Press enter to close the service");
                Console.ReadLine();
                sh.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine($"A communication error occurred: {ce.Message}");
                Console.WriteLine();
            }
            catch (System.Exception exc)
            {
                Console.WriteLine($"An unforeseen error occurred: {exc.Message}");
                Console.ReadLine();
            }

            //</snippet2>
        }

        private void BasicTCPMessage()
        {
            //<snippet3>
            // Create the binding for an endpoint.
            NetTcpBinding b = new NetTcpBinding();
            b.Security.Mode = SecurityMode.Message;

            // Create the ServiceHost for a calculator.
            Uri baseUri = new Uri("net.tcp://MachineName/tcpBase");
            Uri[] baseAddresses = new Uri[] { baseUri };
            ServiceHost sh = new ServiceHost(typeof(Calculator), baseAddresses);

            // Add an endpoint using the binding and a new address.
            Type c = typeof(ICalculator);
            sh.AddServiceEndpoint(c, b, "MyEndpoint");

            // Set a certificate as the credential for the service.
            sh.Credentials.ServiceCertificate.SetCertificate(
                StoreLocation.LocalMachine,
                StoreName.My,
                X509FindType.FindBySubjectName,
                "client.com");
            try
            {
                sh.Open();
                Console.WriteLine("Listening....");
                Console.ReadLine();
                sh.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine($"A communication error occurred: {ce.Message}");
                Console.WriteLine();
            }
            catch (System.Exception exc)
            {
                Console.WriteLine($"An unforeseen error occurred: {exc.Message}");
                Console.ReadLine();
            }
            //</snippet3>
        }
        private void RunClient()
        {
            //<snippet4>
            // Create a binding using Transport and a certificate.
            NetTcpBinding b = new NetTcpBinding();
            b.Security.Mode = SecurityMode.Transport;
            b.Security.Transport.ClientCredentialType =
                TcpClientCredentialType.Certificate;

            // Create an EndPointAddress.
            EndpointAddress ea = new EndpointAddress(
                "net.tcp://localHost:8036/Calculator/MyCalculator");

            // Create the client.
            CalculatorClient cc = new CalculatorClient(b, ea);

            // Set the certificate for the client.
            cc.ClientCredentials.ClientCertificate.SetCertificate(
                StoreLocation.LocalMachine,
                StoreName.My,
                X509FindType.FindBySubjectName,
                "cohowinery.com");
            try
            {
                cc.Open();
                // Begin using the client.
                Console.WriteLine(cc.Divide(1001, 2));
                cc.Close();
            }
            catch (AddressAccessDeniedException adExc)
            {
                Console.WriteLine(adExc.Message);
                Console.ReadLine();
            }
            catch (System.Exception exc)
            {
                Console.WriteLine(exc.Message);
                Console.ReadLine();
            }
            //</snippet4>
        }
    }

    public class Calculator : ICalculator
    {

        public double Divide(double a, double b)
        {
            return a / b;
        }

        public double CalculateTax(double a)
        {

            return a * 1.0862;
        }
    }
}

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "ICalculator")]
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

    [System.Diagnostics.DebuggerStepThroughAttribute()]
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
