// <snippet30>
using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Security.Permissions;

public class Client
{
    [SecurityPermission(SecurityAction.LinkDemand)]
    public static void Main()
    {

// <snippet31>
        // Specify client channel properties.
        IDictionary dict = new Hashtable();
        dict["port"] = 9090;
        dict["impersonationLevel"] = "Identify";
        dict["authenticationPolicy"] = "AuthPolicy, Policy";
 
        // Set up a client channel.
        TcpClientChannel clientChannel = new TcpClientChannel(dict, null);
        ChannelServices.RegisterChannel(clientChannel, false);
// </snippet31>

        // Obtain a proxy for a remote object.
        RemotingConfiguration.RegisterWellKnownClientType(
            typeof(Remotable), "tcp://localhost:9090/Remotable.rem"
        );

        // Call a method on the object.
        Remotable remoteObject = new Remotable();
        Console.WriteLine( remoteObject.GetMessage() );
    }

}
// </snippet30>
