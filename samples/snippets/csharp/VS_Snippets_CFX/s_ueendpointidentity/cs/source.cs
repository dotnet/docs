//  S_UEEndpointIdentity
//
using System;
using System.IdentityModel.Claims;
using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.Threading;
using ClientCalculator;
namespace BasicAuthentication
{
    public class BasicService
    {
        static void Main()
        {
            try
            {

                MessageSecuritWithKerberosAuth.MyService.Run();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.InnerException.Message);
                Console.ReadLine();
            }

        }

        private void ClientConstructor()
        {
            //<snippet0>
            CalculatorClient cc = new CalculatorClient("EndpointConfigurationName");
            //</snippet0>
        }

        public static void Run()
        {
            //<snippet1>
            // Create the binding.
            WSHttpBinding binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType =
                HttpClientCredentialType.Basic;

            // Create the URI for the endpoint.
            Uri httpUri = new Uri("https://localhost/Calculator");

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
            //</snippet1>
        }

        public static void ClientRun()
        {
            //<snippet2>
            // Create the binding.
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.Transport;
            myBinding.Security.Transport.ClientCredentialType =
                HttpClientCredentialType.Basic;

            // Create the endpoint address. Note that the machine name 
            // must match the subject or the DNS field of the X.509 certificate
            // used to authenticate the service. 
            EndpointAddress ea = new
                EndpointAddress("https://machineName/Calculator");

            // Create the client. The code for the calculator 
            // client is not shown here. See the sample applications
            // for examples of the calculator code.
            CalculatorClient cc =
                new CalculatorClient(myBinding, ea);
            // The client must provide a user name and password. The code
            // to return the user name and password is not shown here. Use
            // a database to store the user name and passwords, or use the 
            // ASP.NET Membership provider database.
            cc.ClientCredentials.UserName.UserName = ReturnUsername();
            cc.ClientCredentials.UserName.Password = ReturnPassword();
            try
            {
                // Begin using the client.
                cc.Open();
                Console.WriteLine(cc.Add(100, 11));
                Console.ReadLine();

                // Close the client.
                cc.Close();
            }
            //</snippet2>
            catch (TimeoutException tex)
            {
                Console.WriteLine(tex.Message);
                cc.Abort();
            }
            catch(CommunicationException cex)
            {
                Console.WriteLine(cex.Message);
                cc.Abort();
            }
            finally
            {
                Console.WriteLine("Closed the client");
                Console.ReadLine();
            }
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
namespace EndpointIdentityMethods
{
    public class EndpointIdentityMethods
    {
        //<snippet40>
        // This method creates a WSFederationHttpBinding.
        public static WSFederationHttpBinding CreateWSFederationHttpBinding()
        {
            // Create an instance of the WSFederationHttpBinding.
            WSFederationHttpBinding b = new WSFederationHttpBinding();

            // Set the security mode to Message.
            b.Security.Mode = WSFederationHttpSecurityMode.Message;

            // Set the Algorithm Suite to Basic256Rsa15.
            b.Security.Message.AlgorithmSuite = SecurityAlgorithmSuite.Basic256Rsa15;

            // Set NegotiateServiceCredential to true.
            b.Security.Message.NegotiateServiceCredential = true;

            // Set IssuedKeyType to Symmetric.
            b.Security.Message.IssuedKeyType = SecurityKeyType.SymmetricKey;

            // Set IssuedTokenType to SAML 1.1.
            b.Security.Message.IssuedTokenType = "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#samlv1.1";

            // Extract the STS certificate from the certificate store.
            X509Store store = new X509Store(StoreName.TrustedPeople, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certs = store.Certificates.Find(X509FindType.FindByThumbprint, "cd 54 88 85 0d 63 db ac 92 59 05 af ce b8 b1 de c3 67 9e 3f", false);
            store.Close();

            // Create an EndpointIdentity from the STS certificate.
            EndpointIdentity identity = EndpointIdentity.CreateX509CertificateIdentity(certs[0]);

            // Set the IssuerAddress using the address of the STS and the previously created EndpointIdentity.
            b.Security.Message.IssuerAddress = new EndpointAddress(new Uri("http://localhost:8000/sts/x509"), identity);

            // Set the IssuerBinding to a WSHttpBinding loaded from config
            b.Security.Message.IssuerBinding = new WSHttpBinding("Issuer");

            // Set the IssuerMetadataAddress using the metadata address of the STS and the previously created EndpointIdentity.
            b.Security.Message.IssuerMetadataAddress = new EndpointAddress(new Uri("http://localhost:8001/sts/mex"), identity);

            // Create a ClaimTypeRequirement.
            ClaimTypeRequirement ctr = new ClaimTypeRequirement("http://example.org/claim/c1", false);

            // Add the ClaimTypeRequirement to ClaimTypeRequirements.
            b.Security.Message.ClaimTypeRequirements.Add(ctr);

            // Return the created binding.
            return b;
        }
    }
    //</snippet40>

}

namespace CreateRSAIdentity
{
    // Define a service contract.
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double n1, double n2);
        [OperationContract]
        double Subtract(double n1, double n2);
        [OperationContract]
        double Multiply(double n1, double n2);
        [OperationContract]
        double Divide(double n1, double n2);
    }

    // Service class that implements the service contract.
    // Added code to write output to the console window.
    public class CalculatorService : ICalculator
    {
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            Console.WriteLine("Received Add({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Subtract(double n1, double n2)
        {
            double result = n1 - n2;
            Console.WriteLine("Received Subtract({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            Console.WriteLine("Received Multiply({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Divide(double n1, double n2)
        {
            double result = n1 / n2;
            Console.WriteLine("Received Divide({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        // Host the service within this EXE console application.
        //<snippet41>
        public static void CreateRSAIdentity()
        {
            // Create a ServiceHost for the CalculatorService type. Base Address is supplied in app.config.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService)))
            {
                // The base address is read from the app.config.
                Uri dnsrelativeAddress = new Uri(serviceHost.BaseAddresses[0], "dnsidentity");
                Uri certificaterelativeAddress = new Uri(serviceHost.BaseAddresses[0], "certificateidentity");
                Uri rsarelativeAddress = new Uri(serviceHost.BaseAddresses[0], "rsaidentity");

                // Set the service's X509Certificate to protect the messages.
                serviceHost.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine,
                                                                          StoreName.My,
                                                                          X509FindType.FindBySubjectDistinguishedName,
                                                                          "CN=identity.com, O=Contoso");
                //Cache a reference to the server's certificate.
                X509Certificate2 servercert = serviceHost.Credentials.ServiceCertificate.Certificate;

                //Create endpoints for the service using a WSHttpBinding set for anonymous clients.
                WSHttpBinding wsAnonbinding = new WSHttpBinding(SecurityMode.Message);
                //Clients are anonymous to the service.
                wsAnonbinding.Security.Message.ClientCredentialType = MessageCredentialType.None;
                //Secure conversation (session) is turned off.
                wsAnonbinding.Security.Message.EstablishSecurityContext = false;

                //Create a service endpoint and change its identity to the DNS for an X509 Certificate.
                ServiceEndpoint ep = serviceHost.AddServiceEndpoint(typeof(ICalculator),
                                                                    wsAnonbinding,
                                                                    String.Empty);
                EndpointAddress epa = new EndpointAddress(dnsrelativeAddress, EndpointIdentity.CreateDnsIdentity("identity.com"));
                ep.Address = epa;

                //Create a service endpoint and change its identity to the X509 certificate's RSA key value.
                ServiceEndpoint ep3 = serviceHost.AddServiceEndpoint(typeof(ICalculator), wsAnonbinding, String.Empty);
                EndpointAddress epa3 = new EndpointAddress(rsarelativeAddress, EndpointIdentity.CreateRsaIdentity(servercert));
                ep3.Address = epa3;
             //</snippet41>

           }
        }
        // <snippet42>
        // Utility function to create an EndpointIdentity from a ClaimSet.
        private EndpointIdentity CreateIdentityFromClaimSet(ClaimSet claims)
        {
            foreach (Claim claim in claims.FindClaims(null, Rights.Identity))
            {
                return EndpointIdentity.CreateIdentity(claim);
            }
            return null;
        }
        // </snippet42>

        // Method for retreving a named certificate from a particular store.
        static X509Certificate2 GetServerCertificate(string name)
        {
            X509Store store = new X509Store(StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certs = store.Certificates.Find(X509FindType.FindBySubjectDistinguishedName, name, false);
            store.Close();
            if (certs.Count == 0)
                throw new Exception("You have not installed the certificates. Run setup.bat for this project");
            if (certs.Count > 1)
                throw new Exception("Duplicate certificates found in the store");
            return certs[0];

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
            //<snippet3>
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
            //</snippet3>


        }

        public static void RunClient()
        {
            //<snippet4>
            // Create the binding.
            NetTcpBinding myBinding = new NetTcpBinding();
            myBinding.Security.Mode = SecurityMode.Transport;
            myBinding.Security.Transport.ClientCredentialType =
                TcpClientCredentialType.Windows;

            // Create the endpoint address.
            EndpointAddress myEndpointAddress = new
                EndpointAddress("net.tcp://localhost:8008/Calculator");

            // Create the client. The code for the calculator client 
            // is not shown here. See the sample applications
            // for examples of the calculator code.	
            CalculatorClient cc =
                new CalculatorClient(myBinding, myEndpointAddress);
            try
            {
                cc.Open();

                // Begin using the client.
                Console.WriteLine(cc.Add(100, 11));
                Console.ReadLine();

                // Close the client.
                cc.Close();
            }
            //</snippet4>
                        catch (TimeoutException tex)
            {
                Console.WriteLine(tex.Message);
                cc.Abort();
            }
            catch(CommunicationException cex)
            {
                Console.WriteLine(cex.Message);
                cc.Abort();
            }
            finally
            {
                Console.WriteLine("Closed the client");
                Console.ReadLine();
            }

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
            //<snippet5>
            // Create the binding.
            WSHttpBinding binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType =
                  HttpClientCredentialType.None;

            // Create the URI for the endpoint.
            Uri httpUri = new Uri("https://localhost/Calculator");

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
            //</snippet5>
        }

        public static void RunClient()
        {
            //<snippet6>            
            // Create the binding.
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.Transport;
            myBinding.Security.Transport.ClientCredentialType =
                HttpClientCredentialType.None;

            // Create the endpoint address. Note that the machine name 
            // must match the subject or DNS field of the X.509 certificate
            // used to authenticate the service. 
            EndpointAddress ea = new
                EndpointAddress("https://machineName/Calculator");

            // Create the client. The code for the calculator 
            // client is not shown here. See the sample applications
            // for examples of the calculator code.
            CalculatorClient cc =
                new CalculatorClient(myBinding, ea);

            // Begin using the client.
            try
            {
                cc.Open();
                Console.WriteLine(cc.Add(100, 1111));

                // Close the client.
                cc.Close();
            }
            //</snippet6>

            catch (TimeoutException tex)
            {
                Console.WriteLine(tex.Message);
                cc.Abort();
            }
            catch(CommunicationException cex)
            {
                Console.WriteLine(cex.Message);
                cc.Abort();
            }
            finally
            {
                Console.WriteLine("Closed the client");
                Console.ReadLine();
            }

        }
    }
}

namespace SecuredTranserUsingCertificates
{
    public class MyService
    {
        public static void Run()
        {
            //<snippet7>
            // Create the binding. 
            WSHttpBinding binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.
                Certificate;

            // Create the URI for the endpoint.
            Uri httpUri = new Uri("https://localhost/Calculator");

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
            //</snippet7>
        }

        private void ClientRun()
        {
            //<snippet14>
            // Create the binding.
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.Transport;
            myBinding.Security.Transport.ClientCredentialType =
                HttpClientCredentialType.Certificate;

            // Create the endpoint address. Note that the machine name 
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
            cc.ClientCredentials.ClientCertificate.SetCertificate(
                StoreLocation.CurrentUser,
                StoreName.My,
                X509FindType.FindBySubjectName,
                "contoso.com");

            // Begin using the client.
            Console.WriteLine(cc.Add(100, 1111));
            try
            {
                cc.Open();

                // Close the client.
                cc.Close();
            }
            //</snippet14>
            catch (TimeoutException tex)
            {
                Console.WriteLine(tex.Message);
                cc.Abort();
            }
            catch (CommunicationException cex)
            {
                Console.WriteLine(cex.Message);
                cc.Abort();
            }
            finally
            {
                Console.WriteLine("Closed the client");
                Console.ReadLine();
            }

        }
    }
}

namespace SecuredUsingMessageSecurityWithAnonClient
{
    public class SecureService
    {
        public static void Run()
        {
            //<snippet8>
            // Create the binding. 
            WSHttpBinding binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.Message;
            binding.Security.Message.ClientCredentialType =
                MessageCredentialType.None;

            // Create the URI for the endpoint.
            Uri httpUri = new Uri("http://localhost/Calculator");

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
            //</snippet8>
        }

        private void ClientRun()
        {
            //<snippet15>
            // Create the binding.
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.Message;
            myBinding.Security.Message.ClientCredentialType =
                MessageCredentialType.None;

            // Create the endpoint address. 
            EndpointAddress ea = new
                EndpointAddress("http://localhost/Calculator");

            // Create the client. 
            CalculatorClient cc =
                new CalculatorClient(myBinding, ea);

            // Begin using the client.
            try
            {
                cc.Open();
                Console.WriteLine(cc.Add(200, 1111));
                Console.ReadLine();

                // Close the client.
                cc.Close();
            }
            //</snippet15>
            catch (TimeoutException tex)
            {
                Console.WriteLine(tex.Message);
                cc.Abort();
            }
            catch (CommunicationException cex)
            {
                Console.WriteLine(cex.Message);
                cc.Abort();
            }
            finally
            {
                Console.WriteLine("Closed the client");
                Console.ReadLine();
            }
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
            //<snippet9>
            // Create the binding.
            WSHttpBinding binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.Message;
            binding.Security.Message.ClientCredentialType =
                 MessageCredentialType.UserName;

            // Create the URI for the endpoint.
            Uri httpUri = new Uri("http://localhost/Calculator");

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
            //</snippet9>

        }

        private void ClientRun()
        {
            //<snippet16>
            // Create the binding.
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.Message;
            myBinding.Security.Message.ClientCredentialType =
                MessageCredentialType.UserName;

            // Create the endpoint address. 
            EndpointAddress ea = new
                EndpointAddress("http://machineName/Calculator");

            // Create the client. 
            CalculatorClient cc =
                new CalculatorClient(myBinding, ea);

            // Set the user name and password. The code to 
            // return the user name and password is not shown here. Use
            // an interface to query the user for the information.
            cc.ClientCredentials.UserName.UserName = ReturnUsername();
            cc.ClientCredentials.UserName.Password = ReturnPassword();

            // Begin using the client.
            try
            {
                cc.Open();
                Console.WriteLine(cc.Add(200, 1111));
                Console.ReadLine();

                // Close the client.
                cc.Close();
            }
            //</snippet16>
            catch (TimeoutException tex)
            {
                Console.WriteLine(tex.Message);
                cc.Abort();
            }
            catch (CommunicationException cex)
            {
                Console.WriteLine(cex.Message);
                cc.Abort();
            }
            finally
            {
                Console.WriteLine("Closed the client");
                Console.ReadLine();
            }

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
            //<snippet10>
            // Create the binding.
            WSHttpBinding binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.Message;
            binding.Security.Message.ClientCredentialType =
                 MessageCredentialType.Certificate;

            // Create the URI for the endpoint.
            Uri httpUri = new Uri("http://localhost/Calculator");

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
            //</snippet10>


        }
        private void ClientRun()
        {
            //<snippet17>
            // Create the binding.
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.Message;
            myBinding.Security.Message.ClientCredentialType =
                MessageCredentialType.Certificate;

            // Create the endpoint address. 
            EndpointAddress ea = new
                EndpointAddress("http://machineName/Calculator");

            // Create the client. 
            CalculatorClient cc =
                new CalculatorClient(myBinding, ea);

            // Specify a certificate to use for authenticating the client.
            cc.ClientCredentials.ClientCertificate.SetCertificate(
                StoreLocation.CurrentUser,
                StoreName.My,
                X509FindType.FindBySubjectName,
                "Cohowinery.com");

            // Begin using the client.
            try
            {
                cc.Open();
                Console.WriteLine(cc.Add(200, 1111));
                Console.ReadLine();

                // Close the client.
                cc.Close();
            }
            //</snippet17>
            catch (TimeoutException tex)
            {
                Console.WriteLine(tex.Message);
                cc.Abort();
            }
            catch (CommunicationException cex)
            {
                Console.WriteLine(cex.Message);
                cc.Abort();
            }
            finally
            {
                Console.WriteLine("Closed the client");
                Console.ReadLine();
            }
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
            //<snippet11>
            // Create the binding.
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Mode = SecurityMode.Message;
            binding.Security.Message.ClientCredentialType =
                MessageCredentialType.Windows;

            // Create the URI for the endpoint.
            Uri netTcpUri = new Uri("net.tcp://localhost:8008/Calculator");

            // Create the service host and add an endpoint.
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
            //</snippet11>


        }

        private void ClientRun()
        {
            //<snippet18>
            // Create the binding.
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.Message;
            myBinding.Security.Message.ClientCredentialType =
                MessageCredentialType.Windows;

            // Create the endpoint address. 
            EndpointAddress ea = new
                EndpointAddress("net.tcp://machineName:8008/Calculator");

            // Create the client. 
            CalculatorClient cc =
                new CalculatorClient(myBinding, ea);

            // Begin using the client.
            try
            {
                cc.Open();
                Console.WriteLine(cc.Add(200, 1111));
                Console.ReadLine();

                // Close the client.
                cc.Close();
            }
            //</snippet18>
            catch (TimeoutException tex)
            {
                Console.WriteLine(tex.Message);
                cc.Abort();
            }
            catch (CommunicationException cex)
            {
                Console.WriteLine(cex.Message);
                cc.Abort();
            }
            finally
            {
                Console.WriteLine("Closed the client");
                Console.ReadLine();
            }

        }
    }
}

namespace MessageSecuritWithKerberosAuth
{
    using ServiceModel;
    public class MyService
    {
        public static void Run()
        {
            //<snippet12>
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
            Uri httpUri = new Uri("http://localhost/Calculator");

            // Create the EndpointAddress with the SPN for the Identity.
            EndpointAddress ea = new EndpointAddress(httpUri,
                EndpointIdentity.CreateSpnIdentity("service_spn_name"));

            // Get the contract from the ICalculator interface (not shown here).
            // See the sample applications for an example of the ICalculator.
            ContractDescription contract = ContractDescription.GetContract(
                typeof(ICalculator));

            // Create a new ServiceEndpoint.
            ServiceEndpoint se = new ServiceEndpoint(contract, binding, ea);

            // Add the service endpoint to the service.
            myServiceHost.Description.Endpoints.Add(se);

            // Open the service.
            myServiceHost.Open();
            Console.WriteLine("Listening...");
            Console.ReadLine();

            // Close the service. 
            myServiceHost.Close();
            //</snippet12>
        }

        private void ClientRun()
        {
            //<snippet19>
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
            // is published as the <servicePrincipalName> element under the
            // <identity> element.
            EndpointAddress ea = new EndpointAddress(
            new Uri("http://machineName/Calculator"),
            EndpointIdentity.CreateSpnIdentity("service_spn_name"));

            // Create the client. 
            CalculatorClient cc =
                new CalculatorClient(myBinding, ea);

            // Begin using the client.

            try
            {
                cc.Open();
                Console.WriteLine(cc.Add(200, 1111));
                Console.ReadLine();

                // Close the client.
                cc.Close();
            }
            //</snippet19>
            catch (TimeoutException tex)
            {
                Console.WriteLine(tex.Message);
                cc.Abort();
            }
            catch (CommunicationException cex)
            {
                Console.WriteLine(cex.Message);
                cc.Abort();
            }
            finally
            {
                Console.WriteLine("Closed the client");
                Console.ReadLine();
            }

        }
    }
}
//<snippet30>
namespace TestPrincipalPermission
{
    class PrincipalPermissionModeWindows
    {

        [ServiceContract]
        interface ISecureService
        {
            [OperationContract]
            string Method1();
        }

        class SecureService : ISecureService
        {
            [PrincipalPermission(SecurityAction.Demand, Role = "everyone")]
            public string Method1()
            {
                return String.Format("Hello, \"{0}\"", Thread.CurrentPrincipal.Identity.Name);
            }
        }

        public void Run()
        {
            Uri serviceUri = new Uri(@"http://localhost:8006/Service");
            ServiceHost service = new ServiceHost(typeof(SecureService));
            service.AddServiceEndpoint(typeof(ISecureService), GetBinding(), serviceUri);
            service.Authorization.PrincipalPermissionMode = PrincipalPermissionMode.UseAspNetRoles;
            service.Open();

            EndpointAddress sr = new EndpointAddress(
                serviceUri, EndpointIdentity.CreateUpnIdentity(WindowsIdentity.GetCurrent().Name));
            ChannelFactory<ISecureService> cf = new ChannelFactory<ISecureService>(GetBinding(), sr);
            ISecureService client = cf.CreateChannel();
            Console.WriteLine("Client received response from Method1: {0}", client.Method1());
            ((IChannel)client).Close();
            Console.ReadLine();
            service.Close();

        }

        public static Binding GetBinding()
        {
            WSHttpBinding binding = new WSHttpBinding(SecurityMode.Message);
            binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
            return binding;
        }
    }
}
//</snippet30>

namespace SecuredUsingMessageSecurityWithInteroperableCertClient
{
    using ServiceModel;
    public class MyService
    {
        public static void Run()
        {
            //<snippet13>
            // Create the binding. 
            WSHttpBinding binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.Message;
            binding.Security.Message.ClientCredentialType =
                MessageCredentialType.Certificate;
            binding.Security.Message.NegotiateServiceCredential = false;
            binding.Security.Message.EstablishSecurityContext = false;

            // Create the URI for the endpoint.
            Uri httpUri = new Uri("http://localhost/Calculator");

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
            //</snippet13>
        }
        private void ClientRun()
        {
            //<snippet20>
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
                EndpointAddress("http://machineName/Calculator");

            // Create the client. 
            CalculatorClient cc =
                new CalculatorClient(myBinding, ea);

            // Specify a certificate to use for authenticating the client.
            cc.ClientCredentials.ClientCertificate.SetCertificate(
                StoreLocation.CurrentUser,
                StoreName.My,
                X509FindType.FindBySubjectName,
                "Cohowinery.com");

            // Specify a default certificate for the service.
            cc.ClientCredentials.ServiceCertificate.SetDefaultCertificate(
                StoreLocation.CurrentUser,
                StoreName.TrustedPeople,
                X509FindType.FindBySubjectName,
                "Contoso.com");

            // Begin using the client.
            try
            {
                cc.Open();
                Console.WriteLine(cc.Add(200, 1111));
                Console.ReadLine();

                // Close the client.
                cc.Close();
            }
            //</snippet20>
            catch (TimeoutException tex)
            {
                Console.WriteLine(tex.Message);
                cc.Abort();
            }
            catch (CommunicationException cex)
            {
                Console.WriteLine(cex.Message);
                cc.Abort();
            }
            finally
            {
                Console.WriteLine("Closed the client");
                Console.ReadLine();
            }

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
