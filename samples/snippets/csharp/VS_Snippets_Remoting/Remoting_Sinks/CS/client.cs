// <snippet10>
using System;
using System.Runtime.Remoting;

public class Client
{

    public static void Main()
    {

        // Set up a remoting client.
        RemotingConfiguration.Configure("Client.config");

        // Call a method on a remote object.
        Remotable remoteObject = new Remotable();
        Console.WriteLine( remoteObject.GetCount() );
    }

}
// </snippet10>
