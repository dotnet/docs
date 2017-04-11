using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.MsmqIntegration;
using System.Runtime.Serialization;
using System.Configuration;
using System.Messaging;

namespace Microsoft.ServiceModel.Samples
{
    class Snippets
    {
        public static void Snippet3()
        {
            // Get MSMQ queue name from appsettings in configuration.
            string queueName = @".\private$\Orders";

            // Create the transacted MSMQ queue if necessary.
            if (!MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);

            // Create a ServiceHost for the CalculatorService type.
            using (ServiceHost serviceHost = new ServiceHost(typeof(OrderProcessorService)))
            {
                // <Snippet3>
                MsmqIntegrationBindingElement msmqBindingElement = new MsmqIntegrationBindingElement();
                msmqBindingElement.SerializationFormat = MsmqMessageSerializationFormat.Binary;
                // </Snippet3>

                CustomBinding binding = new CustomBinding(msmqBindingElement);

                serviceHost.AddServiceEndpoint(typeof(IOrderProcessor), binding, @"msmq.formatname:DIRECT=OS:.\private$\Orders");

                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.ReadLine();
            }
           
        }

        public static void Snippet4()
        {
            // <Snippet4>
            MsmqIntegrationBindingElement msmqBindingElement = new MsmqIntegrationBindingElement();
            msmqBindingElement.TargetSerializationTypes = new Type[] { typeof(string) };
            // </Snippet4>
        }

        public static void Snippet5()
        {
            // <Snippet5>
            MsmqIntegrationBindingElement msmqBindingElement = new MsmqIntegrationBindingElement();
            MsmqIntegrationBindingElement clonedElement = (MsmqIntegrationBindingElement)msmqBindingElement.Clone();
            // </Snippet5>
        }

        public static void Snippet6()
        {
            MsmqIntegrationBindingElement msmqBindingElement = new MsmqIntegrationBindingElement();
            CustomBinding binding = new CustomBinding(msmqBindingElement);

            BindingParameterCollection bindingParameterCollection = new BindingParameterCollection();      
                
            BindingContext bindingContext = new BindingContext(binding, bindingParameterCollection);   
            IChannelListener<IInputChannel> listener = msmqBindingElement.BuildChannelListener<IInputChannel>(bindingContext);
            listener.Open();
            IInputChannel channel = listener.AcceptChannel();
            channel.Open();
        }
    }
}
