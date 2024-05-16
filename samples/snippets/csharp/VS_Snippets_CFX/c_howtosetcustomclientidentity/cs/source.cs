using System;
using System.Security.Cryptography.X509Certificates;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.Security.Permissions;

namespace Microsoft.ServiceModel.Samples
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public class CalculatorClient : System.ServiceModel.ClientBase<ICalculator>, ICalculator
    {
        static void Main()
        {
            // ...
        }

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
    class Client
    {

        public static void CallServiceCustomClientIdentity(string endpointName)
        {
            // Create a custom binding that sets a custom IdentityVerifier.
            Binding customSecurityBinding = CreateCustomSecurityBinding();
            // Call the service with DNS identity, setting a custom EndpointIdentity that checks that the certificate
            // returned from the service contains an organization name of Contoso in the subject name; that is, O=Contoso.
            EndpointAddress serviceAddress = new EndpointAddress(new Uri("http://localhost:8003/servicemodelsamples/service/dnsidentity"),
                                                                  new OrgEndpointIdentity("O=Contoso"));
            //<snippet4>
            using (CalculatorClient client = new CalculatorClient(customSecurityBinding, serviceAddress))
            {
                //</snippet4>
                client.ClientCredentials.ServiceCertificate.SetDefaultCertificate(StoreLocation.CurrentUser,
                                                                                  StoreName.TrustedPeople,
                                                                                  X509FindType.FindBySubjectDistinguishedName,
                                                                                  "CN=identity.com, O=Contoso");
                // Setting the certificateValidationMode to PeerOrChainTrust means that if the certificate
                // is in the user's Trusted People store, then it will be trusted without performing a
                // validation of the certificate's issuer chain. This setting is used here for convenience so that the
                // sample can be run without having to have certificates issued by a certificate authority (CA).
                // This setting is less secure than the default, ChainTrust. The security implications of this
                // setting should be carefully considered before using PeerOrChainTrust in production code.
                client.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.PeerOrChainTrust;

                Console.WriteLine("Calling Endpoint: {0}", endpointName);
                // Call the Add service operation.
                double value1 = 100.00D;
                double value2 = 15.99D;
                double result = client.Add(value1, value2);
                Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);
                Console.WriteLine();

                // Call the Subtract service operation.
                value1 = 145.00D;
                value2 = 76.54D;
                result = client.Subtract(value1, value2);
                Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);
            }
        }

        // Create a custom binding using a WsHttpBinding.
        //<snippet3>
        public static Binding CreateCustomSecurityBinding()
        {
            WSHttpBinding binding = new WSHttpBinding(SecurityMode.Message);
            //Clients are anonymous to the service.
            binding.Security.Message.ClientCredentialType = MessageCredentialType.None;
            //Secure conversation is turned off for simplification. If secure conversation is turned on, then
            //you also need to set the IdentityVerifier on the secureconversation bootstrap binding.
            binding.Security.Message.EstablishSecurityContext = false;

            // Get the SecurityBindingElement and cast to a SymmetricSecurityBindingElement to set the IdentityVerifier.
            BindingElementCollection outputBec = binding.CreateBindingElements();
            SymmetricSecurityBindingElement ssbe = (SymmetricSecurityBindingElement)outputBec.Find<SecurityBindingElement>();

            //Set the Custom IdentityVerifier.
            ssbe.LocalClientSettings.IdentityVerifier = new CustomIdentityVerifier();

            return new CustomBinding(outputBec);
        }
        //</snippet3>
    }

    // This custom EndpointIdentity stores an organization name as a string value.
    //<snippet6>
    public class OrgEndpointIdentity : EndpointIdentity
    {
        private string orgClaim;
        public OrgEndpointIdentity(string orgName)
        {
            orgClaim = orgName;
        }

        public string OrganizationClaim
        {
            get { return orgClaim; }
            set { orgClaim = value; }
        }
    }
    //</snippet6>

    // This custom IdentityVerifier uses the supplied OrgEndpointIdentity to check that
    // X.509 certificate's distinguished name claim contains the organization name; for example, O=Contoso.
    //<snippet5>
    class CustomIdentityVerifier : IdentityVerifier
    {
        //<snippet1>
        public override bool CheckAccess(EndpointIdentity identity, AuthorizationContext authContext)
        {
            bool returnvalue = false;

            foreach (ClaimSet claimset in authContext.ClaimSets)
            {
                foreach (Claim claim in claimset)
                {
                    if (claim.ClaimType == "http://schemas.microsoft.com/ws/2005/05/identity/claims/x500distinguishedname")
                    {
                        X500DistinguishedName name = (X500DistinguishedName)claim.Resource;
                        if (name.Name.Contains(((OrgEndpointIdentity)identity).OrganizationClaim))
                        {
                            Console.WriteLine("Claim Type: {0}", claim.ClaimType);
                            Console.WriteLine("Right: {0}", claim.Right);
                            Console.WriteLine("Resource: {0}", claim.Resource);
                            Console.WriteLine();
                            returnvalue = true;
                        }
                    }
                }
            }
            return returnvalue;
        }
        //</snippet1>

        //<snippet2>
        public override bool TryGetIdentity(EndpointAddress reference, out EndpointIdentity identity)
        {
            return IdentityVerifier.CreateDefault().TryGetIdentity(reference, out identity);
        }
        //</snippet2>
    }
    //</snippet5>

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

    // This service class implements the service contract.
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
    }
}

namespace part2
{
        //<snippet7>
    public class CustomIdentityVerifier : IdentityVerifier
    {
        // Code to be added.
        public override bool CheckAccess(EndpointIdentity identity, AuthorizationContext authContext)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override bool TryGetIdentity(EndpointAddress reference, out EndpointIdentity identity)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
    //</snippet7>
}
