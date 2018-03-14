// <snippet50>
using System;
using System.Runtime.Remoting;

public class Server
{

    public static void Main()
    {

        // Set up a remoting server.
        RemotingConfiguration.Configure("Server.config");

        // Wait for method calls.
        Console.WriteLine("Listening...");
        Console.ReadLine();

    }

}
// </snippet50>
