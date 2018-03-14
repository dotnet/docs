// class: System.Runtime.Remoting.Channels.Tcp.TcpClientChannel
// client.cs:
//        Ctor(string, IClientChannelSinkProvider)
//        CreateMessageSink
//        Parse

//<snippet30>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Security.Permissions;

public class Client
{
[SecurityPermission(SecurityAction.Demand)]
    public static void Main(string[] args)
    {
        //<snippet31>
        // Create the channel.
        TcpClientChannel clientChannel = new TcpClientChannel("Client", null);
        //</snippet31>

        // Register the channel.
        ChannelServices.RegisterChannel(clientChannel);

        // Register as client for remote object.
        WellKnownClientTypeEntry remoteType = new WellKnownClientTypeEntry(
            typeof(RemoteObject),"tcp://localhost:9090/RemoteObject.rem");
        RemotingConfiguration.RegisterWellKnownClientType(remoteType);

        //<snippet32>
        // Create a message sink.
        string objectUri;
        System.Runtime.Remoting.Messaging.IMessageSink messageSink = 
            clientChannel.CreateMessageSink(
                "tcp://localhost:9090/RemoteObject.rem", null,
                out objectUri);
        Console.WriteLine("The URI of the message sink is {0}.", 
            objectUri);
        if (messageSink != null)
        {
            Console.WriteLine("The type of the message sink is {0}.", 
                messageSink.GetType().ToString());
        }
        //</snippet32>

        //<snippet33>
        // Parse the channel's URI.
        string objectUrl = "tcp://localhost:9090/RemoteObject.rem";
        string channelUri = clientChannel.Parse(objectUrl, out objectUri);
        Console.WriteLine("The object URL is {0}.", objectUrl);
        Console.WriteLine("The object URI is {0}.", objectUri);
        Console.WriteLine("The channel URI is {0}.", channelUri);
        //</snippet33>
        
        // Create an instance of the remote object.
        RemoteObject service = new RemoteObject(); 

        // Invoke a method on the remote object.
        Console.WriteLine("The client is invoking the remote object.");
        Console.WriteLine("The remote object has been called {0} times.",
            service.GetCount());
    }
}
//</snippet30>
