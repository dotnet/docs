//<snippet10>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class Server
{
    public static void Main(string[] args)
    {
        // Create the server channel.
        TcpChannel serverChannel = new TcpChannel(9090);

        // Register the server channel.
        ChannelServices.RegisterChannel(serverChannel);

        // Expose an object for remote calls.
        RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(RemoteObject), "RemoteObject.rem", 
            WellKnownObjectMode.Singleton);

        // Wait for the user prompt.
        Console.WriteLine("Press ENTER to exit the server.");
        Console.ReadLine();
    }
}
//</snippet10>
