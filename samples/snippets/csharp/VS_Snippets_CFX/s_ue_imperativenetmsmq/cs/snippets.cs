using System;

using System.ServiceModel.Channels;
using System.Configuration;
using System.Messaging;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples

{
    class Snippets
    {
        public static void Snippet2()
        {
            // <Snippet2>
            MsmqTransportBindingElement transportBindingElement = new MsmqTransportBindingElement();
            transportBindingElement.MaxPoolSize = 5;
            // </Snippet2>
        }

        public static void Snippet3()
        {
            // <Snippet3>
            MsmqTransportBindingElement transportBindingElement = new MsmqTransportBindingElement();
            transportBindingElement.QueueTransferProtocol = QueueTransferProtocol.Native;
            // </Snippet3>
        }

        public static void Snippet4()
        {
            // <Snippet4>
            MsmqTransportBindingElement transportBindingElement = new MsmqTransportBindingElement();
            string scheme = transportBindingElement.Scheme;
            // </Snippet4>
        }

        public static void Snippet5()
        {
            // <Snippet5>
            MsmqTransportBindingElement transportBindingElement = new MsmqTransportBindingElement();
            transportBindingElement.UseActiveDirectory = true;
            // </Snippet5>
        }

        public static void Snippet6()
        {
            // <Snippet6>
            MsmqTransportBindingElement transportBindingElement = new MsmqTransportBindingElement();
            BindingElement bindingElement = transportBindingElement.Clone();
            // </Snippet6>
        }

        public static void Snippet7()
        {
            BinaryMessageEncodingBindingElement encodingBindingElement = new BinaryMessageEncodingBindingElement();
            MsmqTransportBindingElement transportBindingElement = new MsmqTransportBindingElement();
            CustomBinding binding = new CustomBinding(encodingBindingElement, transportBindingElement);
            BindingParameterCollection bindingParams = new BindingParameterCollection();
            BindingContext context = new BindingContext(binding, bindingParams);

            // <Snippet7>
            transportBindingElement.BuildChannelFactory<IOutputChannel>(context);
            // </Snippet7>
        }

        public static void Snippet8()
        {
            BinaryMessageEncodingBindingElement encodingBindingElement = new BinaryMessageEncodingBindingElement();
            MsmqTransportBindingElement transportBindingElement = new MsmqTransportBindingElement();
            CustomBinding binding = new CustomBinding(encodingBindingElement, transportBindingElement);
            BindingParameterCollection bindingParams = new BindingParameterCollection();
            BindingContext context = new BindingContext(binding, bindingParams);

            // <Snippet8>
            transportBindingElement.BuildChannelListener<IInputChannel>(context);
            // </Snippet8>
        }

        public static void Snippet9()
        {
            BinaryMessageEncodingBindingElement encodingBindingElement = new BinaryMessageEncodingBindingElement();
            MsmqTransportBindingElement transportBindingElement = new MsmqTransportBindingElement();
            CustomBinding binding = new CustomBinding(encodingBindingElement, transportBindingElement);
            BindingParameterCollection bindingParams = new BindingParameterCollection();
            BindingContext context = new BindingContext(binding, bindingParams);

            // <Snippet9>
            if (transportBindingElement.CanBuildChannelFactory<IOutputChannel>(context))
            {
                // Do something...
            }
            // </Snippet9>
        }

        public static void Snippet10()
        {
            BinaryMessageEncodingBindingElement encodingBindingElement = new BinaryMessageEncodingBindingElement();
            MsmqTransportBindingElement transportBindingElement = new MsmqTransportBindingElement();
            CustomBinding binding = new CustomBinding(encodingBindingElement, transportBindingElement);
            BindingParameterCollection bindingParams = new BindingParameterCollection();
            BindingContext context = new BindingContext(binding, bindingParams);

            // <Snippet10>
            if (transportBindingElement.CanBuildChannelListener<IInputChannel>(context))
            {
                // Do something...
            }
            // </Snippet10>
        }
    }
}
