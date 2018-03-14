
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;

using System.ServiceModel.Channels;
using System.Configuration;
using System.Messaging;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    // Define a service contract. 
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface IQueueCalculator
    {
        [OperationContract(IsOneWay = true)]
        void Add(double n1, double n2);
        [OperationContract(IsOneWay = true)]
        void Subtract(double n1, double n2);
        [OperationContract(IsOneWay = true)]
        void Multiply(double n1, double n2);
        [OperationContract(IsOneWay = true)]
        void Divide(double n1, double n2);
    }

    // Service class that implements the service contract.
    // Added code to write output to the console window.
    public class CalculatorService : IQueueCalculator
    {
        public void Add(double n1, double n2)
        {
            double result = n1 + n2;
            Console.WriteLine("Received Add({0},{1}) - result: {2}", n1, n2, result);
        }

        public void Subtract(double n1, double n2)
        {
            double result = n1 - n2;
            Console.WriteLine("Received Subtract({0},{1}) - result: {2}", n1, n2, result);
        }

        public void Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            Console.WriteLine("Received Multiply({0},{1}) - result: {2}", n1, n2, result);
        }

        public void Divide(double n1, double n2)
        {
            double result = n1 / n2;
            Console.WriteLine("Received Divide({0},{1}) - result: {2}", n1, n2, result);
        }

        public static void Main()
        {
            // <Snippet0>
            string queueName = @".\private$\ServiceModelSamples";

            if (!MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);

            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService)))
            {
                BinaryMessageEncodingBindingElement encodingBindingElement = new BinaryMessageEncodingBindingElement();
                // <Snippet1>
                MsmqTransportBindingElement transportBindingElement = new MsmqTransportBindingElement();
                // </Snippet1>
                CustomBinding binding = new CustomBinding(encodingBindingElement, transportBindingElement);
                
                serviceHost.AddServiceEndpoint(
                    typeof(IQueueCalculator),
                    binding,
                    "net.msmq://localhost/private/ServiceModelSamples");

                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHost to shutdown the service.
                serviceHost.Close();
                // </Snippet0>
            }
        }

    }

}
