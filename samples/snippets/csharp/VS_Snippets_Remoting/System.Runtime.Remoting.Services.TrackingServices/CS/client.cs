//<snippet0>
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class Client
{
    public static void Main(string[] args)
    {
        // Register the TCP channel.
        ChannelServices.RegisterChannel(new TcpChannel());

        // Register the client for the remote object.
        WellKnownClientTypeEntry remoteType = new WellKnownClientTypeEntry(
            typeof(RemoteService),"tcp://localhost:1234/TcpService");
        RemotingConfiguration.RegisterWellKnownClientType(remoteType);

        // Create an instance of the remote object.
        RemoteService service = new RemoteService(); 

        // Invoke a method on the remote object.
        service.Hello("world");
        Console.WriteLine("Hello invoked on server.");
    }
}
//</snippet0>
