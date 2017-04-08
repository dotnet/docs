using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class MyClient
{
   public static void Main()
   {
      ChannelServices.RegisterChannel(new TcpChannel());
      ActivatedClientTypeEntry myActivatedClientTypeEntry =
                        new ActivatedClientTypeEntry(typeof(HelloServer),
                                                 "tcp://localhost:8082");
      // Register 'HelloServer' Type on the client end so that it can be
      // activated on the server.
      RemotingConfiguration.RegisterActivatedClientType(
                                         myActivatedClientTypeEntry);
      // Obtain a proxy object for the remote object.
      HelloServer myHelloServer = new HelloServer("ParameterString");
      if (myHelloServer == null)
      {
         System.Console.WriteLine("Could not locate server");
      }
      else
      {
         Console.WriteLine("Calling remote object");
         Console.WriteLine(myHelloServer.HelloMethod("Bill"));
      }
    }
}
