using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;

public class IpcServer
{

    public static void Main ()
    {
        // Create and register an IPC channel
        IpcServerChannel serverChannel = new IpcServerChannel("remote");
        ChannelServices.RegisterChannel(serverChannel);

        // Expose an object
        RemotingConfiguration.RegisterWellKnownServiceType( typeof(Counter), "counter", WellKnownObjectMode.Singleton );

        // Wait for calls
        Console.WriteLine("Listening on {0}", serverChannel.GetChannelUri());
        Console.ReadLine();
    }

}