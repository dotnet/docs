/*
   Supporting file: Server
*/
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

using Logging;

public class Server
{
    public static void Main()
    {
        RemotingConfiguration.Configure("channels.config");
        RemotingConfiguration.Configure("server.exe.config");               

        Console.WriteLine("Listening...");
        
        String keyState = "";
        while (String.Compare(keyState,"0", true) != 0)
        {
            Console.WriteLine("***** Press 0 to exit this service *****");
            keyState = Console.ReadLine();
        }
    }
}