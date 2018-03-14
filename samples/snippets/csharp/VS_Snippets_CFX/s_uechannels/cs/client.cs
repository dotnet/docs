using System;
using System.ServiceModel;
using System.ServiceModel.Channels;


namespace client
{
    class client
    {
        static void Main(string[] args)
        {
            Snippets.Snippet21();

            // <Snippet2>
//            CustomBinding binding = new CustomBinding();
//            binding.Elements.Add(new HttpTransportBindingElement());
//            BindingParameterCollection paramCollection = new BindingParameterCollection();

//            IChannelFactory<IRequestChannel> factory = binding.BuildChannelFactory<IRequestChannel>(paramCollection);
//            factory.Open();
////            EndpointAddress address = new EndpointAddress("http://localhost:8000/ChannelApp");
//            EndpointAddress address = new EndpointAddress("http://localhost:8000/ChannelApp/service");

//            IRequestChannel channel = factory.CreateChannel(address);
//            channel.Open();
//            Message request = Message.CreateMessage(MessageVersion.Default, "hello");
//            Message reply = channel.Request(request);
//            Console.Out.WriteLine(reply.Headers.Action);
//            reply.Close();
//            channel.Close();
//            factory.Close();
            // </Snippet2>
        }
    }
}
