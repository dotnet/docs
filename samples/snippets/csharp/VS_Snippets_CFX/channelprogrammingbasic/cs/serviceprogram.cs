// <snippet1>
using System;
using System.ServiceModel.Channels;
namespace ProgrammingChannels
{
class Service
{
static void RunService()
{
    //Step1: Create a custom binding with just TCP.
    BindingElement[] bindingElements = new BindingElement[2];
    bindingElements[0] = new TextMessageEncodingBindingElement();
    bindingElements[1] = new HttpTransportBindingElement();

    CustomBinding binding = new CustomBinding(bindingElements);

    //Step2: Use the binding to build the channel listener.
    IChannelListener<IReplyChannel> listener =
          binding.BuildChannelListener<IReplyChannel>(
             new Uri("http://localhost:8080/channelapp"),
           new BindingParameterCollection());

    //Step3: Listening for messages.
    listener.Open();
    Console.WriteLine(
           "Listening for incoming channel connections");
    //Wait for and accept incoming connections.
    IReplyChannel channel = listener.AcceptChannel();
    Console.WriteLine("Channel accepted. Listening for messages");
    //Open the accepted channel.
    channel.Open();
    //Wait for and receive a message from the channel.
    RequestContext request= channel.ReceiveRequest();
    //Step4: Reading the request message.
    Message message = request.RequestMessage;
    Console.WriteLine("Message received");
    Console.WriteLine($"Message action: {message.Headers.Action}");
    string data=message.GetBody<string>();
    Console.WriteLine($"Message content: {data}");
    //Send a reply.
    Message replymessage=Message.CreateMessage(
        binding.MessageVersion,
        "http://contoso.com/someotheraction",
         data);
    request.Reply(replymessage);
    //Step5: Closing objects.
    //Do not forget to close the message.
    message.Close();
    //Do not forget to close RequestContext.
    request.Close();
    //Do not forget to close channels.
    channel.Close();
    //Do not forget to close listeners.
    listener.Close();
}
public static void Main()
{
    Service.RunService();
    Console.WriteLine("Press enter to exit");
    Console.ReadLine();
}
}
}
// </snippet1>