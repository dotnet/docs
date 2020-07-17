
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.IdentityModel.Claims;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.ServiceModel.Samples
{
    // Define a service contract.
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface ICalculator
    {
        [OperationContract]
        double Multiply(double n1, double n2);
    }

    // Service class which implements the service contract.
    public class BackendService : ICalculator
    {

        public double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }

        static void Main()
        {
            // <snippet1>
            // Create a ServiceHost for the CalculatorService type and provide the base address.
            using (ServiceHost host = new ServiceHost(typeof(BackendService)))
            {
                BindingElementCollection bindingElements = new BindingElementCollection();
                bindingElements.Add(SecurityBindingElement.CreateUserNameOverTransportBindingElement());
                bindingElements.Add(new WindowsStreamSecurityBindingElement());
                bindingElements.Add(new TcpTransportBindingElement());
                CustomBinding backendServiceBinding = new CustomBinding(bindingElements);

                host.AddServiceEndpoint(typeof(ICalculator), backendServiceBinding, "BackendService");

                // Open the ServiceHostBase to create listeners and start listening for messages.
                host.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();
                host.Close();
            }
            // </snippet1>
        }
    }

    public class MyUserNamePasswordValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            // ignore the password because it is empty, we trust the facade service to authenticate the client
            // we just accept the username information here so that application gets access to it
            if (null == userName)
            {
                Console.WriteLine("Invalid username");
                throw new SecurityTokenValidationException("Invalid username");
            }
        }
    }
}
