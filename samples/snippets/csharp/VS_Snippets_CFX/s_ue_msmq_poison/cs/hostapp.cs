using System;
using System.ServiceModel.Channels;
using System.Configuration;
using System.Messaging;
using System.ServiceModel;
using System.Transactions;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.ServiceModel.Samples

{
    class HostApp
    {
        // This sample only runs on Windows Vista.
        // Host the service within this EXE console application.
        public static void Main()
        {
            // Get the MSMQ queue name from appsettings in configuration.
            string queueName = ConfigurationManager.AppSettings["queueName"];

            // Create the transacted MSMQ queue if necessary.
            if (!MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);

            // Get the base address that is used to listen for WS-MetaDataExchange requests.
            // This is useful to generate a proxy for the client.
            string baseAddress = ConfigurationManager.AppSettings["baseAddress"];

            // Create a ServiceHost for the OrderProcessorService type.
            ServiceHost serviceHost = new ServiceHost(typeof(OrderProcessorService), new Uri(baseAddress));
            try
            {
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
            catch (TimeoutException timeProblem)
            {
              Console.WriteLine("The service operation timed out. " + timeProblem.Message);
              Console.ReadLine();
            }
            catch (CommunicationException commProblem)
            {
              Console.WriteLine("There was a communication problem. " + commProblem.Message + commProblem.StackTrace);
              Console.ReadLine();
            }
        }
    }
}
