// System.Runtime.Remoting.Channels.SoapClientFormatterSinkProvider.CreateSink
// System.Runtime.Remoting.Channels.BaseChannelSinkWithProperties

/*
   The following example demonstrates the 'BaseChannelSinkWithProperties'
   class and 'CreateSink' method of 'SoapClientFormatterSinkProvider' class.
   Custom client formatter provider is defined by implementing
   the 'IClientChannelSinkProvider' interface and custom channel sink is
   defined by inheriting 'BaseChannelSinkWithProperties' abstract class.
   The sink provider chain has the custom sink provider and 
   'SoapClientFormatterSinkProvider'. The 'CreateSink' method is used to 
   return a sink to the caller and form the sink chain which is used to process
   the message being passed through it.
*/

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Security.Permissions;
public class ClientClass
{
   [SecurityPermission(SecurityAction.Demand)]
   public static void Main()
   {
      try
      {
         IClientChannelSinkProvider myFormatterProvider =
                           new MyClientFormatterProvider();
         myFormatterProvider.Next =
                           new SoapClientFormatterSinkProvider();
         TcpChannel myTcpChannel = new TcpChannel(null,
                           myFormatterProvider, null);
         ChannelServices.RegisterChannel(myTcpChannel, false);
         RemotingConfiguration.RegisterWellKnownClientType(typeof(HelloService),
                  "tcp://localhost:8082/HelloServiceApplication/MyUri");
         HelloService myService = new HelloService();
         Console.WriteLine(myService.HelloMethod("Welcome to .Net"));
      }
      catch(Exception ex)
      {
         Console.WriteLine("The following exception is raised at client side"+ex.Message);
      }
   }
}

