// snippet code for \WSHttpBinding\WSHttpBinding.cs
//<snippet0>
using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Security.Permissions;

// Define a service contract for the calculator. 
[ServiceContract()]
public interface ICalculator
{
    [OperationContract(IsOneWay = false)]
    double Add(double n1, double n2);
    [OperationContract(IsOneWay = false)]
    double Subtract(double n1, double n2);
    [OperationContract(IsOneWay = false)]
    double Multiply(double n1, double n2);
    [OperationContract(IsOneWay = false)]
    double Divide(double n1, double n2);
}

//<snippet3>
public sealed class CustomBindingCreator
{

    public static void snippetSecurity()
    {
        //<Snippet8>
        WSHttpBinding wsHttpBinding = new WSHttpBinding();
        WSHttpSecurity whSecurity = wsHttpBinding.Security;
        //</Snippet8>
    }


    public static void snippetCreateBindingElements()
    {
        //<Snippet9>
        WSHttpBinding wsHttpBinding = new WSHttpBinding();
        BindingElementCollection beCollection = wsHttpBinding.CreateBindingElements();
        //</Snippet9>
    }


    private void snippetCreateMessageSecurity()
    {
        //<Snippet10>
        WSHttpBinding wsHttpBinding = new WSHttpBinding();
        // SecurityBindingElement sbe = wsHttpBinding
        //</Snippet10>
    }

    public static void snippetGetTransport()
    {
        //<Snippet11>
        WSHttpBinding wsHttpBinding = new WSHttpBinding();
        //		TransportBindingElement tbElement = wsHttpBinding.GetTransport();
        //</Snippet11>
    }

    public static void snippetAllowCookies()
    {
        // <Snippet12>
        WSHttpBinding wsHttpBinding = new WSHttpBinding();
        wsHttpBinding.AllowCookies = true;
        // </Snippet12>
    }

    public static Binding GetBinding()
    {
        // <Snippet6>
        // securityMode is Message
        // reliableSessionEnabled is true
        WSHttpBinding binding = new WSHttpBinding(SecurityMode.Message, true);
        binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
        // </Snippet6>

        WSHttpSecurity security = binding.Security;
        return binding;

    }

    public static Binding GetBinding2()
    {
        
        // <Snippet7>
        // The security mode is set to Message.
        WSHttpBinding binding = new WSHttpBinding(SecurityMode.Message);
        binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
        return binding;
        // </Snippet7>

    }

    //<snippet4>
    // This method creates a WSFederationHttpBinding.
    public static WSFederationHttpBinding CreateWSFederationHttpBinding()
    {
        // Create an instance of the WSFederationHttpBinding
        WSFederationHttpBinding b = new WSFederationHttpBinding();

        // Set the security mode to Message
        b.Security.Mode = WSFederationHttpSecurityMode.Message;

        // Set the Algorithm Suite to Basic256Rsa15
        b.Security.Message.AlgorithmSuite = SecurityAlgorithmSuite.Basic256Rsa15;

        // Set NegotiateServiceCredential to true
        b.Security.Message.NegotiateServiceCredential = true;

        // Set IssuedKeyType to Symmetric
        b.Security.Message.IssuedKeyType = SecurityKeyType.SymmetricKey;

        // Set IssuedTokenType to SAML 1.1
        b.Security.Message.IssuedTokenType = "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#samlv1.1";

        // Extract the STS certificate from the certificate store
        X509Store store = new X509Store(StoreName.TrustedPeople, StoreLocation.CurrentUser);
        store.Open(OpenFlags.ReadOnly);
        X509Certificate2Collection certs = store.Certificates.Find(X509FindType.FindByThumbprint, "cd 54 88 85 0d 63 db ac 92 59 05 af ce b8 b1 de c3 67 9e 3f", false);
        store.Close();

        // Create an EndpointIdentity from the STS certificate
        EndpointIdentity identity = EndpointIdentity.CreateX509CertificateIdentity(certs[0]);

        // Set the IssuerAddress using the address of the STS and the previously created EndpointIdentity
        b.Security.Message.IssuerAddress = new EndpointAddress(new Uri("http://localhost:8000/sts/x509"), identity);

        // <Snippet5>
        // Set the IssuerBinding to a WSHttpBinding loaded from config
        b.Security.Message.IssuerBinding = new WSHttpBinding("Issuer");
        // </Snippet5>

        // Set the IssuerMetadataAddress using the metadata address of the STS and the previously created EndpointIdentity
        b.Security.Message.IssuerMetadataAddress = new EndpointAddress(new Uri("http://localhost:8001/sts/mex"), identity);

        // Create a ClaimTypeRequirement
        ClaimTypeRequirement ctr = new ClaimTypeRequirement("http://example.org/claim/c1", false);

        // Add the ClaimTypeRequirement to ClaimTypeRequirements
        b.Security.Message.ClaimTypeRequirements.Add(ctr);

        // Return the created binding
        return b;
    }
    //</snippet4>

}
//</snippet3>

// Service class which implements the service contract. 
public class CalculatorService : ICalculator
{
    public double Add(double n1, double n2)
    {
        double result = n1 + n2; return result;
    }
    public double Subtract(double n1, double n2)
    {
        double result = n1 - n2; return result;
    }
    public double Multiply(double n1, double n2)
    {
        double result = n1 * n2; return result;
    }
    public double Divide(double n1, double n2)
    {
        double result = n1 / n2; return result;
    }


    // Host the service within this EXE console application. 
    public static void Main()
    {
        // Create a WSHttpBinding and set its property values. 
        //<snippet1>
        WSHttpBinding binding = new WSHttpBinding();
        binding.Name = "binding1";
        binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
        binding.Security.Mode = SecurityMode.Message;
        binding.ReliableSession.Enabled = false;
        binding.TransactionFlow = false;
        //</snippet1>
        //Specify a base address for the service endpoint. 
        Uri baseAddress = new Uri(@"http://localhost:8000/servicemodelsamples/service");
        // Create a ServiceHost for the CalculatorService type 
        // and provide it with a base address. 
        ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);
        serviceHost.AddServiceEndpoint(typeof(ICalculator), binding, baseAddress);
        // Open the ServiceHostBase to create listeners 
        // and start listening for messages. 
        serviceHost.Open();
        // The service can now be accessed. 
        Console.WriteLine("The service is ready.");
        Console.WriteLine("Press <ENTER> to terminate service.");
        Console.WriteLine(); Console.ReadLine();
        // Close the ServiceHost to shutdown the service. 
        serviceHost.Close();
    }
}
//</snippet0>