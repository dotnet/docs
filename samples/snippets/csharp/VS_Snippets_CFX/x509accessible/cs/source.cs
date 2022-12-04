using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Serialization;
using ClientCalculator;
namespace BasicAuthentication
{
    public class BasicService
    {
        static void Main()
        {
            try
            {

                MessageSecurityWithKerberosAuth.MyService.Run();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.InnerException.Message);
                Console.ReadLine();
            }
        }

        public static void Run()
        {

            // Create the binding.
            WSHttpBinding binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType =
                HttpClientCredentialType.Basic;

            // Create the URI for the endpoint.
            Uri httpUri = new Uri("https://localhost:8006/Calculator");

            // Create the service host and add an endpoint.
            ServiceHost myServiceHost = new ServiceHost(
                typeof(ServiceModel.Calculator), httpUri);
            myServiceHost.AddServiceEndpoint(
                typeof(ServiceModel.ICalculator), binding, "");

            // Open the service.
            myServiceHost.Open();
            Console.WriteLine("Listening...");
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();

            // Close the service.
            myServiceHost.Close();
        }

        public static void ClientRun()
        {

            // Create the binding.
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.Transport;
            myBinding.Security.Transport.ClientCredentialType =
                HttpClientCredentialType.Basic;

            // Create the endpoint address. Note that the machine name must
            // must match the subject or DNS field of the X.509 certificate
            // used to authenticate the service.
            EndpointAddress ea = new
                EndpointAddress("https://machineName:8006/Calculator");

            // Create the client. The code for the calculator
            // client is not shown here. See the sample applications
            // for examples of the calculator code.
            CalculatorClient cc =
                new CalculatorClient(myBinding, ea);

            // The client must provide a username and password. The code
            // to return the username and password is not shown here. Use
            // a database to store the username and passwords, or use the
            // ASP.NET Membership provider database.
            cc.ClientCredentials.UserName.UserName = ReturnUsername();
            cc.ClientCredentials.UserName.Password = ReturnPassword();

            // Begin using the client.
            cc.Open();

            Console.WriteLine(cc.Add(100, 11));
            Console.ReadLine();

            // Close the client.
            cc.Close();
        }

        private static string ReturnUsername()
        {
            return @"";
        }

        private static string ReturnPassword()
        {
            return "not";
        }
    }
}
namespace SecuredUsingWindows
{
    using ServiceModel;
    public class WindowsService
    {
        public static void Run()
        {

            // Create the binding.
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType =
                TcpClientCredentialType.Windows;

            // Create the URI for the endpoint.
            Uri netTcpUri = new Uri("net.tcp://localhost:8008/Calculator");

            // Create the service host and add an endpoint.
            ServiceHost myServiceHost = new ServiceHost(typeof(Calculator), netTcpUri);
            myServiceHost.AddServiceEndpoint(typeof(ServiceModel.ICalculator), binding, "");

            // Open the service.
            myServiceHost.Open();
            Console.WriteLine("Listening...");
            Console.ReadLine();

            // Close the service.
            myServiceHost.Close();
        }

        public static void RunClient()
        {

            // Create the binding.
            NetTcpBinding myBinding = new NetTcpBinding();
            myBinding.Security.Mode = SecurityMode.Transport;
            myBinding.Security.Transport.ClientCredentialType =
                TcpClientCredentialType.Windows;

            // Create the endpoint address.
            EndpointAddress myEndpointAddress = new
                EndpointAddress("net.tcp://localhost:8008/Calculator");

            // Create the client. The code for the calculator is not
            // shown here. client is not shown here. See the sample applications
            // for examples of the calculator code.
            CalculatorClient cc =
                new CalculatorClient(myBinding, myEndpointAddress);
            cc.Open();

            // Begin using the client.
            Console.WriteLine(cc.Add(100, 11));
            Console.ReadLine();

            // Close the client.
            cc.Close();
        }
        private static string ReturnUsername()
        {
            return @"";
        }

        private static string ReturnPassword()
        {
            return "not";
        }
    }
}
namespace SecuredByTransportWithAnonymousClient
{
    public class MyService
    {
        public static void Run()
        {

            // Create the binding.
            WSHttpBinding binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType =
                  HttpClientCredentialType.None;

            // Create the URI for the endpoint.
            Uri httpUri = new Uri("https://localhost:8006/Calculator");

            // Create the service host and add an endpoint.
            ServiceHost myServiceHost =
                new ServiceHost(typeof(ServiceModel.Calculator), httpUri);
            myServiceHost.AddServiceEndpoint(
                typeof(ServiceModel.ICalculator), binding, "");

            // Open the service host.
            myServiceHost.Open();
            Console.WriteLine("Press Enter to exit....");
            Console.ReadLine();

            // Close the service.
            myServiceHost.Close();
        }

        public static void RunClient()
        {

            // Create the binding.
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.Transport;
            myBinding.Security.Transport.ClientCredentialType =
                HttpClientCredentialType.None;

            // Create the endpoint address. Note that the machine name must
            // must match the subject or DNS field of the X.509 certificate
            // used to authenticate the service.
            EndpointAddress ea = new
                EndpointAddress("https://machineName:8006/Calculator");

            // Create the client. The code for the calculator
            // client is not shown here. See the sample applications
            // for examples of the calculator code.
            CalculatorClient cc =
                new CalculatorClient(myBinding, ea);

            // Begin using the client.
            cc.Open();
            Console.WriteLine(cc.Add(100, 1111));

            // Close the client.
            cc.Close();
        }
    }
}

namespace SecuredTransferUsingCertificates
{
    public class MyService
    {
        public static void Run()
        {

            // Create the binding. The service needs a valid certificate
            // attached to port 8006. The client also needs a valid certificate.
            WSHttpBinding binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.
                Certificate;

            // Create the URI for the endpoint.
            Uri httpUri = new Uri("https://localhost:8006/Calculator");

            // Create the service and add an endpoint.
            ServiceHost myServiceHost =
                new ServiceHost(typeof(ServiceModel.Calculator), httpUri);
            myServiceHost.AddServiceEndpoint(
                typeof(ServiceModel.ICalculator), binding, "");

            // Open the service.
            myServiceHost.Open();
            Console.WriteLine("Listening...");
            Console.ReadLine();

            // Close the service.
            myServiceHost.Close();
        }

        private void ClientRun()
        {

            // Create the binding.
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.Transport;
            myBinding.Security.Transport.ClientCredentialType =
                HttpClientCredentialType.Certificate;

            // Create the endpoint address. Note that the machine name must
            // must match the subject or DNS field of the X.509 certificate
            // used to authenticate the service.
            EndpointAddress ea = new
                EndpointAddress("https://localhost:8006/Calculator");

            // Create the client. The code for the calculator
            // client is not shown here. See the sample applications
            // for examples of the calculator code.
            CalculatorClient cc =
                new CalculatorClient(myBinding, ea);

            // The client must specify a certificate trusted by the server.
            //<snippet1>
            cc.ClientCredentials.ClientCertificate.SetCertificate(
                StoreLocation.CurrentUser,
                StoreName.My,
                X509FindType.FindBySubjectName,
                "contoso.com");
            //</snippet1>
            // Begin using the client.
            Console.WriteLine(cc.Add(100, 1111));
            cc.Open();

            // Close the client.
            cc.Close();
        }
    }
}

namespace SecuredUsingMessageSecurityWithAnonClient
{
    public class SecureService
    {
        public static void Run()
        {

            // Create the binding.
            WSHttpBinding binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.Message;
            binding.Security.Message.ClientCredentialType = MessageCredentialType.None;

            // Create the URI for the endpoint.
            Uri httpUri = new Uri("http://localhost:90/Calculator");

            // Create the service host and add an endpoint.
            ServiceHost myServiceHost =
                new ServiceHost(typeof(ServiceModel.Calculator), httpUri);
            myServiceHost.AddServiceEndpoint(
                typeof(ServiceModel.ICalculator), binding, "");

            // Specify a certificate to authenticate the service.
            myServiceHost.Credentials.ServiceCertificate.SetCertificate(
                StoreLocation.LocalMachine,
                StoreName.My,
                X509FindType.FindByThumbprint,
                "00000000000000000000000000000000");

            // Open the service.
            myServiceHost.Open();
            Console.WriteLine("Listening...");
            Console.ReadLine();

            // Close the service.
            myServiceHost.Close();
        }

        private void ClientRun()
        {

            // Create the binding.
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.Message;
            myBinding.Security.Message.ClientCredentialType =
                MessageCredentialType.None;

            // Create the endpoint address.
            EndpointAddress ea = new
                EndpointAddress("http://localhost:90/Calculator");

            // Create the client.
            CalculatorClient cc =
                new CalculatorClient(myBinding, ea);

            // Begin using the client.
            cc.Open();
            Console.WriteLine(cc.Add(200, 1111));
            Console.ReadLine();

            // Close the client.
            cc.Close();
        }
    }
}

namespace SecuredUsingMessageSecurityWithUsername
{
    using ServiceModel;
    public class MyService
    {
        public static void Run()
        {

            // Create the binding.
            WSHttpBinding binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.Message;
            binding.Security.Message.ClientCredentialType =
                 MessageCredentialType.UserName;

            // Create the URI for the endpoint.
            Uri httpUri = new Uri("http://localhost:90/Calculator");

            // Create the service host.
            ServiceHost myServiceHost =
                new ServiceHost(typeof(Calculator), httpUri);
            myServiceHost.AddServiceEndpoint(typeof(ICalculator), binding, "");

            // Specify a certificate to authenticate the service.
            myServiceHost.Credentials.ServiceCertificate.
                SetCertificate(StoreLocation.LocalMachine,
                StoreName.My,
                X509FindType.FindBySubjectName,
                "Contoso.com");

            myServiceHost.Open();
            Console.WriteLine("Listening...");
            Console.ReadLine();

            // Close the service.
            myServiceHost.Close();
        }

        private void ClientRun()
        {

            // Create the binding.
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.Message;
            myBinding.Security.Message.ClientCredentialType =
                MessageCredentialType.UserName;

            // Create the endpoint address.
            EndpointAddress ea = new
                EndpointAddress("http://localhost:90/Calculator");

            // Create the client.
            CalculatorClient cc =
                new CalculatorClient(myBinding, ea);

            // Set the username and password. The code to
            // return the username and password is not shown here. Use
            // an interface to query the user for the information.
            cc.ClientCredentials.UserName.UserName = ReturnUsername();
            cc.ClientCredentials.UserName.Password = ReturnPassword();

            // Begin using the client.
            cc.Open();
            Console.WriteLine(cc.Add(200, 1111));
            Console.ReadLine();

            // Close the client.
            cc.Close();
        }

        private string ReturnUsername()
        {
            return "someone@example.com";
        }

        private string ReturnPassword()
        {
            return "notReally";
        }
    }
}
namespace SecuredUsingMessageWithCertClient
{
    using ServiceModel;
    public class MyService
    {
        public static void Run()
        {

            // Create the binding.
            WSHttpBinding binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.Message;
            binding.Security.Message.ClientCredentialType =
                 MessageCredentialType.Certificate;

            // Create the URI for the endpoint.
            Uri httpUri = new Uri("http://localhost:90/Calculator");

            // Create the service host.
            ServiceHost myServiceHost =
                new ServiceHost(typeof(Calculator), httpUri);
            myServiceHost.AddServiceEndpoint(typeof(ICalculator), binding, "");

            // Specify a certificate to authenticate the service.
            myServiceHost.Credentials.ServiceCertificate.
                SetCertificate(StoreLocation.LocalMachine,
                StoreName.My,
                X509FindType.FindBySubjectName,
                "Contoso.com");

            // Open the service.
            myServiceHost.Open();
            Console.WriteLine("Listening...");
            Console.ReadLine();

            // Close the service.
            myServiceHost.Close();
        }
        private void ClientRun()
        {

            // Create the binding.
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.Message;
            myBinding.Security.Message.ClientCredentialType =
                MessageCredentialType.Certificate;

            // Create the endpoint address.
            EndpointAddress ea = new
                EndpointAddress("http://localhost:90/Calculator");

            // Create the client.
            CalculatorClient cc =
                new CalculatorClient(myBinding, ea);

            // Specify a certificate to use for authenticating the client.
            cc.ClientCredentials.ClientCertificate.SetCertificate(
                StoreLocation.CurrentUser,
                StoreName.My,
                X509FindType.FindBySubjectName,
                "Contoso.com");

            // Begin using the client.
            cc.Open();
            Console.WriteLine(cc.Add(200, 1111));
            Console.ReadLine();

            // Close the client.
            cc.Close();
        }
    }
}

namespace SecuredUsingMessageWithWindowsClient
{
    using ServiceModel;
    public class MyService
    {
        public static void Run()
        {

            // Create the binding.
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Mode = SecurityMode.Message;
            binding.Security.Message.ClientCredentialType =
                MessageCredentialType.Windows;

            // Create the URI for the endpoint.
            Uri netTcpUri = new Uri("net.tcp://localhost:8006/Calculator");

            // Crate the service host and add an endpoint.
            ServiceHost myServiceHost = new ServiceHost
                (typeof(Calculator), netTcpUri);
            myServiceHost.AddServiceEndpoint(
                typeof(ICalculator), binding, "");

            // Open the service.
            myServiceHost.Open();
            Console.WriteLine("Listening ....");
            Console.ReadLine();

            // Close the service.
            myServiceHost.Close();
        }

        private void ClientRun()
        {

            // Create the binding.
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.Message;
            myBinding.Security.Message.ClientCredentialType =
                MessageCredentialType.Windows;

            // Create the endpoint address.
            EndpointAddress ea = new
                EndpointAddress("http://localhost:90/Calculator");

            // Create the client.
            CalculatorClient cc =
                new CalculatorClient(myBinding, ea);

            // Begin using the client.
            cc.Open();
            Console.WriteLine(cc.Add(200, 1111));
            Console.ReadLine();

            // Close the client.
            cc.Close();
        }
    }
}

namespace MessageSecurityWithKerberosAuth
{
    using ServiceModel;
    public class MyService
    {
        public static void Run()
        {

            // Create the service host.
            ServiceHost myServiceHost = new ServiceHost(typeof(Calculator));

            // Create the binding.
            WSHttpBinding binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.Message;
            binding.Security.Message.ClientCredentialType =
                 MessageCredentialType.Windows;

            // Disable credential negotiation and establishment of the
            // security context.
            binding.Security.Message.NegotiateServiceCredential = false;
            binding.Security.Message.EstablishSecurityContext = false;

            // Create a URI for the endpoint address.
            Uri httpUri = new Uri("http://localhost:8006/Calculator");

            // Create the EndpointAddress with the SPN for the Identity.
            EndpointAddress ea = new EndpointAddress(httpUri,
                EndpointIdentity.CreateSpnIdentity("service_spn_name"));

            // Get the contract from the ICalculator interface (not shown here).
            // See the sample applications for an example of the ICalculator.
            ContractDescription contract = ContractDescription.GetContract(
                typeof(ICalculator));

            // Create a new ServiceEndpoint.
            ServiceEndpoint se = new ServiceEndpoint(contract, binding ,ea);

            // Add the service endpoint to the service.
            myServiceHost.Description.Endpoints.Add(se);

            // Open the service.
            myServiceHost.Open();
            Console.WriteLine("Listening...");
            Console.ReadLine();

            // Close the service.
            myServiceHost.Close();
        }
        private void ClientRun()
        {

            // Create the binding.
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.Message;
            myBinding.Security.Message.ClientCredentialType =
                MessageCredentialType.Windows;

            // Disable credential negotiation and the establishment of
            // a security context.
            myBinding.Security.Message.NegotiateServiceCredential = false;
            myBinding.Security.Message.EstablishSecurityContext = false;

            // Create the endpoint address and set the SPN identity.
            // The SPN must match the identity of the service's SPN.
            // If using SvcUtil to generate a configuration file, the SPN
            // will be published as the <servicePrincipalName> element under the
            // <identity> element.
            EndpointAddress ea = new EndpointAddress(
            new Uri("http://localhost:8006/calculator"),
            EndpointIdentity.CreateSpnIdentity("service_spn_name"));

            // Create the client.
            CalculatorClient cc =
                new CalculatorClient(myBinding, ea);

            // Begin using the client.
            cc.Open();
            Console.WriteLine(cc.Add(200, 1111));
            Console.ReadLine();

            // Close the client.
            cc.Close();
        }
    }
}

namespace SecuredUsingMessageSecurityWithInteroperableCertClient
{
    using ServiceModel;
    public class MyService
    {
        public static void Run()
        {

            // Create the binding.
            WSHttpBinding binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.Message;
            binding.Security.Message.ClientCredentialType =
                MessageCredentialType.Certificate;
            binding.Security.Message.NegotiateServiceCredential = false;
            binding.Security.Message.EstablishSecurityContext = false;

            // Create the URI for the endpoint.
            Uri httpUri = new Uri("http://localhost:8006/Calculator");

            // Create the service host.
            ServiceHost myServiceHost =
                new ServiceHost(typeof(Calculator), httpUri);

            // Specify a certificate to authenticate the service.
            myServiceHost.Credentials.ServiceCertificate.SetCertificate(
                StoreLocation.LocalMachine,
                StoreName.My,
                X509FindType.FindBySubjectName,
                "contoso.com");

            // Add an endpoint to the service.
            myServiceHost.AddServiceEndpoint(typeof(ICalculator), binding, "");

            // Open the service.
            myServiceHost.Open();
            Console.WriteLine("Listening...");
            Console.ReadLine();

            // Close the service.
            myServiceHost.Close();
        }
        private void ClientRun()
        {

            // Create the binding.
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.Message;
            myBinding.Security.Message.ClientCredentialType =
                MessageCredentialType.Certificate;

            // Disable credential negotiation and the establishment of
            // a security context.
            myBinding.Security.Message.NegotiateServiceCredential = false;
            myBinding.Security.Message.EstablishSecurityContext = false;

            // Create the endpoint address.
            EndpointAddress ea = new
                EndpointAddress("http://localhost:90/Calculator");

            // Create the client.
            CalculatorClient cc =
                new CalculatorClient(myBinding, ea);

            // Specify a certificate to use for authenticating the client.
            cc.ClientCredentials.ClientCertificate.SetCertificate(
                StoreLocation.CurrentUser,
                StoreName.My,
                X509FindType.FindBySubjectName,
                "Contoso.com");

            // Specify a default certificate for the service.
            cc.ClientCredentials.ServiceCertificate.SetDefaultCertificate(
                StoreLocation.CurrentUser,
                StoreName.TrustedPeople,
                X509FindType.FindBySubjectName,
                "cohowinery.com");

            // Begin using the client.
            cc.Open();
            Console.WriteLine(cc.Add(200, 1111));
            Console.ReadLine();

            // Close the client.
            cc.Close();
        }
    }
}
namespace ServiceModel
{
    [ServiceContract]
    interface ICalculator
    {
        [OperationContract]
        double Add(double a, double b);
    }

    public class Calculator : ICalculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }
    }

    public class Utility
    {
        public static void EnableMex(ref ServiceHost sh)
        {
            ServiceMetadataBehavior sb = new ServiceMetadataBehavior();
            sb.HttpGetEnabled = true;
            sb.HttpGetUrl = new Uri("http://localhost:8008/metadata");
            sh.Description.Behaviors.Add(sb);
        }
    }
}
namespace ClientCalculator
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "ICalculator")]
    public interface ICalculator
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICalculator/Add", ReplyAction = "http://tempuri.org/ICalculator/AddResponse")]
        double Add(double a, double b);
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

        public double Add(double a, double b)
        {
            return base.Channel.Add(a, b);
        }
    }
}
