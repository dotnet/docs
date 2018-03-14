//<snippet1>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class MyClient
{
    public static void Main()
    {
        // Register TCP Channel.
        ChannelServices.RegisterChannel(new TcpChannel());

        //<snippet2>
        // Create activated client type entry.
        ActivatedClientTypeEntry myActivatedClientTypeEntry =
            new ActivatedClientTypeEntry(typeof(HelloServer),
            "tcp://localhost:8082");
        //</snippet2>

        // Register type on client to activate it on the server.
        RemotingConfiguration.RegisterActivatedClientType(
            myActivatedClientTypeEntry);

        // Activate a client activated object type.
        HelloServer myHelloServer = new HelloServer("ParameterString");

        //<snippet3>
        // Print the object type.
        Console.WriteLine(
            "Object type of client activated object: " +
            myActivatedClientTypeEntry.ObjectType.ToString());
        //</snippet3>

        //<snippet4>
        // Print the application URL.
        Console.WriteLine(
            "Application url where the type is activated: " +
            myActivatedClientTypeEntry.ApplicationUrl);
        //</snippet4>

        //<snippet5>
        // Print the string representation of the type entry.
        Console.WriteLine(
            "Type name, assembly name and application URL " +
            "of the remote object: " + 
            myActivatedClientTypeEntry.ToString());
        //</snippet5>

        // Print a blank line.
        Console.WriteLine();

        // Check that server was located.
        if (myHelloServer == null)
        {
            Console.WriteLine("Could not locate server");
        }
        else
        {
            Console.WriteLine("Calling remote object");
            Console.WriteLine(myHelloServer.HelloMethod("Bill"));
        }
    }
}
//</snippet1>
