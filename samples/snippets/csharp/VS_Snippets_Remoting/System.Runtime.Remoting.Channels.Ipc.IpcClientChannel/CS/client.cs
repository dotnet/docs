/// Class: System.Runtime.Remoting.Channels.Ipc.IpcClientChannel
/// 41 #ctor(IDictionary,IClientChannelSinkProvider)
/// 42 #ctor(String,IClientChannelSinkProvider)
/// 21 ChannelName
/// 23 ChannelPriority
/// 22 CreateMessageSink(String,Object,String@) 
/// 24 Parse(String,String@)

using System;
using System.Runtime.Remoting.Channels.Ipc;

public class Client
{
    public static void Main(string[] args)
    {
        // Create the channel.
        IpcClientChannel clientChannel = new IpcClientChannel();

        // Register the channel.
        System.Runtime.Remoting.Channels.ChannelServices.
            RegisterChannel(clientChannel);

        //<snippet21>
        // Show the name of the channel.
        Console.WriteLine("The name of the channel is {0}.", 
            clientChannel.ChannelName);
        //</snippet21>

        //<snippet23>
        // Show the priority of the channel.
        Console.WriteLine("The priority of the channel is {0}.", 
            clientChannel.ChannelPriority);
        //</snippet23>

        // Register as client for remote object.
        System.Runtime.Remoting.WellKnownClientTypeEntry remoteType = 
            new System.Runtime.Remoting.WellKnownClientTypeEntry(
                typeof(RemoteObject),
                "ipc://localhost:9090/RemoteObject.rem");
        System.Runtime.Remoting.RemotingConfiguration.
            RegisterWellKnownClientType(remoteType);

        //<snippet22>
        // Create a message sink.
        string messageSinkUri;
        System.Runtime.Remoting.Messaging.IMessageSink messageSink =
            clientChannel.CreateMessageSink(
                "ipc://localhost:9090/RemoteObject.rem", null,
                out messageSinkUri);
        Console.WriteLine("The URI of the message sink is {0}.",
            messageSinkUri);
        if (messageSink != null)
        {
            Console.WriteLine("The type of the message sink is {0}.",
                messageSink.GetType().ToString());
        }
        //</snippet22>

        //<snippet24>
        // Parse the object URL.
        string objectUrl = "ipc://localhost:9090/RemoteObject.rem";
        string objectUri;
        string channelUri = clientChannel.Parse(objectUrl, out objectUri);
        Console.WriteLine("The object URL is {0}.", objectUrl);
        Console.WriteLine("The object URI is {0}.", objectUri);
        Console.WriteLine("The channel URI is {0}.", channelUri);
        //</snippet24>

        // Create an instance of the remote object.
        RemoteObject service = new RemoteObject(); 

        // Invoke a method on the remote object.
        Console.WriteLine("The client is invoking the remote object.");
        Console.WriteLine("The remote object has been called {0} times.",
            service.GetCount());
    }
}
