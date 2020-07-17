// <Snippet10>
// This is the hosting application.

using System;
using System.ServiceModel.Channels;
using System.Configuration;
using System.Messaging;
using System.ServiceModel;
using System.Transactions;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Microsoft.ServiceModel.Samples
{
    class hostApp
    {
        // Host the service within this EXE console application.
        public static void Main()
        {
            // Get MSMQ queue name from appsettings in configuration.
            string queueName = ConfigurationManager.AppSettings["queueName"];

            // <Snippet4>
            // Create the transacted MSMQ queue if necessary.
            if (!MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);
            // </Snippet4>

            // <Snippet6>
            // Create a ServiceHost for the OrderProcessorService type.
            using (ServiceHost serviceHost = new ServiceHost(typeof(OrderProcessorService)))
            {
                // Open the ServiceHost to create listeners and start listening for messages.
                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostB to shutdown the service.
                serviceHost.Close();
            }
            // </Snippet6>
        }
    }
}
// </Snippet10>