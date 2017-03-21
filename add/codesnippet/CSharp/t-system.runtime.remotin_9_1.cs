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

        // Create activated client type entry.
        ActivatedClientTypeEntry myActivatedClientTypeEntry =
            new ActivatedClientTypeEntry(typeof(HelloServer),
            "tcp://localhost:8082");

        // Register type on client to activate it on the server.
        RemotingConfiguration.RegisterActivatedClientType(
            myActivatedClientTypeEntry);

        // Activate a client activated object type.
        HelloServer myHelloServer = new HelloServer("ParameterString");

        // Print the object type.
        Console.WriteLine(
            "Object type of client activated object: " +
            myActivatedClientTypeEntry.ObjectType.ToString());

        // Print the application URL.
        Console.WriteLine(
            "Application url where the type is activated: " +
            myActivatedClientTypeEntry.ApplicationUrl);

        // Print the string representation of the type entry.
        Console.WriteLine(
            "Type name, assembly name and application URL " +
            "of the remote object: " + 
            myActivatedClientTypeEntry.ToString());

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