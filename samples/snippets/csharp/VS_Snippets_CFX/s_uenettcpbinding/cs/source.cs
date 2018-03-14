// S_UENetTcpBinding/CS/source.cs Snippet for
// System.ServiceModel.TcpBinding

//<snippet0>
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
//</snippet0>

namespace TcpService
{
    class Test
    {
        //static string addressTCP = String.Format("net.tcp://{0}:8036/NetTcpSecurity",
        //    System.Net.Dns.GetHostEntry("").HostName);

        //static string addressHTTP = String.Format("http://{0}:8036/HttpCertificate",
        //    System.Net.Dns.GetHostEntry("").HostName);

        static void Main(string[] args)
        {
            Test t = new Test();
            int i = t.Choices();
            switch (i)
            {
                case 1:
                    t.TcpTransportCert();
                    break;

                case 2:
                    t.TcpMessageCert();
                    break;
            }

        }

        private int Choices()
        {
            int max = 2;
            Console.WriteLine("Type 1, 2:");
            Console.WriteLine("\t 1 = TCP, Transport, Certificate client");
            Console.WriteLine("\t 2 = TCP, Message, Certficate client");
            int answer;
            try
            {
                answer = Convert.ToInt16(Console.ReadLine());
                if (answer < 0)
                {
                    Console.WriteLine("Answer is less than zero. Returning 1");
                    answer = 1;
                }
                if (answer > max)
                {
                    Console.WriteLine("Answer is too large. Returning 1");
                    answer = 1;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("No choices match your input. Returning choice 1");
                return 1;
            }
            return answer;

        }

        private void TcpTransportCert()
        {
            // This string uses a function to prepend the computer name at run time.
            string addressTCP = String.Format(
                "net.tcp://{0}:8036/NetTcpSecurity/Transport/Certificate",
                System.Net.Dns.GetHostEntry("").HostName);

	    // <Snippet1>
	    NetTcpBinding binding = new NetTcpBinding();
	    binding.Security.Mode = SecurityMode.Transport;
	    binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;
	    // </Snippet1>

	    // <Snippet3>
	    NetTcpBinding bSecurity = new NetTcpBinding(SecurityMode.Transport);
	    // </Snippet3>

	    // <Snippet4>
	    NetTcpBinding bConfigurationName = new NetTcpBinding("MyConfiguration");
	    // </Snippet4>

	    // <Snippet5>
	    NetTcpBinding bSecurityReliable = new NetTcpBinding(SecurityMode.Transport, true);
	    // </Snippet5>

	    // <Snippet6>
	    EnvelopeVersion envelopeVersion = binding.EnvelopeVersion;
	    // </Snippet6>

	    // <Snippet7>
	    HostNameComparisonMode hostNameComparisonMode = binding.HostNameComparisonMode;
	    // </Snippet7>

	    // <Snippet8>
	    int listenBacklog = binding.ListenBacklog;
	    // </Snippet8>

	    // <Snippet9>
	    long maxBufferPoolsize = binding.MaxBufferPoolSize;
	    // </Snippet9>

	    // <Snippet10>
	    int maxBufferSize = binding.MaxBufferSize;
	    // </Snippet10>

	    // <Snippet11>
	    int maxConnections = binding.MaxConnections;
	    // </Snippet11>

	    // <Snippet12>
	    long MaxReceivedMessageSize = binding.MaxReceivedMessageSize;
	    // </Snippet12>

	    // <Snippet13>
	    bool portSharingEnabled = binding.PortSharingEnabled;
	    // </Snippet13>

	    // <Snippet14>
	    XmlDictionaryReaderQuotas xmlDictionaryReaderQuotas =
		    binding.ReaderQuotas;
	    // </Snippet14>

	    // <Snippet15>
	    OptionalReliableSession reliableSession =
		    binding.ReliableSession;
	    // </Snippet15>

	    // <Snippet16>
            string scheme = binding.Scheme;
	    // </Snippet16>

	    // <Snippet17>
	    NetTcpSecurity security = binding.Security;
	    // </Snippet17>

	    // <Snippet18>
	    bool transactionFlow = binding.TransactionFlow;
	    // </Snippet18>

	    // <Snippet19>
	    TransactionProtocol transactionProtocol =
		    binding.TransactionProtocol;
	    // </Snippet19>

	    // <Snippet20>
            BindingElementCollection elementCollection =
		    binding.CreateBindingElements();
	    // </Snippet20>

	    // <Snippet21>
            // P:System.ServiceModel.NetTcpBinding.System.ServiceModel.Channels.
	    // IBindingRuntimePreferences.ReceiveSynchronously
	    // Private, no example needed
	    // </Snippet21>

	    // <Snippet22>
	    TransferMode transferMode = binding.TransferMode;
	    // </Snippet22>



            // You must create an array of URI objects to have a base address.
            Uri a = new Uri(addressTCP);
            Uri[] baseAddresses = new Uri[] { a };

            // Create the ServiceHost. The service type (Calculator) is not
            // shown here.
            ServiceHost sh = new ServiceHost(typeof(Calculator), baseAddresses);

            // Add an endpoint to the service. Insert the thumbprint of an X.509 
            // certificate found on your computer. 
            Type c = typeof(ICalculator);
            //sh.AddServiceEndpoint(c, b, "Aloha");
            sh.Credentials.ServiceCertificate.SetCertificate(
                StoreLocation.LocalMachine,
                StoreName.My,
                X509FindType.FindByThumbprint,
                "af1f51b25cd413ed9cd00c315bbb6dc1c08da5e6");

            // This next line is optional. It specifies that the client's certificate
            // does not have to be issued by a trusted authority, but can be issued
            // by a peer if it is in the Trusted People store. Do not use this setting
            // for production code.
            // sh.Credentials.ClientCertificate.Authentication.CertificateValidationMode =
            //X509CertificateValidationMode.PeerOrChainTrust;
            sh.Open();

            string address = sh.Description.Endpoints[0].ListenUri.AbsoluteUri;
            Console.WriteLine("Listening @ {0}", address);
            Console.WriteLine("Press enter to close the service");
            Console.ReadLine();
        }

        private void TcpMessageCert()
        {
            //<snippet2>
            // This string uses a function to prepend the computer name at run time.
            string addressTCP = String.Format(
                "net.tcp://{0}:8036/NetTcpSecurity/Message/Certficate",
                System.Net.Dns.GetHostEntry("").HostName);

            // Create an instance of the NetTcpBindng and set its security mode to Message.
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
            sh.AddServiceEndpoint(c, b, "Aloha");
            sh.Credentials.ServiceCertificate.SetCertificate(
            StoreLocation.LocalMachine,
            StoreName.My,
            X509FindType.FindByThumbprint,
            "af1f50b20cd413ed9cd00c315bbb6dc1c08da5e6");
            sh.Open();

            string address = sh.Description.Endpoints[0].ListenUri.AbsoluteUri;
            Console.WriteLine("Listening @ {0}", address);
            Console.WriteLine("Press enter to close the service");
            Console.ReadLine();
            //</snippet2>
        }

        private void BasicTCPMessage()
        {
            //<snippet23>
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
            sh.Open();
            //</snippet23>
        }
    }


    [ServiceContract]
    interface ICalculator
    {
        [OperationContract]
        double Divide(double a, double b);

        [OperationContract]
        double CalculateTax(double a);

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
