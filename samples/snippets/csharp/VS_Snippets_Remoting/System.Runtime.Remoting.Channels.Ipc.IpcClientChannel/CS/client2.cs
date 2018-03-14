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
    public static IpcClientChannel Ctor1()
    {
        //<snippet41>
        // Create the client channel.
        System.Collections.IDictionary properties = 
            new System.Collections.Hashtable();
        properties["name"] = "ipc client";
        properties["priority"] = "1";
        System.Runtime.Remoting.Channels.IClientChannelSinkProvider 
            sinkProvider = null;
        IpcClientChannel clientChannel = 
            new IpcClientChannel(properties, sinkProvider);
        //</snippet41>
        return clientChannel;
    }

    public static IpcClientChannel Ctor2()
    {
        //<snippet42>
        // Create the client channel.
        string name = "ipc client";
        System.Runtime.Remoting.Channels.IClientChannelSinkProvider 
            sinkProvider = null;
        IpcClientChannel clientChannel = 
            new IpcClientChannel(name, sinkProvider);
        //</snippet42>
        return clientChannel;
    }

    public static void Main(string[] args)
    {
        // Create the client channel.
        IpcClientChannel clientChannel = null;
        if (false) { }
        else if (args[0] == "1") clientChannel = Ctor1();
        else if (args[0] == "2") clientChannel = Ctor2();
        else throw new ApplicationException("Invalid argument.");

        // Register the channel.
        System.Runtime.Remoting.Channels.ChannelServices.
            RegisterChannel(clientChannel);

        // Register as client for remote object.
        System.Runtime.Remoting.WellKnownClientTypeEntry remoteType = 
            new System.Runtime.Remoting.WellKnownClientTypeEntry(
                typeof(RemoteObject),
                "ipc://localhost:9090/RemoteObject.rem");
        System.Runtime.Remoting.RemotingConfiguration.
            RegisterWellKnownClientType(remoteType);

        // Create an instance of the remote object.
        RemoteObject service = new RemoteObject(); 

        // Invoke a method on the remote object.
        Console.WriteLine("The client is invoking the remote object.");
        Console.WriteLine("The remote object has been called {0} times.",
            service.GetCount());
    }
}
