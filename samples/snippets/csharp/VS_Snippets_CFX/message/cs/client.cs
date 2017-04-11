//<snippet0>
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Runtime.Serialization;

namespace ConsoleApplication1
{
    class client
    {


        static void RunClient()
        {
            //Step1: create a binding with just HTTP
            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new HttpTransportBindingElement());
            //Step2: use the binding to build the channel factory
            IChannelFactory<IRequestChannel> factory =
            binding.BuildChannelFactory<IRequestChannel>(
                             new BindingParameterCollection());
            //open the channel factory
            factory.Open();
            //Step3: use the channel factory to create a channel
            IRequestChannel channel = factory.CreateChannel(
               new EndpointAddress("http://localhost:8080/channelapp"));
            channel.Open();
            //Step4: create a message
            Message requestmessage = Message.CreateMessage(
                MessageVersion.Soap12WSAddressing10,
                "http://contoso.com/someaction",
                 "This is the body data");
            //send message
            Message replymessage = channel.Request(requestmessage);
            Console.WriteLine("Reply message received");
            Console.WriteLine("Reply action: {0}",
                                  replymessage.Headers.Action);
            string data = replymessage.GetBody<string>();
            Console.WriteLine("Reply content: {0}", data);
            //Step5: don't forget to close the message
            requestmessage.Close();
            replymessage.Close();
            //don't forget to close the channel
            channel.Close();
            //don't forget to close the factory
            factory.Close();
        }
        public static void Main()
        {
            Console.WriteLine("Press [ENTER] when service is ready");
            Console.ReadLine();
            RunClient();
            Console.WriteLine("Press [ENTER] to exit");
            Console.ReadLine();
        }
    }
}
//</snippet0>