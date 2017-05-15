using System;
using System.Runtime.Remoting.Channels.Ipc;

public class Server
{
    public static void Main(string[] args)
    {
        // Create the server channel.
        IpcChannel serverChannel = 
            new IpcChannel("localhost:9090"); 

        // Register the server channel.
        System.Runtime.Remoting.Channels.ChannelServices.RegisterChannel(
            serverChannel);

        // Expose an object for remote calls.
        System.Runtime.Remoting.RemotingConfiguration.
            RegisterWellKnownServiceType(
                typeof(RemoteObject), "RemoteObject.rem", 
                System.Runtime.Remoting.WellKnownObjectMode.Singleton);

        // Wait for the user prompt.
        Console.WriteLine("Press ENTER to exit the server.");
        Console.ReadLine();
        Console.WriteLine("The server is exiting.");
    }
}
