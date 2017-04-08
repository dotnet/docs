using System;
using System.ServiceModel.Channels;
using System.Configuration;
using System.Messaging;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    // <Snippet10>
    // This is the hosting application. This code can appear directly in the service class as well.
    class HostApp
    {
        // Host the service within this EXE console application.
        public static void Main()
        {
            // <Snippet3>
            // Get MSMQ queue name from appsettings in configuration.
            string queueName = ConfigurationManager.AppSettings["queueName"];

            // Create the transacted MSMQ queue if necessary.
            if (!MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);
            // </Snippet3>

            // <Snippet5>
            // Get the base address that is used to listen for WS-MetaDataExchange requests.
            // This is useful to generate a proxy for the client.
            string baseAddress = ConfigurationManager.AppSettings["baseAddress"];

            // Create a ServiceHost for the CalculatorService type.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), new Uri(baseAddress)))
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
            // </Snippet5>
        }
    }
    // </Snippet10>
}
