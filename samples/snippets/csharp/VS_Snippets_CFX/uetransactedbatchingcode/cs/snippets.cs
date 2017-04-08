using System;

using System.ServiceModel.Channels;
using System.Configuration;
using System.Messaging;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Microsoft.ServiceModel.Samples
{
    public class Snippets
    {
        public static void Snippet2()
        {
            // Get MSMQ queue name from appsettings in configuration.
            string queueName = ConfigurationManager.AppSettings["queueName"];

            // Create the transacted MSMQ queue if necessary.
            if (!MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);

            Uri baseAddress = new Uri("http://localhost:8000/ServiceModelSamples/service");

            // Create a ServiceHost for the CalculatorService type.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
            {
                // <Snippet2>
                ServiceEndpoint endpoint;
                endpoint = serviceHost.AddServiceEndpoint(typeof(IQueueCalculator), new NetMsmqBinding(),"net.msmq://localhost/private/ServiceModelSamples");
                TransactedBatchingBehavior batchBehavior = new TransactedBatchingBehavior(10);
                batchBehavior.MaxBatchSize = 100;
                endpoint.Behaviors.Add(new TransactedBatchingBehavior(10));
                // </Snippet2>

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

        public static void Snippet3()
        {
            // Get MSMQ queue name from appsettings in configuration.
            string queueName = ConfigurationManager.AppSettings["queueName"];

            // Create the transacted MSMQ queue if necessary.
            if (!MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);

            Uri baseAddress = new Uri("http://localhost:8000/ServiceModelSamples/service");

            // Create a ServiceHost for the CalculatorService type.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
            {
                // <Snippet3>
                ServiceEndpoint endpoint;
                endpoint = serviceHost.AddServiceEndpoint(typeof(IQueueCalculator), new NetMsmqBinding(), "net.msmq://localhost/private/ServiceModelSamples");
                TransactedBatchingBehavior batchBehavior = new TransactedBatchingBehavior(10);
                              batchBehavior.MaxBatchSize = 100;
                endpoint.Behaviors.Add(new TransactedBatchingBehavior(10));
                // </Snippet3>

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
            // </Snippet0>
        }

    }
}
