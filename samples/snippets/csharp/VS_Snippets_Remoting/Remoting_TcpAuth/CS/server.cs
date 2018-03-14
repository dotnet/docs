// <snippet20>
using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class Server
{
    public static void Main()
    {
// <snippet21>
        // Specify server channel properties.
        IDictionary dict = new Hashtable();
        dict["port"] = 9090;
        dict["authenticationMode"] = "IdentifyCallers";
 
        // Set up a server channel.
        TcpServerChannel serverChannel = new TcpServerChannel(dict, null);
        ChannelServices.RegisterChannel(serverChannel, false);    
// </snippet21>

        // Set up a remote object.
        RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(Remotable), "Remotable.rem", WellKnownObjectMode.Singleton
        );

        // Wait for method calls.
        Console.WriteLine("Listening...");
        Console.ReadLine();
    }
}
// </snippet20>
