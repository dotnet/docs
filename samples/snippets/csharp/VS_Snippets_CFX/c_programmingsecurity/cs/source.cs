using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.ServiceModel.Description;

namespace Windows.Communication.Foundation.Samples
{

    public class Test
    {
        private Test() { }
        static void Main()
        {
            Console.WriteLine("Hello");
            Console.ReadLine();
        }

        private class Snippets
        {
            WSHttpBinding binding;
            ServiceHost myServiceHost;
            CalculatorClient CalculatorClient;
            private string ReturnUserName() { return "SHH"; }
            private string ReturnPassword() { return "SHH"; }

            private void snippet1()
            {
                //<snippet1>
                BasicHttpBinding binding = new BasicHttpBinding();
                // Specify HTTPS as the security mechanism.
                binding.Security.Mode = BasicHttpSecurityMode.Transport;
                //</snippet1>
            }
            private void Snippet2()
            {
                //<snippet2>
                NetTcpBinding binding = new NetTcpBinding();
                // Specify the mode, then the credential type.
                binding.Security.Mode = SecurityMode.Message;
                binding.Security.Message.ClientCredentialType =
                    MessageCredentialType.UserName;
                //</snippet2>
            }
            private void snippet3()
            {
                //<snippet3>
                NetTcpBinding binding = new NetTcpBinding();
                binding.Security.Mode = SecurityMode.Transport;
                binding.Security.Transport.ClientCredentialType =
                    TcpClientCredentialType.Certificate;
                //</snippet3>
            }

            private void Snippet4()
            {
                //<snippet4>
                // Specify client credentials on the client.
                // Code to set the UserName and Password is not shown here.
                CalculatorClient CalculatorClient = new CalculatorClient("myBinding");
                CalculatorClient.ClientCredentials.UserName.UserName = ReturnUserName();
                CalculatorClient.ClientCredentials.UserName.Password = ReturnPassword();
                //</snippet4>
            }

            private void Snippet5()
            {
                //<snippet5>
                ServiceHost myServiceHost = new ServiceHost(typeof(CalculatorService));
                // Create a binding to use.
                WSHttpBinding binding = new WSHttpBinding();
                binding.Security.Mode = SecurityMode.Message;
                binding.Security.Message.ClientCredentialType =
                    MessageCredentialType.Certificate;

                // Set the client certificate.
                myServiceHost.Credentials.ClientCertificate.SetCertificate(
                    StoreLocation.CurrentUser,
                    StoreName.My,
                    X509FindType.FindBySubjectName,
                    "client.com");
                //</snippet5>
            }

            private void Snippet6And7()
            {
                //<snippet6>
                ServiceHost myServiceHost = new ServiceHost(typeof(CalculatorService));

                // Specify client credentials validation on the service.
                ServiceCredentials myServiceCredentials =
                    myServiceHost.Description.Behaviors.Find<ServiceCredentials>();

                // The CurrentUser property of the StoreLocation class is a static method.
                myServiceCredentials.ClientCertificate.Authentication.TrustedStoreLocation =
                    StoreLocation.CurrentUser;
                //</snippet6>

                //<snippet7>
                WSHttpBinding binding = new WSHttpBinding();
                binding.Security.Mode = SecurityMode.Message;
                binding.Security.Message.ClientCredentialType =
                    MessageCredentialType.UserName;
                binding.Security.Message.NegotiateServiceCredential = false;

                CalculatorClient CalculatorClient = new CalculatorClient("myBinding");
                CalculatorClient.ClientCredentials.ServiceCertificate.
                    SetDefaultCertificate("Al", StoreLocation.CurrentUser, StoreName.My);
                //</snippet7>
            }

            private void Snippet8()
            {
                //<snippet8>
                WSHttpBinding binding = new WSHttpBinding();
                binding.Security.Mode = SecurityMode.Message;
                binding.Security.Message.AlgorithmSuite =
                    System.ServiceModel.Security.SecurityAlgorithmSuite.Basic256;
                //</snippet8>
            }

            //<snippet9>
            [OperationContract(ProtectionLevel =
                System.Net.Security.ProtectionLevel.EncryptAndSign)]
            private void MyCalculatorMethod()
            {
                // Code not shown.
            }
            //</snippet9>

            private void TransportSecurityOverview()
            {
                //<snippet10>
                BasicHttpBinding b = new BasicHttpBinding();
                b.Security.Mode = BasicHttpSecurityMode.Transport ;
                b.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
                //</snippet10>
            }

            private void TransportSecurityOverview2()
            {
                //<snippet11>
                // The code uses a shortcut to specify the security mode to Transport.
                WSHttpBinding b = new WSHttpBinding(SecurityMode.Transport);
                b.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
                //</snippet11>
            }

            private void TransportSecurityOverview3()
            {
                //<snippet12>
                NetTcpBinding b = new NetTcpBinding();
                b.Security.Mode = SecurityMode.Transport;
                b.Security.Transport.ClientCredentialType =
                TcpClientCredentialType.Certificate;
                //</snippet12>
            }

            private void ClientSideCode()
            {
                //<snippet13>
                NetTcpBinding b = new NetTcpBinding();
                b.Security.Mode = SecurityMode.Transport;
                b.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;
                EndpointAddress a = new EndpointAddress("net.tcp://contoso.com/TcpAddress");
                ChannelFactory<ICalculator> cf = new ChannelFactory<ICalculator>(b, a);
                cf.Credentials.ClientCertificate.SetCertificate(
                    StoreLocation.LocalMachine,
                    StoreName.My,
                    X509FindType.FindByThumbprint,
                    "0000000000000000000000000000000000000000");
                //</snippet13>
            }

            private void Snippet14()
            {
                //<snippet15>
                //<snippet14>
                ServiceHost myServiceHost = new ServiceHost(typeof(CalculatorService));
                // Create a binding to use.
                WSHttpBinding binding = new WSHttpBinding();
                binding.Security.Mode = SecurityMode.Message;
                binding.Security.Message.ClientCredentialType =
                    MessageCredentialType.Windows;
                //</snippet14>

                // Set the service certificate.
                myServiceHost.Credentials.ServiceCertificate.SetCertificate("cn=service.com");
                //</snippet15>
            }
        }
    }

    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface ICalculator
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://Microsoft.ServiceModel.Samples/ICalculator/Add", ReplyAction = "http://Microsoft.ServiceModel.Samples/ICalculator/AddResponse")]
        double Add(double n1, double n2);

        [System.ServiceModel.OperationContractAttribute(Action = "http://Microsoft.ServiceModel.Samples/ICalculator/Subtract", ReplyAction = "http://Microsoft.ServiceModel.Samples/ICalculator/SubtractResponse")]
        double Subtract(double n1, double n2);

        [System.ServiceModel.OperationContractAttribute(Action = "http://Microsoft.ServiceModel.Samples/ICalculator/Multiply", ReplyAction = "http://Microsoft.ServiceModel.Samples/ICalculator/MultiplyResponse")]
        double Multiply(double n1, double n2);

        [System.ServiceModel.OperationContractAttribute(Action = "http://Microsoft.ServiceModel.Samples/ICalculator/Divide", ReplyAction = "http://Microsoft.ServiceModel.Samples/ICalculator/DivideResponse")]
        double Divide(double n1, double n2);
    }

    public interface ICalculatorChannel : ICalculator, System.ServiceModel.IClientChannel
    {
    }

    public partial class CalculatorClient : System.ServiceModel.ClientBase<ICalculator>, ICalculator
    {

        public CalculatorClient()
        {
        }

        public CalculatorClient(string configurationName)
            :
                base(configurationName)
        {
        }

        public CalculatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress address)
            :
                base(binding, address)
        {
        }

        public double Add(double n1, double n2)
        {
            return base.Channel.Add(n1, n2);
        }

        public double Subtract(double n1, double n2)
        {
            return base.Channel.Subtract(n1, n2);
        }

        public double Multiply(double n1, double n2)
        {
            return base.Channel.Multiply(n1, n2);
        }

        public double Divide(double n1, double n2)
        {
            return base.Channel.Divide(n1, n2);
        }
    }

    public class CalculatorService
    { }
}
