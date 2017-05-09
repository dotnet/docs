// <Snippet1>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class ClientClass {

    public static void Main() { 

        ChannelServices.RegisterChannel(new TcpChannel());

        RemotingConfiguration.RegisterActivatedClientType(typeof(HelloServiceClass),
                                                   "tcp://localhost:8082");

        try
        {
            HelloServiceClass service = new HelloServiceClass();


           // Calls the remote method.
           Console.WriteLine();
           Console.WriteLine("Calling remote object");
           Console.WriteLine(service.HelloMethod("Caveman"));
           Console.WriteLine(service.HelloMethod("Spaceman"));
           Console.WriteLine(service.HelloMethod("Client Man"));
           Console.WriteLine("Finished remote object call");
           Console.WriteLine();
        }
	catch (Exception ex)
	{
	   Console.WriteLine("An exception occured: " + ex.Message);
        }
    }
}
// </Snippet1>