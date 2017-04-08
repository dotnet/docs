// <snippet20>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;


public class Client
{
    public static void Main ()
    {
// <snippet21>
        IpcClientChannel clientChannel = new IpcClientChannel();
        ChannelServices.RegisterChannel(clientChannel);
// </snippet21>

        RemotingConfiguration.RegisterWellKnownClientType( typeof(Counter) , "ipc://remote/counter" );

        Counter counter = new Counter();
        Console.WriteLine("This is call number {0}.", counter.Count);
    }

}
// </snippet20>
