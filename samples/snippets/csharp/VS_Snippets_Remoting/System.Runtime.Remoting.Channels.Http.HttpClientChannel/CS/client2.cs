/// x    broken
/// +    done
/// 9    number of snippet
/// Need snippets:
///    21    #ctor(IDictionary,IClientChannelSinkProvider)
///    22    #ctor(string,sinkProvider)
///    11    CreateMessageSink
///    12    Item
///    12    Keys
///    13    Parse

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

public class Client2
{
    private static HttpClientChannel Ctor1()
    {
        //<snippet21>
        // Create a client channel.
        System.Collections.Hashtable properties =
            new System.Collections.Hashtable();
        properties["port"] = 9090;
        IClientChannelSinkProvider sinkProvider = null;
        HttpClientChannel clientChannel = new HttpClientChannel(
            properties, sinkProvider);
        //</snippet21>

        return clientChannel;
    }

    private static HttpClientChannel Ctor2()
    {
        //<snippet22>
        // Create a client channel.
        string name = "RemotingClient";
        IClientChannelSinkProvider sinkProvider = null;
        HttpClientChannel clientChannel = new HttpClientChannel(name,
            sinkProvider);
        //</snippet22>

        return clientChannel;
    }

    public static void Main(string[] args)
    {
        // Create the channel.
        HttpClientChannel clientChannel = null;
        string overload = args[0];
        if      (overload == "1") clientChannel = Ctor1();
        else if (overload == "2") clientChannel = Ctor2();
        else throw new Exception("Argument " + args[0] + "was invalid.");

        // Register the channel and the client.
        Register(clientChannel);

        // Create an instance of the remote object.
        RemoteObject service = new RemoteObject(); 

        // Invoke a method on the remote object.
        InvokeRemoteObject(service);
    }

    static void Register(HttpClientChannel channel)
    {
        // Register the channel.
        ChannelServices.RegisterChannel(channel);

        // Register as client for remote object.
        WellKnownClientTypeEntry remoteType = 
            new WellKnownClientTypeEntry(
                typeof(RemoteObject), 
                "http://localhost:9090/RemoteObject.rem");
        RemotingConfiguration.RegisterWellKnownClientType(remoteType);
    }

    static void InvokeRemoteObject(RemoteObject service)
    {
        // Invoke a method on the remote object.
        Console.WriteLine("The client is invoking the remote object.");
        Console.WriteLine("The remote object has been called {0} times.", 
            service.GetCount());
    }
}