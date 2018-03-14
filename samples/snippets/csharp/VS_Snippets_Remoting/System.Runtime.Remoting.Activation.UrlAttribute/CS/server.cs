//<snippet2>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class Server
{
    [STAThread]
    public static void Main()
    {
        // Report the status to the user.
        Console.WriteLine("Starting server.");

        // Register the TCP channel.
        ChannelServices.RegisterChannel(new TcpChannel(1234));

        // Set the application name.
        RemotingConfiguration.ApplicationName = "RemoteApp";

        // Register the object for remoting.
        RemotingConfiguration.RegisterActivatedServiceType(
            typeof(RemoteObject));

        // Wait until the user presses ENTER.
        Console.WriteLine("Press ENTER to exit.");
        Console.ReadLine();
        Console.WriteLine("The server is exiting.");
    }
}
//</snippet2>