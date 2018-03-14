// Snippet Class:  for ClientCredentials
// snippet digits: 0-4 used 
// References:
//   System.ServiceModel
// 
// History: 
//   06-21-2006 a-arhu created
// 
/*
    //Example
    //The following code shows how you can use this property to configure the X.509 certificate.

// snippet3
    // see source.cs below
    // Configure proxy with 
    // certificate.
    proxy.ClientCredentials.ClientCertificate.SetCertificate(
  		StoreLocation.CurrentUser, 
  		StoreName.TrustedPeople, 
  		X509FindType.FindBySubjectName, 
  		"test1");
 
// snippet4
Example
The following code shows how to configure a credential.
   // Configure proxy with 
   // (username,password).
   proxy.ClientCredentials.UserName.UserName = "test1";
   proxy.ClientCredentials.UserName.Password = "1tset";
 

Example
The following code shows how to use the object returned by this property to configure the impersonation level.
// Create a proxy with the given client endpoint configuration.
            using (CalculatorProxy proxy = new CalculatorProxy())
            {
                proxy.ClientCredentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation;
*/

//<snippet0>
using System;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Security.Principal;
//</snippet0>
[assembly: SecurityPermission(
   SecurityAction.RequestMinimum, Execution = true)]
namespace Microsoft.Security.Samples
{    internal class Service
    {
        static void Main(string[] args)
        {
            try
            {
                Service s = new Service();
                s.NetTcpSecurityWindows();
                Console.ReadLine();
            }
            catch (System.InvalidOperationException exc)
            {
                Console.WriteLine("Message: {0}", exc.Message);
            }
            catch (System.ServiceModel.AddressAlreadyInUseException exc)
            {
                Console.WriteLine("Message: {0}", exc.Message);
            }
            catch (System.ServiceModel.ProtocolException exc)
            {
                Console.WriteLine("Message: {0}", exc.Message);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                Console.WriteLine(exc.InnerException.Message);
                Console.ReadLine();
            }

        }

        private void NetTcpSecurityWindows()
        {
            //<snippet1>
            // Create a NetTcpBinding and set its security properties. The
            // security mode is Message, and the client must be authenticated with
            // Windows. Therefore, the client must be on the same Windows domain.
            NetTcpBinding b = new NetTcpBinding();
            b.Security.Mode = SecurityMode.Message;
            b.Security.Message.ClientCredentialType = MessageCredentialType.Windows;

            // Set a Type variable for use when constructing the endpoint.
            Type c = typeof(ICalculator);

            // Create a base address for the service.
            Uri tcpBaseAddress =
                new Uri("net.tcp://machineName.Domain.Contoso.com:8036/serviceName");
            // The base address is in an array of URI objects.
            Uri[] baseAddresses = new Uri[] { tcpBaseAddress };
            // Create the ServiceHost with type and base addresses.
            ServiceHost sh = new ServiceHost(typeof(CalculatorClient), baseAddresses);

            // Add an endpoint to the service using the service type and binding.
            sh.AddServiceEndpoint(c, b, "");
            sh.Open();
            string address = sh.Description.Endpoints[0].ListenUri.AbsoluteUri;
            Console.WriteLine("Listening @ {0}", address);
            Console.WriteLine("Press enter to close the service");
            Console.ReadLine();
            //</snippet1>
        }

        private void SecureHttp()
        {
 //<snippet2>
            // Create a WSHttpBinding and set its security properties. The
            // security mode is Message, and the client is authenticated with 
            // a certificate.
            EndpointAddress ea = new EndpointAddress("http://contoso.com/");
            WSHttpBinding b = new WSHttpBinding();
            b.Security.Mode = SecurityMode.Message;
            b.Security.Message.ClientCredentialType =
                MessageCredentialType.Certificate;

// <snippet3>
            // Create the client with the binding and EndpointAddress.
            CalculatorClient calcClient = new CalculatorClient(b, ea);

            // Set the client credential value to a valid certificate.
            calcClient.ClientCredentials.ClientCertificate.SetCertificate(
                StoreLocation.CurrentUser, 
                StoreName.TrustedPeople, 
                X509FindType.FindBySubjectName, 
                "client.com");
// </snippet3>

// <snippet4>
           // Configure the proxy with 
           // (username,password).
           calcClient.ClientCredentials.UserName.UserName = "username";
           calcClient.ClientCredentials.UserName.Password = "changethispassword";
// </snippet4>

            // Use the object returned by the property 
            // to configure the impersonation level.

// <snippet5>
            // Create a client object with the given client endpoint configuration.
           CalculatorClient client = new CalculatorClient();
          try
            {
                client.ClientCredentials.Windows.AllowedImpersonationLevel 
                    = TokenImpersonationLevel.Impersonation;
            }
            catch (TimeoutException timeProblem)
            {
              Console.WriteLine("The service operation timed out. " + timeProblem.Message);
              Console.ReadLine();
              client.Abort();
            }
            catch (CommunicationException commProblem)
            {
              Console.WriteLine("There was a communication problem. " + commProblem.Message + commProblem.StackTrace);
              Console.ReadLine();
              client.Abort();
            }
// </snippet5>

// </snippet2>
        }
    }


    //------------------------------------------------------------------------------
    // <auto-generated>
    //     This code was generated by a tool.
    //     Runtime Version:2.0.50727.42
    //
    //     Changes to this file may cause incorrect behavior and will be lost if
    //     the code is regenerated.
    // </auto-generated>
    //------------------------------------------------------------------------------



//    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://Microsoft.ServiceModel.Samples", ConfigurationName = "ICalculator")]
    public interface ICalculator
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://Microsoft.ServiceModel.Samples/ICalculator/Add", ReplyAction = "http://Microsoft.ServiceModel.Samples/ICalculator/AddResponse")]
        double Add(double n1, double n2);
    }

    // [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface ICalculatorChannel : ICalculator, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    // [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public class CalculatorClient : System.ServiceModel.ClientBase<ICalculator>, ICalculator
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

        public double Add(double n1, double n2)
        {
            return base.Channel.Add(n1, n2);
        }
    }

}


