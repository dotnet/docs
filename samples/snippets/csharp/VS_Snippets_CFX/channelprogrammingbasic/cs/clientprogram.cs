// <snippet2>
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
namespace ProgrammingChannels
{
class Client
{

    static void RunClient()
    {
        //Step1: Create a binding with just HTTP.
        BindingElement[] bindingElements = new BindingElement[2];
        bindingElements[0] = new TextMessageEncodingBindingElement();
        bindingElements[1] = new HttpTransportBindingElement();
        CustomBinding binding = new CustomBinding(bindingElements);

        //Step2: Use the binding to build the channel factory.
        IChannelFactory<IRequestChannel> factory =
        binding.BuildChannelFactory<IRequestChannel>(
                         new BindingParameterCollection());
        //Open the channel factory.
        factory.Open();

        //Step3: Use the channel factory to create a channel.
        IRequestChannel channel = factory.CreateChannel(
           new EndpointAddress("http://localhost:8080/channelapp"));
        channel.Open();

        //Step4: Create a message.
        Message requestmessage = Message.CreateMessage(
            binding.MessageVersion,
            "http://contoso.com/someaction",
             "This is the body data");
        //Send message.
        Message replymessage = channel.Request(requestmessage);
        Console.WriteLine("Reply message received");
        Console.WriteLine($"Reply action: {replymessage.Headers.Action}");
        string data = replymessage.GetBody<string>();
        Console.WriteLine($"Reply content: {data}");

        //Step5: Do not forget to close the message.
        replymessage.Close();
        //Do not forget to close the channel.
        channel.Close();
        //Do not forget to close the factory.
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
// </snippet2>