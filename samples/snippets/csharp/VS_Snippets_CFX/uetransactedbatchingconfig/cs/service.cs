
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
    // Added code to write output to the console window
    public class CalculatorService : IQueueCalculator
    {
        [OperationBehavior(TransactionScopeRequired = true)]
        public void Add(double n1, double n2)
        {
            double result = n1 + n2;
            Console.WriteLine("Received Add({0},{1}) - result: {2}", n1, n2, result);
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void Subtract(double n1, double n2)
        {
            double result = n1 - n2;
            Console.WriteLine("Received Subtract({0},{1}) - result: {2}", n1, n2, result);
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            Console.WriteLine("Received Multiply({0},{1}) - result: {2}", n1, n2, result);
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void Divide(double n1, double n2)
        {
            double result = n1 / n2;
            Console.WriteLine("Received Divide({0},{1}) - result: {2}", n1, n2, result);
        }


        // Host the service within this EXE console application.
        public static void Main()
        {
            // Get MSMQ queue name from appsettings in configuration.
            string queueName = ConfigurationManager.AppSettings["queueName"];

            // Create the transacted MSMQ queue if necessary.
            if (!MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);

            // Create a ServiceHost for the CalculatorService type.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService)))
            {
                // Open the ServiceHost to create listeners and start listening for messages.
                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHost to shutdown the service.
                serviceHost.Close();
            }
        }

    }

}
