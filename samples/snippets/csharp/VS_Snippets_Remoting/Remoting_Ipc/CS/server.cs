// <snippet10>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;

public class IpcServer
{

    public static void Main ()
    {
// <snippet11>
        // Create and register an IPC channel
        IpcServerChannel serverChannel = new IpcServerChannel("remote");
        ChannelServices.RegisterChannel(serverChannel);
// </snippet11>

        // Expose an object
        RemotingConfiguration.RegisterWellKnownServiceType( typeof(Counter), "counter", WellKnownObjectMode.Singleton );

        // Wait for calls
// <snippet12>
        Console.WriteLine("Listening on {0}", serverChannel.GetChannelUri());
// </snippet12>
        Console.ReadLine();
    }

}
// </snippet10>
