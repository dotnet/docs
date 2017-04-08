// class: System.Runtime.Remoting.Activation.UrlAttribute
//<snippet0>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Security.Permissions;

public class Client
{
[SecurityPermission(SecurityAction.Demand)]
    [STAThread]
    public static void Main()
    {
        // Report the initial status.
        Console.WriteLine("Starting client.");

        // Register the TCP channel.
        ChannelServices.RegisterChannel(new TcpChannel());

        //<snippet1>
        // Create a url attribute object.
        UrlAttribute attribute = 
            new UrlAttribute("tcp://localhost:1234/RemoteApp");
        Console.WriteLine("UrlAttribute value: {0}", attribute.UrlValue);
        //</snippet1>
        object[] activationAttributes = new object[] { attribute };

        // Register the client for the remote object.
        RemotingConfiguration.RegisterActivatedClientType(
            typeof(RemoteObject), 
            "tcp://localhost:1234/RemoteApp");

        // Activate the remote object.
        Console.WriteLine("Activating remote object.");
        RemoteObject obj = (RemoteObject) Activator.CreateInstance(
            typeof(RemoteObject), null, activationAttributes);

        // Invoke a method on the remote object.
        Console.WriteLine("Invoking Hello() on remote object.");
        obj.Hello();

        // Inform the user that the program is exiting.
        Console.WriteLine("The client is exiting.");
    }
}
//</snippet0>