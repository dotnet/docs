using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.Threading;
namespace Microsoft.ServiceModel.Samples
{
	class Snippets
	{
        public static void Snippet2()
        {
            Uri baseAddress = new Uri("http://localhost:8000/ServiceModelSamples/service");

            // Create a ServiceHost for the CalculatorService type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
            {
                // <Snippet2>
                string info = "";

                InstanceContext instanceContext = new InstanceContext(serviceHost);
                info += "    " + "State: " + instanceContext.State.ToString() + "\n";
                info += "    " + "ManualFlowControlLimit: " + instanceContext.ManualFlowControlLimit.ToString() + "\n";
                info += "    " + "HashCode: " + instanceContext.GetHashCode().ToString() + "\n";

                Console.WriteLine(info);
                // </Snippet2>
            }
        }

        public static void Snippet3()
        {
            // <Snippet3>
            Uri baseAddress = new Uri("http://localhost:8000/ServiceModelSamples/service");
            CalculatorService service = new CalculatorService();
            ServiceHost serviceHost = new ServiceHost(service, baseAddress);
            InstanceContext instanceContext = new InstanceContext(serviceHost,service);

            string info = "";
            info += "    " + "State: " + instanceContext.State.ToString() + "\n";
            info += "    " + "ManualFlowControlLimit: " + instanceContext.ManualFlowControlLimit.ToString() + "\n";
            info += "    " + "HashCode: " + instanceContext.GetHashCode().ToString() + "\n";
            Console.WriteLine(info);
            // </Snippet3>
        }

        public static void Snippet4()
        {
            // <Snippet4>
            Uri baseAddress = new Uri("http://localhost:8000/ServiceModelSamples/service");
            CalculatorService service = new CalculatorService();
            ServiceHost serviceHost = new ServiceHost(service, baseAddress);
            InstanceContext instanceContext = new InstanceContext(serviceHost, service);

            IExtensionCollection<InstanceContext> extensions = instanceContext.Extensions;
            // </Snippet4>
        }

        public static void Snippet5()
        {
            // <Snippet5>
            Uri baseAddress = new Uri("http://localhost:8000/ServiceModelSamples/service");
            CalculatorService service = new CalculatorService();
            ServiceHost serviceHost = new ServiceHost(service, baseAddress);
            InstanceContext instanceContext = new InstanceContext(serviceHost, service);

            ServiceHost host = (ServiceHost) instanceContext.Host;
            // </Snippet5>
        }

        public static void Snippet6()
        {
            // <Snippet6>
            Uri baseAddress = new Uri("http://localhost:8000/ServiceModelSamples/service");

            // Create a ServiceHost for the CalculatorService type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
            {
                serviceHost.Open();
                OperationContext operationContext = OperationContext.Current;
                InstanceContext instanceContext = operationContext.InstanceContext;
                ICollection<IChannel> channels = instanceContext.IncomingChannels;
            }
            // </Snippet6>
        }

        public static void Snippet8()
        {
            // <Snippet8>
            Uri baseAddress = new Uri("http://localhost:8000/ServiceModelSamples/service");

            // Create a ServiceHost for the CalculatorService type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
            {
                serviceHost.Open();
                OperationContext operationContext = OperationContext.Current;
                InstanceContext instanceContext = operationContext.InstanceContext;
                instanceContext.ReleaseServiceInstance();
            }
            // </Snippet8>
        }

        public static void Snippet9()
        {
            // <Snippet9>
            Uri baseAddress = new Uri("http://localhost:8000/ServiceModelSamples/service");

            // Create a ServiceHost for the CalculatorService type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
            {
                serviceHost.Open();
                OperationContext operationContext = OperationContext.Current;
                InstanceContext instanceContext = operationContext.InstanceContext;
                instanceContext.ManualFlowControlLimit = 100;
            }
            // </Snippet9>
        }

        public static void Snippet10()
        {
            // <Snippet10>
            Uri baseAddress = new Uri("http://localhost:8000/ServiceModelSamples/service");

            // Create a ServiceHost for the CalculatorService type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
            {
                serviceHost.Open();
                OperationContext operationContext = OperationContext.Current;
                InstanceContext instanceContext = operationContext.InstanceContext;
                CalculatorService service = (CalculatorService) instanceContext.GetServiceInstance();
            }
            // </Snippet10>
        }

        public static void Snippet11()
        {
            Message msg = Message.CreateMessage(MessageVersion.Default, "SomeAction");
            // <Snippet11>
            Uri baseAddress = new Uri("http://localhost:8000/ServiceModelSamples/service");

            // Create a ServiceHost for the CalculatorService type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
            {
                serviceHost.Open();
                OperationContext operationContext = OperationContext.Current;
                InstanceContext instanceContext = operationContext.InstanceContext;
                CalculatorService service = (CalculatorService)instanceContext.GetServiceInstance(msg);
            }
            // </Snippet11>
        }

        public static void Snippet12()
        {
            // <Snippet12>
            Uri baseAddress = new Uri("http://localhost:8000/ServiceModelSamples/service");

            // Create a ServiceHost for the CalculatorService type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
            {
                serviceHost.Open();
                OperationContext operationContext = OperationContext.Current;
                InstanceContext instanceContext = operationContext.InstanceContext;
                instanceContext.IncrementManualFlowControlLimit(100);
            }
            // </Snippet12>
        }

        public static void Snippet13()
        {
            // <Snippet13>
            Uri baseAddress = new Uri("http://localhost:8000/ServiceModelSamples/service");

            // Create a ServiceHost for the CalculatorService type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
            {
                serviceHost.Open();
                OperationContext operationContext = OperationContext.Current;
                InstanceContext instanceContext = operationContext.InstanceContext;
                SynchronizationContext syncCon = instanceContext.SynchronizationContext;
            }
            // </Snippet13>
        }
	}
}
