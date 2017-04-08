
/*
   The example demonstrates the remoting version of a server. When a client
   calls the 'MyPrintMethod' on the 'PrintServer' class, the server object 
   prints the parameters passed from the client and returns the last 
   parameter back to the client. 
*/
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class Sample {

   public static void Main() {
      TcpChannel myTcpChannel = new TcpChannel(8085);
      ChannelServices.RegisterChannel(myTcpChannel);
      RemotingConfiguration.RegisterWellKnownServiceType
         (Type.GetType("PrintServer,ChannelServices_SyncDispatchMessage_Share"),
         "SayHello", WellKnownObjectMode.SingleCall);
      Console.WriteLine("Hit <enter> to exit...");
      Console.ReadLine();            
   }
}

