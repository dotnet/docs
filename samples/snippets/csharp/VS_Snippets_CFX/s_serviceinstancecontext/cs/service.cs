
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;

namespace Microsoft.ServiceModel.Samples
{
    // Define a service contract.
    [ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
    public interface IInstanceContextCalculator
    {
        [OperationContract]
        int Add(int n1, int n2);
        [OperationContract]
        int Subtract(int n1, int n2);
        [OperationContract]
        int Multiply(int n1, int n2);
        [OperationContract]
        int Divide(int n1, int n2);
        [OperationContract]
        string GetInstanceContextInfo();
        [OperationContract]
        void GetIncomingChannels();
    }

    // Service class which implements the service contract.
    public class CalculatorService : IInstanceContextCalculator
    {
        public int Add(int n1, int n2)
        {
            return n1 + n2;
        }

        public int Subtract(int n1, int n2)
        {
            return n1 - n2;
        }

        public int Multiply(int n1, int n2)
        {
            return n1 * n2;
        }

        public int Divide(int n1, int n2)
        {
            return n1 / n2;
        }

        // Obtain information from the InstanceContext and return it as a multi-line string.

        public string GetInstanceContextInfo()
        {
            // <Snippet1>
            string info = "";

            OperationContext operationContext = OperationContext.Current;
            InstanceContext instanceContext = operationContext.InstanceContext;

            info += "    " + "State: " + instanceContext.State.ToString() + "\n";
            info += "    " + "ManualFlowControlLimit: " + instanceContext.ManualFlowControlLimit.ToString() + "\n";
            info += "    " + "HashCode: " + instanceContext.GetHashCode().ToString() + "\n";
                     
            return info;
            // </Snippet1>
        }

        public void GetIncomingChannels()
        {
            // <Snippet6>
            OperationContext operationContext = OperationContext.Current;
            InstanceContext instanceContext = operationContext.InstanceContext;
            ICollection<IChannel> incomingChannels = instanceContext.IncomingChannels;
            // </Snippet6>
        }

        public void GetOutgoingChannels()
        {
            // <Snippet7>
            OperationContext operationContext = OperationContext.Current;
            InstanceContext instanceContext = operationContext.InstanceContext;
            ICollection<IChannel> OutgoingChannels = instanceContext.OutgoingChannels;
            // </Snippet7>
        }

        public static void Main()
        {
            Snippets.Snippet11();

            Uri baseAddress = new Uri("http://localhost:8000/ServiceModelSamples/service");

            // Create a ServiceHost for the CalculatorService type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
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
        }
    }
 
}
