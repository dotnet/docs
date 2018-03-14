
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;

using System.ServiceModel.Channels;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Microsoft.ServiceModel.Samples
{
    // Define a service contract.
    [ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
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
    public class CalculatorService : ICalculator
    {
        public double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public double Subtract(double n1, double n2)
        {
            return n1 - n2;
        }

        public double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }

        public double Divide(double n1, double n2)
        {
            return n1 / n2;
        }

        // Host the service within this EXE console application.
        public static void Main()
        {
            // <Snippet1>
            Uri baseAddress = new Uri("http://localhost:8000/servicemodelsamples/service");

            // Create a ServiceHost for the CalculatorService type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
            {
                // <Snippet2>
                // Create a custom binding that contains two binding elements.
                ReliableSessionBindingElement reliableSession = new ReliableSessionBindingElement();
                // </Snippet2>
                reliableSession.Ordered = true;

                HttpTransportBindingElement httpTransport = new HttpTransportBindingElement();
                httpTransport.AuthenticationScheme = System.Net.AuthenticationSchemes.Anonymous;
                httpTransport.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;

                CustomBinding binding = new CustomBinding(reliableSession, httpTransport);

                // Add an endpoint using that binding.
                serviceHost.AddServiceEndpoint(typeof(ICalculator), binding, "");

                // Add a MEX endpoint.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.HttpGetUrl = new Uri("http://localhost:8001/servicemodelsamples");
                serviceHost.Description.Behaviors.Add(smb);
              
                // Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                serviceHost.Close();
            }
            // </Snippet1>
        }
    }
}

	
  

