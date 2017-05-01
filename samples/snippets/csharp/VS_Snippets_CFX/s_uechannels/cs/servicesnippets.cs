using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace UE.Samples.Channel
{
    public class Snippets
    {

        public static void Snippet1()
        {
            // <Snippet1>
            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new HttpTransportBindingElement());
            BindingParameterCollection paramCollection = new BindingParameterCollection();
            IChannelListener<IReplyChannel> listener = binding.BuildChannelListener<IReplyChannel>
                (new Uri("http://localhost:8000/ChannelApp"), paramCollection);

            listener.Open();
            IReplyChannel channel = listener.AcceptChannel();
            Console.WriteLine("Listening for messages");
            channel.Open();
            RequestContext request = channel.ReceiveRequest();
            Message msg = request.RequestMessage;
            Console.WriteLine("Message Received");
            Console.WriteLine("Message Action: {0}", msg.Headers.Action);

            if (msg.Headers.Action == "hello")
            {
                Message reply = Message.CreateMessage(MessageVersion.Default, "wcf");
                request.Reply(reply);
            }

            msg.Close();
            channel.Close();
            listener.Close();
            // </Snippet1>
        }


        public static void Snippet5()
        {
            // <Snippet5>
            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new HttpTransportBindingElement());
            Object[] bindingParameters = new Object[2];

            IChannelListener<IReplyChannel> listener = binding.BuildChannelListener<IReplyChannel>
                (bindingParameters);
            listener.Open();
            IReplyChannel channel = listener.AcceptChannel();
            Console.WriteLine("Listening for messages");
            channel.Open();
            RequestContext request = channel.ReceiveRequest();
            Message msg = request.RequestMessage;
            Console.WriteLine("Message Received");
            Console.WriteLine("Message Action: {0}", msg.Headers.Action);

            if (msg.Headers.Action == "hello")
            {
                Message reply = Message.CreateMessage(MessageVersion.Default, "wcf");
                request.Reply(reply);
            }

            msg.Close();
            channel.Close();
            listener.Close();
            // </Snippet5>
        }


        public static void Snippet6()
        {
            // <Snippet6>
            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new HttpTransportBindingElement());
            Object[] bindingParameters = new Object[2];
            IChannelListener<IReplyChannel> listener = binding.BuildChannelListener<IReplyChannel>
                (new Uri("http://localhost:8000/ChannelApp"), bindingParameters);
            // </Snippet6>
        }

        public static void Snippet7()
        {
            // <Snippet7>
            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new HttpTransportBindingElement());
            BindingParameterCollection paramCollection = new BindingParameterCollection();
            IChannelListener<IReplyChannel> listener = binding.BuildChannelListener<IReplyChannel>
                (new Uri("http://localhost:8000/ChannelApp"), "http://localhost:8000/ChannelApp/service", paramCollection);
            // </Snippet7>
        }

        public static void Snippet8()
        {
            // <Snippet8>
            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new HttpTransportBindingElement());
            Object[] bindingParameters = new Object[2];
            IChannelListener<IReplyChannel> listener = binding.BuildChannelListener<IReplyChannel>
                (new Uri("http://localhost:8000/ChannelApp"), "http://localhost:8000/ChannelApp/service", bindingParameters);
            // </Snippet8>
        }

        public static void Snippet9()
        {
            // <Snippet9>
            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new HttpTransportBindingElement());
            BindingParameterCollection paramCollection = new BindingParameterCollection();
            IChannelListener<IReplyChannel> listener = binding.BuildChannelListener<IReplyChannel>
                (new Uri("http://localhost:8000/ChannelApp"), "http://localhost:8000/ChannelApp/service",
                ListenUriMode.Explicit, paramCollection);
            // </Snippet9>
        }

        public static void Snippet10()
        {
            // <Snippet10>
            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new HttpTransportBindingElement());
            Object[] bindingParameters = new Object[2];
            IChannelListener<IReplyChannel> listener = binding.BuildChannelListener<IReplyChannel>
                (new Uri("http://localhost:8000/ChannelApp"), "http://localhost:8000/ChannelApp/service",
                ListenUriMode.Explicit, bindingParameters);
            // </Snippet10>

        }

        public static void Snippet15()
        {
            // <Snippet15>
            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new HttpTransportBindingElement());
            BindingParameterCollection paramCollection = new BindingParameterCollection();

            binding.GetProperty<IReplyChannel>(paramCollection);
            // </Snippet15>
        }

        public static void Snippet17()
        {
            // <Snippet17>
            CustomBinding binding = new CustomBinding();
            HttpTransportBindingElement element = new HttpTransportBindingElement();
            BindingParameterCollection parameters = new BindingParameterCollection();
            Uri baseAddress = new Uri("http://localhost:8000/ChannelApp");
            String relAddress = "http://localhost:8000/ChannelApp/service";
            BindingContext context = new BindingContext(binding, parameters, baseAddress, relAddress, ListenUriMode.Explicit);

            IChannelListener<IReplyChannel> listener = element.BuildChannelListener<IReplyChannel>(context);
            listener.Open();
            IReplyChannel channel = listener.AcceptChannel();
            channel.Open();
            RequestContext request = channel.ReceiveRequest();
            Message msg = request.RequestMessage;
            Console.WriteLine("Message Received");
            Console.WriteLine("Message Action: {0}", msg.Headers.Action);

            if (msg.Headers.Action == "hello")
            {
                Message reply = Message.CreateMessage(MessageVersion.Default, "wcf");
                request.Reply(reply);
            }

            msg.Close();
            channel.Close();
            listener.Close();
            // </Snippet17>
        }

        public static void Snippet19()
        {
            // <Snippet19>
            CustomBinding binding = new CustomBinding();
            HttpTransportBindingElement element = new HttpTransportBindingElement();
            BindingParameterCollection parameters = new BindingParameterCollection();
            Uri baseAddress = new Uri("http://localhost:8000/ChannelApp");
            String relAddress = "http://localhost:8000/ChannelApp/service";
            BindingContext context = new BindingContext(binding, parameters, baseAddress, relAddress, ListenUriMode.Explicit);

            bool bFlag = element.CanBuildChannelListener<IReplyChannel>(context);
            // </Snippet19>
        }

        public static void Snippet20()
        {
            // <Snippet20>
            CustomBinding binding = new CustomBinding();
            HttpTransportBindingElement element = new HttpTransportBindingElement();
            BindingParameterCollection parameters = new BindingParameterCollection();
            parameters.Add(new ServiceCredentials());
            Uri baseAddress = new Uri("http://localhost:8000/ChannelApp");
            String relAddress = "http://localhost:8000/ChannelApp/service";
            BindingContext context = new BindingContext(binding, parameters, baseAddress, relAddress, ListenUriMode.Explicit);

            ServiceCredentials serviceCredentials = element.GetProperty<ServiceCredentials>(context);
            // </Snippet20>
        }

        public static void Snippet22()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            //CustomBinding binding = new CustomBinding();
            //binding.Elements.Add(new HttpTransportBindingElement());
       
            BindingParameterCollection paramCollection = new BindingParameterCollection();
            IChannelListener<IReplyChannel> listener = binding.BuildChannelListener<IReplyChannel>
                (new Uri("http://localhost:8000/ChannelApp"), paramCollection);

            listener.Open();
            IReplyChannel channel = listener.AcceptChannel();
            Console.WriteLine("Listening for messages");
            channel.Open();
            RequestContext request = channel.ReceiveRequest();
            Message msg = request.RequestMessage;
            Console.WriteLine("Message Received");
            Console.WriteLine("Message Action: {0}", msg.Headers.Action);

            if (msg.Headers.Action == "hello")
            {
                Message reply = Message.CreateMessage(MessageVersion.Soap11, "wcf");
                request.Reply(reply);
            }

            msg.Close();
            channel.Close();
            listener.Close();
        }
    }
}
