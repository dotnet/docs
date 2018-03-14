// <Snippet5>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;


public class ClientClass {

    public static void Main() { 

// </Snippet5>
// <Snippet6>
        ChannelServices.RegisterChannel(new TcpChannel());

        RemotingConfiguration.RegisterWellKnownClientType(
                                                           typeof(HelloService),
                                                           "tcp://localhost:8082/HelloServiceApplication/MyUri"
                                                         );

        HelloService service = new HelloService();
// </Snippet6>
// <Snippet7>

        if(service == null) {
            Console.WriteLine("Could not locate server.");
            return;
        }


        // Calls the remote method.
        Console.WriteLine();
        Console.WriteLine("Calling remote object");
        Console.WriteLine(service.HelloMethod("Caveman"));
        Console.WriteLine(service.HelloMethod("Spaceman"));
        Console.WriteLine(service.HelloMethod("Client Man"));
        Console.WriteLine("Finished remote object call");
        Console.WriteLine();
    }
}
// </Snippet7>