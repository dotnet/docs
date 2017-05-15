// <Snippet5>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;

public class Client {
    public static void Main()  {

       // open channel and get handle to object
       ChannelServices.RegisterChannel(new TcpChannel());
            
       //Registering the well known object on the client side for use by the operator new.
       RemotingConfiguration.RegisterWellKnownClientType(typeof(HelloServer), 
                                                          "tcp://localhost:8084/SayHello");
       HelloServer obj = new HelloServer();

       // call remote method
       Console.WriteLine();
       Console.WriteLine("Before Call");
       Console.WriteLine(obj.HelloMethod("Caveman"));
       Console.WriteLine(obj.HelloMethod("Spaceman"));
       Console.WriteLine(obj.HelloMethod("Client Man"));
       Console.WriteLine("After Call");
       Console.WriteLine();

   }
}
// </Snippet5>