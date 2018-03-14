/* This file is a support file for demonstrating IClientChannelSinkProvider 
and ServerProcessing. */

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Security.Permissions;
using MyLogging;

public class MyServerProcessingClient 
{
   [SecurityPermission(SecurityAction.LinkDemand)]
   public static void Main() 
   {
      IClientChannelSinkProvider mySoapClientFormatterProvider = new SoapClientFormatterSinkProvider();
      IClientChannelSinkProvider myClientProvider = new MyServerProcessingLogClientChannelSinkProviderData();
      
      mySoapClientFormatterProvider.Next = myClientProvider;
            
      TcpChannel channel = new TcpChannel(null, mySoapClientFormatterProvider, null);

      ChannelServices.RegisterChannel(channel);

      RemotingConfiguration.RegisterWellKnownClientType(typeof(MyHelloService),
                                    "tcp://localhost:8082/HelloServiceApplication/MyUri");

      MyHelloService myService = new MyHelloService();

      if(myService == null) 
      {
         Console.WriteLine("Could not locate server.");
         return;
      }

      // Call remote method.
      Console.WriteLine();
      Console.WriteLine("Calling remote object");
      Console.WriteLine(myService.HelloMethod("Caveman"));
      Console.WriteLine(myService.HelloMethod("Spaceman"));
      Console.WriteLine(myService.HelloMethod("Client Man"));
      Console.WriteLine("Finished remote object call");
      Console.WriteLine();
   }
}