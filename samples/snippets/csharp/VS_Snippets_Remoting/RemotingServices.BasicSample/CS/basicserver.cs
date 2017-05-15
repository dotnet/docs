using System;
using System.Collections;
using System.IO;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Threading;
using SampleNamespace;


public class Server {
    public static void Main(string[] args) {
        string serverConfigFile = "basicserver.exe.config";
        if ((args.Length > 1) && (args[0].ToLower() == "/c" | args[0].ToLower() == "-c")){
            serverConfigFile = args[1];
        }
        RemotingConfiguration.Configure("channels.config");
        RemotingConfiguration.Configure(serverConfigFile);               

        Console.WriteLine("Listening...");
        
        string keyState = "";
        while (String.Compare(keyState,"0", true) != 0) {
            Console.WriteLine("***** Press 0 to exit this service *****");
            keyState = Console.ReadLine();
        }
    }
}

